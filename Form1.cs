using Un4seen.Bass;
using System.Xml.Linq;
using Windows.Media.Control;
using AudioSwitcher.AudioApi.CoreAudio;
using System.Runtime.InteropServices;
using Un4seen.Bass.AddOn.Tags;
using System.Net;
using Windows.Storage.Streams;
using System.Globalization;

namespace ContinuousAudioOverlay
{
    public partial class Form1 : Form
    {
        static int _streamHandle;
        List<Radio> radioList = new List<Radio>();

        CoreAudioDevice defaultPlaybackDevice = new CoreAudioController().DefaultPlaybackDevice;
        IEnumerable<CoreAudioDevice> devices = new CoreAudioController().GetPlaybackDevices();
        Color controlBackgroundColor = Color.FromArgb(255, 191, 0);
        Color hoverColor = Color.Yellow;
        bool outputDeviceDropdownEnter = false;
        bool radioDropdownEnter = false;
        private readonly System.Windows.Forms.Timer radioTitleUpdateTimer = new System.Windows.Forms.Timer();
        GlobalSystemMediaTransportControlsSessionManager mediaManager;
        private TAG_INFO previousTagInfo;
        bool muted = false;
        bool radioPlaying = false;
        string radioURL = string.Empty;
        int radioIndex = -1;
        bool loaded = false;
        bool folded = false;

        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;

        public Form1()
        {
            InitializeComponent();
            InitializeOutputDevices();
            InitializeXml();
            InitializeTimer();
            volumeSlider.Value = (int)defaultPlaybackDevice.Volume;
            this.TopMost = true;
            UpdateSourceLabel("<no source>");
        }

        protected override void WndProc(ref Message message)
        {
            base.WndProc(ref message);

            if (message.Msg == WM_NCHITTEST && (int)message.Result == HTCLIENT)
                message.Result = (IntPtr)HTCAPTION;
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

        // Pinvoke
        private const int WM_APPCOMMAND = 0x319;
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

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

        private void radioDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReleaseBassResources();
            if (radioDropDownList.SelectedIndex != radioDropDownList.Items.Count - 1)
            {
                if (!Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero))
                {
                    return;
                }
                radioPlaying = true;
                radioURL = radioList[radioDropDownList.SelectedIndex].RadioURL;

                _streamHandle = Bass.BASS_StreamCreateURL(radioURL, 0, BASSFlag.BASS_DEFAULT, null, IntPtr.Zero);
                if (_streamHandle != 0)
                {
                    Bass.BASS_ChannelPlay(_streamHandle, true);
                    Bass.BASS_ChannelSetAttribute(_streamHandle, BASSAttribute.BASS_ATTRIB_VOL, (float)0.1);
                }
                else
                {
                    MessageBox.Show("Radio could not be loaded.\r\nRadio URL: " + radioURL, "Error loading radio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                radioIndex = radioDropDownList.SelectedIndex;
                radioTitleUpdateTimer.Start();
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
            Bass.BASS_ChannelStop(_streamHandle);
            Bass.BASS_StreamFree(_streamHandle);
            Bass.BASS_Free();
            radioPlaying = false;
        }

        public void InitializeXml()
        {
            string xmlFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "RadioList.xml");
            XDocument doc;

            if (!File.Exists(xmlFilePath))
            {
                doc = new XDocument(
                    new XElement("Radios",
                        new XElement("Radio",
                            new XElement("RadioName", "Rádio Èas Rock"),
                            new XElement("RadioURL", "https://icecast9.play.cz/casrock192.mp3")
                        ),
                        new XElement("Radio",
                            new XElement("RadioName", "Rádio Kiss"),
                            new XElement("RadioURL", "http://icecast4.play.cz/kiss128.mp3")
                        )
                    )
                );
                doc.Save(xmlFilePath);
            }

            if (File.Exists(xmlFilePath))
            {
                doc = XDocument.Load(xmlFilePath);

                var radios = doc.Descendants("Radio")
                                .Select(radio => new Radio
                                {
                                    RadioName = radio.Element("RadioName")?.Value,
                                    RadioURL = radio.Element("RadioURL")?.Value
                                })
                                .ToList();
                radioList.AddRange(radios);
            }

            radioDropDownList.Items.AddRange(radioList.Select(radio => radio.RadioName).ToArray());
            radioDropDownList.Items.Add("<no radio>");
            radioDropDownList.SelectedIndex = radioDropDownList.Items.Count - 1;
        }

        private void pauseRadioButton_Click(object sender, EventArgs e)
        {
            StopRadio();
        }

        private void StopRadio()
        {
            MediaControlsUpdateTitleTextBox();
            radioTitleUpdateTimer.Stop();
            ReleaseBassResources();
            radioDropDownList.SelectedIndex = radioDropDownList.Items.Count - 1;
        }

        public class Radio
        {
            public string RadioName { get; set; }
            public string RadioURL { get; set; }
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
            e.DrawBackground();
            e.Graphics.DrawString(outputDeviceDropDown.Items[index].ToString(), e.Font, brush, e.Bounds, StringFormat.GenericDefault);
            e.DrawFocusRectangle();
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
            foreach (CoreAudioDevice d in devices)
            {
                if (d.FullName == outputDeviceDropDown.Text)
                {
                    d.SetAsDefault();
                    defaultPlaybackDevice = d;
                    volumeSlider.Value = (int)d.Volume;
                }
            }
        }

        public void InitializeTimer()
        {
            radioTitleUpdateTimer.Interval = 5000;
            radioTitleUpdateTimer.Tick += radioTitleUpdateTimer_Tick;
            //radioTitleUpdateTimer.Start();
        }

        private async Task<GlobalSystemMediaTransportControlsSessionMediaProperties> GetMediaInfoAsync()
        {
            GlobalSystemMediaTransportControlsSession session =
                mediaManager.GetCurrentSession();
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
                    processName = Path.GetFileNameWithoutExtension(session.SourceAppUserModelId);
                    processName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(processName);
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

        private void radioTitleUpdateTimer_Tick(object sender, EventArgs e)
        {
            if (radioPlaying)
            {
                TAG_INFO currentTagInfo = new TAG_INFO(radioURL);
                if (TagInfoPropertiesChanged(currentTagInfo, previousTagInfo))
                {
                    UpdateTitleTextBox();
                }
            }
        }

        private bool TagInfoPropertiesChanged(TAG_INFO current, TAG_INFO previous)
        {
            return current?.title != previous?.title;
        }

        private void UpdateTitleTextBox()
        {
            TAG_INFO tagInfo = new TAG_INFO(radioURL);
            if (BassTags.BASS_TAG_GetFromURL(_streamHandle, tagInfo))
            {
                if (tagInfo.title != null && tagInfo.artist != null)
                {
                    string title = WebUtility.HtmlDecode(tagInfo.title);
                    string artist = WebUtility.HtmlDecode(tagInfo.artist);
                    titleTextBox.Text = title + "\r\n" + artist;
                    SetTitleTextBoxMargin();
                }
            }
            else
            {
                titleTextBox.Text = "Unknown";
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
            if (radioIndex != -1)
            {
                radioDropDownList.SelectedIndex = radioIndex;

                GlobalSystemMediaTransportControlsSessionPlaybackInfo currentMediaPlaybackInfo = GetPlaybackInfo();
                if (currentMediaPlaybackInfo != null)
                {
                    if (currentMediaPlaybackInfo.PlaybackStatus == GlobalSystemMediaTransportControlsSessionPlaybackStatus.Playing)
                    {
                        Send(AppCommands.MediaPause);
                    }
                }

                radioTitleUpdateTimer.Start();
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            mediaManager = await GlobalSystemMediaTransportControlsSessionManager.RequestAsync();
            mediaManager.CurrentSessionChanged += SessionsChanged;

            GlobalSystemMediaTransportControlsSession session = mediaManager.GetCurrentSession();
            if (session != null)
            {
                MediaControlsUpdateTitleTextBox();
            }

            loaded = true;
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
                sourceLabel.Location = new Point((this.ClientSize.Width - sourceLabel.Width) / 2, sourceLabel.Location.Y);
            }
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
            }
        }
    }
}
