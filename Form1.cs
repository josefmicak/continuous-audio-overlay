using AudioSwitcher.AudioApi.CoreAudio;
using AudioSwitcher.AudioApi.Observables;
using ContinuousAudioOverlay.Helpers;
using System.Runtime.InteropServices;
using Windows.Media.Control;
using Windows.Storage.Streams;

namespace ContinuousAudioOverlay
{
    public partial class Form1 : Form
    {
        CoreAudioDevice defaultPlaybackDevice = new CoreAudioController().DefaultPlaybackDevice;
        IEnumerable<CoreAudioDevice> devices = new CoreAudioController().GetPlaybackDevices();
        Color controlBackgroundColor = Color.FromArgb(255, 191, 0);
        Color hoverColor = Color.Yellow;
        bool outputDeviceDropdownEnter = false;
        bool radioDropdownEnter = false;
        GlobalSystemMediaTransportControlsSessionManager mediaManager;
        bool muted = false;
        bool radioPlaying = false;
        int resumeRadioIndex = -1;
        int previousRadioIndex = -1;
        (int, int) outputDeviceIndexes = (-1, -1);
        bool loaded = false;
        bool folded = false;
        BassService bassService;
        SettingsForm settingsForm;

        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;
        private const int WM_NCLBUTTONDOWN = 0xA1;

        public Form1()
        {
            bassService = new BassService();

            InitializeComponent();
            InitializeOutputDevices();
            InitializeCoreAudioController();
            InitializeRadioList();
            volumeSlider.Value = (int)defaultPlaybackDevice.Volume;
            UpdateSourceLabel("<no source>");
            bassService.OnMetaDataChanged += UpdateRadioTitle;
        }

        public void InitializeRadioList()
        {
            List<Radio> radioList = bassService.GetRadioList();
            radioDropDownList.Items.Clear();
            radioDropDownList.Items.AddRange(radioList.Select(radio => radio.RadioName).ToArray());
            radioDropDownList.Items.Add("<no radio>");
            radioDropDownList.SelectedIndex = radioDropDownList.Items.Count - 1;
        }

        protected override void WndProc(ref Message message)
        {
            const int WM_NCLBUTTONDBLCLK = 0x00A3;

            if (message.Msg == WM_NCLBUTTONDBLCLK)
            {
                // Ignore double click, don't move the form to top left after double click
                return;
            }

            base.WndProc(ref message);

            if (message.Msg == WM_NCHITTEST && (int)message.Result == HTCLIENT)
                message.Result = (IntPtr)HTCAPTION;//Must be after base.WndProc call   
        }

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

        public static void Send(AppCommands cmd)
        {
            if (frm == null) Initialize();
            frm.Invoke(new MethodInvoker(() => SendMessage(frm.Handle, WM_APPCOMMAND, frm.Handle, (IntPtr)((int)cmd << 16))));
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

        private static ManualResetEvent mre = new ManualResetEvent(false);
        private static Form frm;

        private const int WM_APPCOMMAND = 0x319;
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        public void InitializeOutputDevices()
        {
            foreach (CoreAudioDevice d in devices)
            {
                if (d.Name == "Speakers" || d.Name == "Headphones")
                {
                    outputDeviceDropDown.Items.Add(d.FullName);
                }
                if (d.IsDefaultDevice)
                {
                    outputDeviceDropDown.SelectedIndex = outputDeviceDropDown.Items.Count - 1;
                }
            }
        }

        private void InitializeCoreAudioController()
        {
            CoreAudioController controller = new CoreAudioController();
            controller
                .AudioDeviceChanged
                .Subscribe(x =>
                {
                    outputDeviceDropDown.Invoke(new Action(() =>
                    {
                        int index = outputDeviceDropDown.Items.IndexOf(x.Device.FullName);
                        if (index != -1)
                            outputDeviceDropDown.SelectedIndex = index;
                    }));
                });
        }

        private void radioDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeRadioIndex(radioDropDownList.SelectedIndex);
        }

        private void ChangeRadioIndex(int radioIndex)
        {
            if (bassService.BassInitialized())
            {
                ReleaseBassResources();
            }

            if (radioIndex != radioDropDownList.Items.Count - 1)
            {
                bassService.IndexChanged(radioIndex);
                radioPlaying = true;
                if (radioIndex != resumeRadioIndex)//Remember previous station in case radio is stopped
                {
                    previousRadioIndex = resumeRadioIndex;
                }
                resumeRadioIndex = radioIndex;
                thumbnailPictureBox.Image = null;
                UpdateSourceLabel("Radio");
            }

            if (loaded)
            {
                GlobalSystemMediaTransportControlsSessionPlaybackInfo currentMediaPlaybackInfo = GetPlaybackInfo();
                if (currentMediaPlaybackInfo != null)
                {
                    if (currentMediaPlaybackInfo.PlaybackStatus == GlobalSystemMediaTransportControlsSessionPlaybackStatus.Playing)
                    {
                        Send(AppCommands.MediaPause);
                    }
                }
            }
        }

        public void ReleaseBassResources()
        {
            bassService.ReleaseBassResources();
            radioPlaying = false;
        }

        private void pauseRadioButton_Click(object sender, EventArgs e)
        {
            StopRadio();
        }

        private void StopRadio()
        {
            radioPlaying = false;
            MediaControlsUpdateTitleTextBox();
            ReleaseBassResources();
            radioDropDownList.SelectedIndex = radioDropDownList.Items.Count - 1;
        }

        private void minimizePictureBox_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void closePictureBox_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void ChangeBackgroundColorMouseEnter(object sender, EventArgs e)
        {
            try
            {
                var pictureBox = (PictureBox)sender;
                pictureBox.BackColor = hoverColor;
            }
            catch
            {
                var pictureBox = (Button)sender;
                pictureBox.BackColor = hoverColor;
            }
        }

        private void ChangeBackgroundColorMouseLeave(object sender, EventArgs e)
        {
            try
            {
                var pictureBox = (PictureBox)sender;
                pictureBox.BackColor = controlBackgroundColor;
            }
            catch
            {
                var pictureBox = (Button)sender;
                pictureBox.BackColor = controlBackgroundColor;
            }
        }

        private void prevPictureBox_Click(object sender, EventArgs e)
        {
            Send(AppCommands.MediaPrevious);

            if (radioPlaying)
            {
                StopRadio();
            }
        }

        private void pausePlayPictureBox_Click(object sender, EventArgs e)
        {
            Send(AppCommands.MediaPlayPause);

            if (radioPlaying)
            {
                StopRadio();
            }
        }

        private void nextPictureBox_Click(object sender, EventArgs e)
        {
            Send(AppCommands.MediaNext);

            if (radioPlaying)
            {
                StopRadio();
            }
        }

        private void volumeSlider_ValueChanged(object sender, EventArgs e)
        {
            defaultPlaybackDevice.Volume = volumeSlider.Value;
            volumeLabel.Text = volumeSlider.Value.ToString();
            volumeLabel.Left = reduceVolumePictureBox.Right + ((increaseVolumePictureBox.Left - reduceVolumePictureBox.Right - volumeLabel.Width) / 2);
        }

        private void mutePictureBox_Click(object sender, EventArgs e)
        {
            Send(AppCommands.VolumeMute);
            muted = !muted;
            if (muted)
            {
                mutePictureBox.Image = Properties.Resources.Mute;
            }
            else
            {
                mutePictureBox.Image = Properties.Resources.Unmute;
            }
        }

        private void reduceVolumePictureBox_Click(object sender, EventArgs e)
        {
            volumeSlider.Value -= 5;
        }

        private void increaseVolumePictureBox_Click(object sender, EventArgs e)
        {
            volumeSlider.Value += 5;
        }

        private void outputDeviceDropDown_DrawItem(object sender, DrawItemEventArgs e)
        {
            int index = e.Index >= 0 ? e.Index : 0;
            SolidBrush brush;
            if (outputDeviceDropdownEnter || outputDeviceDropDown.DroppedDown)
            {
                brush = new SolidBrush(hoverColor);
            }
            else
            {
                brush = new SolidBrush(controlBackgroundColor);
            }

            if (outputDeviceDropDown.Items.Count > 0)
            {
                e.DrawBackground();
                e.Graphics.DrawString(outputDeviceDropDown.Items[index].ToString(), e.Font, brush, e.Bounds, StringFormat.GenericDefault);
                e.DrawFocusRectangle();
            }
        }

        private void outputDeviceDropDown_DropDownClosed(object sender, EventArgs e)
        {
            volumeLabel.Focus();
            var pictureBox = (FlatComboBox)sender;
            pictureBox.BorderColor = controlBackgroundColor;
            outputDeviceDropdownEnter = false;
        }

        private void outputDeviceDropDown_MouseEnter(object sender, EventArgs e)
        {
            outputDeviceDropdownEnter = true;
            var pictureBox = (FlatComboBox)sender;
            pictureBox.BorderColor = hoverColor;
        }

        private void outputDeviceDropDown_MouseLeave(object sender, EventArgs e)
        {
            outputDeviceDropdownEnter = false;
            var pictureBox = (FlatComboBox)sender;
            pictureBox.BorderColor = controlBackgroundColor;
        }

        private void outputDeviceDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (outputDeviceIndexes.Item2 == -1)
            {
                outputDeviceIndexes.Item2 = outputDeviceDropDown.SelectedIndex;
            }
            else
            {
                outputDeviceIndexes.Item1 = outputDeviceIndexes.Item2;
                outputDeviceIndexes.Item2 = outputDeviceDropDown.SelectedIndex;
            }

            foreach (CoreAudioDevice d in devices)
            {
                if (d.FullName == outputDeviceDropDown.Text)
                {
                    d.SetAsDefault();
                    defaultPlaybackDevice = d;
                    volumeSlider.Value = (int)d.Volume;
                }
            }

            if (radioPlaying)
            {
                ChangeRadioIndex(radioDropDownList.SelectedIndex);
            }
        }

        private async Task<GlobalSystemMediaTransportControlsSessionMediaProperties> GetMediaInfoAsync()
        {
            if (mediaManager == null)
            {
                await InitializeMediaManager();
            }
            GlobalSystemMediaTransportControlsSession session =
                mediaManager!.GetCurrentSession();
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

        private async void MediaControlsUpdateTitleTextBox()
        {
            if (radioPlaying)
            {
                //We don't want to update media properties in case radio is currently playing
                return;
            }
            //Update media title and thumbnail
            GlobalSystemMediaTransportControlsSessionMediaProperties currentMediaProperties =
                await GetMediaInfoAsync();

            UpdateTitleTextBox(currentMediaProperties);

            //Update source label
            GlobalSystemMediaTransportControlsSession session =
                mediaManager.GetCurrentSession();

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

        private GlobalSystemMediaTransportControlsSessionPlaybackInfo GetPlaybackInfo()
        {
            GlobalSystemMediaTransportControlsSession session =
                mediaManager.GetCurrentSession();
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
                    (title, artist, _) = bassService.GetTitleTags();
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
                        thumbnailPictureBox.Image = thumbnailImage;
                        memoryStream.Dispose();
                    }
                }
                else
                {
                    thumbnailPictureBox.Image = null;
                }

                title = mediaProperties.Title;
                artist = mediaProperties.Artist;
            }
            else
            {
                thumbnailPictureBox.Image = null;
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

        private void radioDropDownList_DrawItem(object sender, DrawItemEventArgs e)
        {
            int index = e.Index >= 0 ? e.Index : 0;
            SolidBrush brush;
            if (radioDropdownEnter || radioDropDownList.DroppedDown)
            {
                brush = new SolidBrush(hoverColor);
            }
            else
            {
                brush = new SolidBrush(controlBackgroundColor);
            }
            e.DrawBackground();
            e.Graphics.DrawString(radioDropDownList.Items[index].ToString(), e.Font, brush, e.Bounds, StringFormat.GenericDefault);
            e.DrawFocusRectangle();
        }

        private void radioDropDownList_MouseEnter(object sender, EventArgs e)
        {
            radioDropdownEnter = true;
            var pictureBox = (FlatComboBox)sender;
            pictureBox.BorderColor = hoverColor;
        }

        private void radioDropDownList_MouseLeave(object sender, EventArgs e)
        {
            radioDropdownEnter = false;
            var pictureBox = (FlatComboBox)sender;
            pictureBox.BorderColor = controlBackgroundColor;
        }

        private void radioDropDownList_DropDownClosed(object sender, EventArgs e)
        {
            volumeLabel.Focus();
            var pictureBox = (FlatComboBox)sender;
            pictureBox.BorderColor = controlBackgroundColor;
            radioDropdownEnter = false;
        }

        private void resumeRadioButton_Click(object sender, EventArgs e)
        {
            if (resumeRadioIndex != -1)
            {
                if (radioPlaying && previousRadioIndex != -1)
                {
                    radioDropDownList.SelectedIndex = previousRadioIndex;
                }
                else
                {
                    radioDropDownList.SelectedIndex = resumeRadioIndex;
                }

                GlobalSystemMediaTransportControlsSessionPlaybackInfo currentMediaPlaybackInfo = GetPlaybackInfo();
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

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await InitializeMediaManager();

            GlobalSystemMediaTransportControlsSession session = mediaManager.GetCurrentSession();
            if (session != null)
            {
                session.MediaPropertiesChanged -= MediaPropertiesChanged;
                session.MediaPropertiesChanged += MediaPropertiesChanged;
                MediaControlsUpdateTitleTextBox();
            }

            loaded = true;
        }

        private async Task InitializeMediaManager()
        {
            mediaManager = await GlobalSystemMediaTransportControlsSessionManager.RequestAsync();
            mediaManager.CurrentSessionChanged += SessionsChanged;
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

        private void thumbnailPictureBox_Paint(object sender, PaintEventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            ControlPaint.DrawBorder(e.Graphics, pictureBox.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }

        private void UpdateSourceLabel(string source)
        {
            if (sourceLabel.InvokeRequired)
            {
                sourceLabel.Invoke((Action)(() => UpdateSourceLabel(source)));
            }
            else
            {
                sourceLabel.Text = source;
                if (!folded && this.WindowState != FormWindowState.Minimized)
                {
                    UpdateSourceLabelLocation();
                }
            }
        }

        private void UpdateSourceLabelLocation()
        {
            sourceLabel.Location = new Point((this.ClientSize.Width - sourceLabel.Width) / 2, sourceLabel.Location.Y);
        }

        private void foldPictureBox_Click(object sender, EventArgs e)
        {
            if (!folded)
            {
                folded = true;
                this.Size = new Size(40, 30);
            }
            else
            {
                folded = false;
                this.Size = new Size(260, 409);
                MediaControlsUpdateTitleTextBox();
            }
            this.Invalidate();
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

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            BringToFrontReliably();
        }

        public void BringToFrontReliably()
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

        //Probably not needed, kept for future tests:
        //protected override void OnActivated(EventArgs e)
        //{
        //    base.OnActivated(e);
        //    SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0,
        //        SWP_NOMOVE | SWP_NOSIZE | SWP_NOOWNERZORDER | SWP_SHOWWINDOW);
        //}

        [DllImport("user32.dll")]
        static extern bool SetWindowPos(
         IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll")] static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")] static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);

        const uint SWP_NOSIZE = 0x0001;
        const uint SWP_NOMOVE = 0x0002;
        const uint SWP_NOOWNERZORDER = 0x0200;
        const uint SWP_SHOWWINDOW = 0x0040;

        const int SW_RESTORE = 9;
        const int SW_SHOW = 5;

        private void settingsPictureBox_Click(object sender, EventArgs e)
        {
            // Check if form2 is already open
            if (settingsForm == null || settingsForm.IsDisposed)
            {
                settingsForm = new SettingsForm();
                settingsForm.FormClosed += SettingsForm_FormClosed;
                settingsForm.Show();
            }
            else
            {
                settingsForm.BringToFront();
            }
        }

        private void SettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            settingsForm = null;
            InitializeRadioList();
        }

        private void previousOutputDevicePictureBox_Click(object sender, EventArgs e)
        {
            int previousOutputDeviceIndex = outputDeviceIndexes.Item1;
            if (previousOutputDeviceIndex != -1 && previousOutputDeviceIndex < outputDeviceDropDown.Items.Count)
            {
                outputDeviceDropDown.SelectedIndex = previousOutputDeviceIndex;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (!folded && this.WindowState != FormWindowState.Minimized)
            {
                UpdateSourceLabelLocation();
            }
        }
    }
}
