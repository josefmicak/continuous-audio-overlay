using AudioSwitcher.AudioApi.CoreAudio;
using AudioSwitcher.AudioApi.Observables;
using ContinuousAudioOverlay.Helpers;
using System.Runtime.InteropServices;
using Windows.Media.Control;
using Windows.Storage.Streams;

namespace ContinuousAudioOverlay
{
    public enum AppCommands
    {
        BrowserBack = 1,
        BrowserForward = 2,
        BrowserRefresh = 3,
        BrowserStop = 4,
        BrowserSearch = 5,
        BrowserFavorite = 6,
        BrowserHome = 7,
        VolumeMute = 8,
        VolumeDown = 9,
        VolumeUp = 10,
        MediaNext = 11,
        MediaPrevious = 12,
        MediaStop = 13,
        MediaPlayPause = 14,
        LaunchMail = 15,
        LaunchMediaSelect = 16,
        LaunchApp1 = 17,
        LaunchApp2 = 18,
        BassDown = 19,
        BassBoost = 20,
        BassUp = 21,
        TrebleUp = 22,
        TrebleDown = 23,
        MicrophoneMute = 24,
        MicrophoneVolumeUp = 25,
        MicrophoneVolumeDown = 26,
        Help = 27,
        Find = 28,
        New = 29,
        Open = 30,
        Close = 31,
        Save = 32,
        Print = 33,
        Undo = 34,
        Redo = 35,
        Copy = 36,
        Cut = 37,
        Paste = 38,
        ReplyToMail = 39,
        ForwardMail = 40,
        SendMail = 41,
        SpellCheck = 42,
        Dictate = 43,
        MicrophoneOnOff = 44,
        CorrectionList = 45,
        MediaPlay = 46,
        MediaPause = 47,
        MediaRecord = 48,
        MediaFastForward = 49,
        MediaRewind = 50,
        MediaChannelUp = 51,
        MediaChannelDown = 52,
        Delete = 53,
        Flip3D = 54
    }

    public partial class Form1 : Form
    {

        #region Fields

        private List<CoreAudioDevice>? _playbackDevices = null;
        private CoreAudioController? _coreAudioController = null;
        private Color _controlBackgroundColor = Color.FromArgb(255, 191, 0);
        private Color _hoverColor = Color.Yellow;
        private bool _outputDeviceDropdownEnter = false;
        private bool _radioDropdownEnter = false;
        private GlobalSystemMediaTransportControlsSessionManager? _mediaManager;
        private bool _muted = false;
        private int _resumeRadioIndex = -1;
        private int _previousRadioIndex = -1;
        private (int, int) _outputDeviceIndexes = (-1, -1);
        private bool _loaded = false;
        private bool _folded = false;
        private BassService _bassService;
        private SettingsForm? _settingsForm;
        private bool _isOutputDeviceChangingFromSystem = false;
        private bool _isOutputDeviceChangingFromApplication = false;
        private static ManualResetEvent mre = new ManualResetEvent(false);
        private static Form? frm;
        
        #endregion

        #region Properties

        #endregion

        #region Constructor

        public Form1()
        {
            _bassService = new BassService();

            InitializeComponent();
            InitializeCoreAudioController();

            Shown += async (_, __) => await InitializeCustomFormComponents();

            VolumeSlider.Value = (int)GetDefaultPlaybackDevice().Volume;
            UpdateSourceLabel("<no source>");
            _bassService.OnMetaDataChanged += UpdateRadioTitle;
        }

        #endregion

        #region Win32 Interop

        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const uint SWP_NOSIZE = 0x0001;
        private const uint SWP_NOMOVE = 0x0002;
        private const uint SWP_NOOWNERZORDER = 0x0200;
        private const uint SWP_SHOWWINDOW = 0x0040;
        private const int SW_RESTORE = 9;
        private const int SW_SHOW = 5;
        private const int WM_NCLBUTTONDBLCLK = 0x00A3;
        private const int WM_APPCOMMAND = 0x319;

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll")] static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")] static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);

        #endregion

        #region Private methods

        private async Task InitializeCustomFormComponents()
        {
            var outputTask = InitializeOutputDevices();
            var radioListTask = InitializeRadioList();

            await Task.WhenAll(outputTask, radioListTask);

            _loaded = true;
        }

        private async Task InitializeRadioList()
        {
            List<Radio> radioList = await _bassService.GetRadioList();
            RadioDropDownList.Items.Clear();
            RadioDropDownList.Items.AddRange(radioList.Select(radio => radio.RadioName).ToArray());
            RadioDropDownList.Items.Add("<no radio>");
            RadioDropDownList.SelectedIndex = RadioDropDownList.Items.Count - 1;
        }

        private static void Send(AppCommands cmd)
        {
            if (frm == null) Initialize();
            frm?.Invoke(new MethodInvoker(() => SendMessage(frm.Handle, WM_APPCOMMAND, frm.Handle, (IntPtr)((int)cmd << 16))));
        }

        private static void Initialize()
        {
            var t = new Thread(() =>
            {
                frm = new Form();
                var dummy = frm.Handle;
                frm.BeginInvoke(new MethodInvoker(() => mre.Set()));
                System.Windows.Forms.Application.Run();
            });
            t.SetApartmentState(ApartmentState.STA);
            t.IsBackground = true;
            t.Start();
            mre.WaitOne();
        }

        private async Task InitializeOutputDevices()
        {
            foreach (CoreAudioDevice d in await GetPlaybackDevices())
            {
                if (d.IsPlaybackDevice)
                {
                    OutputDeviceDropDown.Items.Add(d.FullName);
                }
                if (d.IsDefaultDevice)
                {
                    OutputDeviceDropDown.SelectedIndex = OutputDeviceDropDown.Items.Count - 1;
                }
            }
        }

        private void InitializeCoreAudioController()
        {
            //Metoda slouzi k tomu, aby byly zaznamenany zmeny vystupnich zvukovych zarizeni provedene mimo aplikaci
            GetCoreAudioController().AudioDeviceChanged.Subscribe(x =>
            {
                if (!OutputDeviceDropDown.IsHandleCreated || _isOutputDeviceChangingFromApplication)
                {
                    //Pokud zmenu provedl uzivatel v aplikaci, neni potreba, aby zde byly provadeny jakekoli zmeny
                    return;
                }

                OutputDeviceDropDown.BeginInvoke(new Action(() =>
                {
                    int index = OutputDeviceDropDown.Items.IndexOf(x.Device.FullName);

                    if (index == -1 || OutputDeviceDropDown.SelectedIndex == index)
                    {
                        return;
                    }

                    _isOutputDeviceChangingFromSystem = true;

                    try
                    {
                        OutputDeviceDropDown.SelectedIndex = index;
                    }
                    finally
                    {
                        _isOutputDeviceChangingFromSystem = false;
                    }

                }));
            });
        }

        private async Task ChangeRadioIndex(int radioIndex)
        {
            if (_bassService.BassInitialized())
            {
                ReleaseBassResources();
            }

            if (radioIndex != RadioDropDownList.Items.Count - 1)
            {
                await _bassService.IndexChanged(radioIndex);
                if (_bassService.GetRadioPlaying())
                {
                    if (radioIndex != _resumeRadioIndex)//Remember previous station in case radio is stopped
                    {
                        _previousRadioIndex = _resumeRadioIndex;
                    }
                    _resumeRadioIndex = radioIndex;
                    ThumbnailPictureBox.Image = null;
                    UpdateSourceLabel("Radio");
                }
            }

            if (_loaded)
            {
                GlobalSystemMediaTransportControlsSessionPlaybackInfo? currentMediaPlaybackInfo = GetPlaybackInfo();
                if (currentMediaPlaybackInfo != null)
                {
                    if (currentMediaPlaybackInfo.PlaybackStatus == GlobalSystemMediaTransportControlsSessionPlaybackStatus.Playing)
                    {
                        Send(AppCommands.MediaPause);
                    }
                }
            }
        }

        private void ReleaseBassResources()
        {
            _bassService.ReleaseBassResources();
        }

        private void StopRadio()
        {
            MediaControlsUpdateTitleTextBox(true);
            ReleaseBassResources();
            RadioDropDownList.SelectedIndex = RadioDropDownList.Items.Count - 1;
        }

        private void ChangeBackgroundColorMouseEnter(object sender, EventArgs e)
        {
            try
            {
                var pictureBox = (PictureBox)sender;
                pictureBox.BackColor = _hoverColor;
            }
            catch
            {
                var pictureBox = (Button)sender;
                pictureBox.BackColor = _hoverColor;
            }
        }

        private void ChangeBackgroundColorMouseLeave(object sender, EventArgs e)
        {
            try
            {
                var pictureBox = (PictureBox)sender;
                pictureBox.BackColor = _controlBackgroundColor;
            }
            catch
            {
                var pictureBox = (Button)sender;
                pictureBox.BackColor = _controlBackgroundColor;
            }
        }

        private async Task<GlobalSystemMediaTransportControlsSessionMediaProperties?> GetMediaInfoAsync()
        {
            if (_mediaManager == null)
            {
                await InitializeMediaManager();
            }
            GlobalSystemMediaTransportControlsSession session =
                _mediaManager!.GetCurrentSession();
            //session.MediaPropertiesChanged += MediaPropertiesChanged;
            //session.PlaybackInfoChanged += PlaybackInfoChanged;
            //session.TimelinePropertiesChanged += TimelinePropertiesChanged;
            if (session != null)
            {
                try
                {
                    GlobalSystemMediaTransportControlsSessionMediaProperties properties =
                        await session.TryGetMediaPropertiesAsync();

                    return properties;
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        private void MediaPropertiesChanged(GlobalSystemMediaTransportControlsSession sender, object args)
        {
            MediaControlsUpdateTitleTextBox();
        }

        private async void MediaControlsUpdateTitleTextBox(bool alwaysUpdate = false)
        {
            if (!alwaysUpdate && _bassService.GetRadioPlaying())
            {
                //We don't want to update media properties in case radio is currently playing
                return;
            }
            //Update media title and thumbnail
            GlobalSystemMediaTransportControlsSessionMediaProperties? currentMediaProperties =
                await GetMediaInfoAsync();

            if (currentMediaProperties != null)
            {
                UpdateTitleTextBox(currentMediaProperties);
            }

            //Update source label
            GlobalSystemMediaTransportControlsSession? session =
                _mediaManager?.GetCurrentSession();

            string processName = "<no source>";
            if (session != null)
            {
                if (session.SourceAppUserModelId != null)
                {
                    processName = ProcessNameHelper.GetReadableProcessName(session.SourceAppUserModelId);
                    processName = ProcessNameHelper.FormatProcessName(processName);
                }
            }
            UpdateSourceLabel(processName);
        }

        private GlobalSystemMediaTransportControlsSessionPlaybackInfo? GetPlaybackInfo()
        {
            GlobalSystemMediaTransportControlsSession? session =
                _mediaManager?.GetCurrentSession();
            if (session != null)
            {
                GlobalSystemMediaTransportControlsSessionPlaybackInfo playbackInfo = session.GetPlaybackInfo();

                return playbackInfo;
            }
            else
            {
                return null;
            }
        }

        private void UpdateTitleTextBox(string title, string artist)
        {
            if (titleTextBox.InvokeRequired)
            {
                titleTextBox.Invoke(new Action(() => UpdateTitleTextBox(title, artist)));
            }
            else
            {
                if (title == string.Empty && artist == string.Empty)
                {
                    //Call likely to be removed in the future - for now it's kept for testing purposes
                    (title, artist, _) = _bassService.GetTitleTags();
                }
                if (!string.IsNullOrEmpty(title) || !string.IsNullOrEmpty(artist))
                {
                    titleTextBox.Text = $"{title}\r\n{artist}";
                    SetTitleTextBoxMargin();
                }
                else
                {
                    titleTextBox.Text = "Unknown";
                }
            }
        }

        private async void UpdateTitleTextBox(GlobalSystemMediaTransportControlsSessionMediaProperties mediaProperties)
        {
            string title = string.Empty;
            string artist = string.Empty;
            if (mediaProperties != null)
            {
                IRandomAccessStreamReference thumbnailStreamReference = mediaProperties.Thumbnail;

                if (thumbnailStreamReference != null)
                {
                    using (IRandomAccessStreamWithContentType stream = await thumbnailStreamReference.OpenReadAsync())
                    {
                        MemoryStream memoryStream = new MemoryStream();
                        await stream.AsStreamForRead().CopyToAsync(memoryStream);
                        memoryStream.Position = 0;
                        Image thumbnailImage = Image.FromStream(memoryStream);
                        ThumbnailPictureBox.Image = thumbnailImage;
                        memoryStream.Dispose();
                    }
                }
                else
                {
                    ThumbnailPictureBox.Image = null;
                }

                title = mediaProperties.Title;
                artist = mediaProperties.Artist;
            }
            else
            {
                ThumbnailPictureBox.Image = null;
            }

            if (titleTextBox.InvokeRequired)
            {
                titleTextBox.Invoke(new Action<GlobalSystemMediaTransportControlsSessionMediaProperties>(UpdateTitleTextBox), mediaProperties);
            }
            else
            {
                titleTextBox.Text = title + "\r\n" + artist;
                SetTitleTextBoxMargin();
            }
        }

        private void SetTitleTextBoxMargin()
        {
            if (GetNumberOfLines() < 4)
            {
                titleTextBox.Text = "\r\n" + titleTextBox.Text;
            }
        }

        private int GetNumberOfLines()
        {
            int lineCount = 0;

            if (titleTextBox != null)
            {
                for (int charIndex = 0; charIndex < titleTextBox.Text.Length; charIndex++)
                {
                    int lineIndex = titleTextBox.GetLineFromCharIndex(charIndex);

                    if (lineIndex > lineCount)
                    {
                        lineCount = lineIndex;
                    }
                }

                lineCount++;
            }

            return lineCount;
        }

        private async Task InitializeMediaManager()
        {
            _mediaManager = await GlobalSystemMediaTransportControlsSessionManager.RequestAsync();
            _mediaManager.CurrentSessionChanged += SessionsChanged;
        }

        private void SessionsChanged(GlobalSystemMediaTransportControlsSessionManager sender, object args)
        {
            GlobalSystemMediaTransportControlsSession session = sender.GetCurrentSession();
            if (session != null)
            {
                session.MediaPropertiesChanged -= MediaPropertiesChanged;
                session.MediaPropertiesChanged += MediaPropertiesChanged;
            }

            MediaControlsUpdateTitleTextBox();
        }

        private void UpdateSourceLabel(string source)
        {
            if (SourceLabel.InvokeRequired)
            {
                SourceLabel.Invoke((Action)(() => UpdateSourceLabel(source)));
            }
            else
            {
                SourceLabel.Text = source;
                if (!_folded && this.WindowState != FormWindowState.Minimized)
                {
                    UpdateSourceLabelLocation();
                }
            }
        }

        private void UpdateSourceLabelLocation()
        {
            SourceLabel.Location = new Point((this.ClientSize.Width - SourceLabel.Width) / 2, SourceLabel.Location.Y);
        }

        private async Task<List<CoreAudioDevice>> GetPlaybackDevices()
        {
            if (_playbackDevices != null)
            {
                return _playbackDevices;
            }

            _playbackDevices = await Task.Run(() =>
            {
                return GetCoreAudioController().GetPlaybackDevices().ToList();
            });

            return _playbackDevices;
        }

        private CoreAudioDevice GetDefaultPlaybackDevice()
        {
            return GetCoreAudioController().DefaultPlaybackDevice;
        }

        private CoreAudioController GetCoreAudioController()
        {
            if (_coreAudioController == null)
            {
                _coreAudioController = new CoreAudioController();
            }

            return _coreAudioController;
        }

        private void MoveFormOnElementMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void UpdateRadioTitle(string artist, string title)
        {
            UpdateTitleTextBox(artist, title);
        }

        private void BringToFrontReliably()
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                ShowWindow(this.Handle, SW_RESTORE);
            }
            else
            {
                ShowWindow(this.Handle, SW_SHOW);
            }

            this.TopMost = false;
            this.TopMost = true;

            SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0,
                SWP_NOMOVE | SWP_NOSIZE | SWP_NOOWNERZORDER | SWP_SHOWWINDOW);

            Activate();
            SetForegroundWindow(this.Handle);
        }


        #endregion

        #region Event handlers

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await InitializeMediaManager();

            GlobalSystemMediaTransportControlsSession? session = _mediaManager?.GetCurrentSession();
            if (session != null)
            {
                session.MediaPropertiesChanged -= MediaPropertiesChanged;
                session.MediaPropertiesChanged += MediaPropertiesChanged;
                MediaControlsUpdateTitleTextBox();
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (!_folded && this.WindowState != FormWindowState.Minimized)
            {
                UpdateSourceLabelLocation();
            }
        }

        private async void RadioDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            await ChangeRadioIndex(RadioDropDownList.SelectedIndex);
        }

        private void PauseRadioButton_Click(object sender, EventArgs e)
        {
            StopRadio();
        }

        private void MinimizePictureBox_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ClosePictureBox_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void PrevPictureBox_Click(object sender, EventArgs e)
        {
            Send(AppCommands.MediaPrevious);

            if (_bassService.GetRadioPlaying())
            {
                StopRadio();
            }
        }

        private void PausePlayPictureBox_Click(object sender, EventArgs e)
        {
            Send(AppCommands.MediaPlayPause);

            if (_bassService.GetRadioPlaying())
            {
                StopRadio();
            }
        }

        private void NextPictureBox_Click(object sender, EventArgs e)
        {
            Send(AppCommands.MediaNext);

            if (_bassService.GetRadioPlaying())
            {
                StopRadio();
            }
        }

        private void VolumeSlider_ValueChanged(object sender, EventArgs e)
        {
            GetDefaultPlaybackDevice().Volume = VolumeSlider.Value;
            VolumeLabel.Text = VolumeSlider.Value.ToString();
            VolumeLabel.Left = ReduceVolumePictureBox.Right + ((IncreaseVolumePictureBox.Left - ReduceVolumePictureBox.Right - VolumeLabel.Width) / 2);
        }

        private void MutePictureBox_Click(object sender, EventArgs e)
        {
            Send(AppCommands.VolumeMute);
            _muted = !_muted;
            if (_muted)
            {
                MutePictureBox.Image = Properties.Resources.Mute;
            }
            else
            {
                MutePictureBox.Image = Properties.Resources.Unmute;
            }
        }

        private void ReduceVolumePictureBox_Click(object sender, EventArgs e)
        {
            VolumeSlider.Value -= 5;
        }

        private void IncreaseVolumePictureBox_Click(object sender, EventArgs e)
        {
            VolumeSlider.Value += 5;
        }

        private void OutputDeviceDropDown_DrawItem(object sender, DrawItemEventArgs e)
        {
            int index = e.Index >= 0 ? e.Index : 0;
            SolidBrush brush;
            if (_outputDeviceDropdownEnter || OutputDeviceDropDown.DroppedDown)
            {
                brush = new SolidBrush(_hoverColor);
            }
            else
            {
                brush = new SolidBrush(_controlBackgroundColor);
            }

            if (OutputDeviceDropDown.Items.Count > 0)
            {
                e.DrawBackground();
                e.Graphics.DrawString(OutputDeviceDropDown.Items[index]?.ToString(), e.Font ?? Control.DefaultFont, brush, e.Bounds, StringFormat.GenericDefault);
                e.DrawFocusRectangle();
            }
        }

        private void OutputDeviceDropDown_DropDownClosed(object sender, EventArgs e)
        {
            VolumeLabel.Focus();
            var pictureBox = (FlatComboBox)sender;
            pictureBox.BorderColor = _controlBackgroundColor;
            _outputDeviceDropdownEnter = false;
        }

        private void OutputDeviceDropDown_MouseEnter(object sender, EventArgs e)
        {
            _outputDeviceDropdownEnter = true;
            var pictureBox = (FlatComboBox)sender;
            pictureBox.BorderColor = _hoverColor;
        }

        private void OutputDeviceDropDown_MouseLeave(object sender, EventArgs e)
        {
            _outputDeviceDropdownEnter = false;
            var pictureBox = (FlatComboBox)sender;
            pictureBox.BorderColor = _controlBackgroundColor;
        }

        private async void OutputDeviceDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isOutputDeviceChangingFromSystem)
            {
                if (_bassService.GetRadioPlaying())
                {
                    //Je potreba zavolat i pokud dojde ke zmene mimo aplikaci - jinak bude radio dale hrat pres puvodni zarizeni
                    await ChangeRadioIndex(RadioDropDownList.SelectedIndex);
                }

                //Pokud byla zmena provedena mimo aplikaci tak ve funkci nepokracujeme, jinak muze dojit k zacykleni
                return;
            }

            _isOutputDeviceChangingFromApplication = true;

            try
            {
                if (_outputDeviceIndexes.Item2 == -1)
                {
                    _outputDeviceIndexes.Item2 = OutputDeviceDropDown.SelectedIndex;
                }
                else
                {
                    _outputDeviceIndexes.Item1 = _outputDeviceIndexes.Item2;
                    _outputDeviceIndexes.Item2 = OutputDeviceDropDown.SelectedIndex;
                }

                foreach (CoreAudioDevice d in await GetPlaybackDevices())
                {
                    if (d.FullName == OutputDeviceDropDown.Text)
                    {
                        d.SetAsDefault();
                        int vol = (int)d.Volume;
                        if (vol < VolumeSlider.Minimum)
                        {
                            vol = VolumeSlider.Minimum;
                        }
                        else if (vol > VolumeSlider.Maximum)
                        {
                            vol = VolumeSlider.Maximum;
                        }
                        VolumeSlider.Value = vol;
                    }
                }

                if (_bassService.GetRadioPlaying())
                {
                    await ChangeRadioIndex(RadioDropDownList.SelectedIndex);
                }
            }
            finally
            {
                _isOutputDeviceChangingFromApplication = false;
            }
        }

        private void RadioDropDownList_DrawItem(object sender, DrawItemEventArgs e)
        {
            int index = e.Index >= 0 ? e.Index : 0;
            SolidBrush brush;
            if (_radioDropdownEnter || RadioDropDownList.DroppedDown)
            {
                brush = new SolidBrush(_hoverColor);
            }
            else
            {
                brush = new SolidBrush(_controlBackgroundColor);
            }
            e.DrawBackground();
            if (RadioDropDownList.Items.Count > 0)
            {
                e.Graphics.DrawString(RadioDropDownList.Items[index]?.ToString(), e.Font ?? Control.DefaultFont, brush, e.Bounds, StringFormat.GenericDefault);
            }
            e.DrawFocusRectangle();
        }

        private void RadioDropDownList_MouseEnter(object sender, EventArgs e)
        {
            _radioDropdownEnter = true;
            var pictureBox = (FlatComboBox)sender;
            pictureBox.BorderColor = _hoverColor;
        }

        private void RadioDropDownList_MouseLeave(object sender, EventArgs e)
        {
            _radioDropdownEnter = false;
            var pictureBox = (FlatComboBox)sender;
            pictureBox.BorderColor = _controlBackgroundColor;
        }

        private void RadioDropDownList_DropDownClosed(object sender, EventArgs e)
        {
            VolumeLabel.Focus();
            var pictureBox = (FlatComboBox)sender;
            pictureBox.BorderColor = _controlBackgroundColor;
            _radioDropdownEnter = false;
        }

        private void ResumeRadioButton_Click(object sender, EventArgs e)
        {
            if (_resumeRadioIndex != -1)
            {
                if (_bassService.GetRadioPlaying() && _previousRadioIndex != -1)
                {
                    RadioDropDownList.SelectedIndex = _previousRadioIndex;
                }
                else
                {
                    RadioDropDownList.SelectedIndex = _resumeRadioIndex;
                }

                GlobalSystemMediaTransportControlsSessionPlaybackInfo? currentMediaPlaybackInfo = GetPlaybackInfo();
                if (currentMediaPlaybackInfo != null)
                {
                    if (currentMediaPlaybackInfo.PlaybackStatus == GlobalSystemMediaTransportControlsSessionPlaybackStatus.Playing)
                    {
                        Send(AppCommands.MediaPause);
                    }
                }

                UpdateTitleTextBox(string.Empty, string.Empty);
            }
        }

        private void ThumbnailPictureBox_Paint(object sender, PaintEventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            ControlPaint.DrawBorder(e.Graphics, pictureBox.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }

        private void FoldPictureBox_Click(object sender, EventArgs e)
        {
            if (!_folded)
            {
                _folded = true;
                this.Size = new Size(40, 30);
            }
            else
            {
                _folded = false;
                this.Size = new Size(260, 409);
                MediaControlsUpdateTitleTextBox();
            }
            this.Invalidate();
        }

        private void SettingsPictureBox_Click(object sender, EventArgs e)
        {
            // Check if form2 is already open
            if (_settingsForm == null || _settingsForm.IsDisposed)
            {
                _settingsForm = new SettingsForm();
                _settingsForm.FormClosed += SettingsForm_FormClosed;
                _settingsForm.Show();
            }
            else
            {
                _settingsForm.BringToFront();
            }
        }

        private async void SettingsForm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            _settingsForm = null;
            await InitializeRadioList();
        }

        private void PreviousOutputDevicePictureBox_Click(object sender, EventArgs e)
        {
            int previousOutputDeviceIndex = _outputDeviceIndexes.Item1;
            if (previousOutputDeviceIndex != -1 && previousOutputDeviceIndex < OutputDeviceDropDown.Items.Count)
            {
                OutputDeviceDropDown.SelectedIndex = previousOutputDeviceIndex;
            }
        }

        #endregion

        #region Overrides

        protected override void WndProc(ref Message message)
        {
            if (message.Msg == WM_NCLBUTTONDBLCLK)
            {
                // Ignore double click, don't move the form to top left after double click
                return;
            }

            base.WndProc(ref message);

            if (message.Msg == WM_NCHITTEST && (int)message.Result == HTCLIENT)
                message.Result = (IntPtr)HTCAPTION;//Must be after base.WndProc call   
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            BringToFrontReliably();
        }

        #endregion
    }
}
