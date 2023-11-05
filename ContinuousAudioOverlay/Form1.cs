using AudioSwitcher.AudioApi.CoreAudio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ContinuousAudioOverlay
{
    public partial class Form1 : Form
    {
        CoreAudioDevice defaultPlaybackDevice = new CoreAudioController().DefaultPlaybackDevice;
        IEnumerable<CoreAudioDevice> devices = new CoreAudioController().GetPlaybackDevices();
        Color controlBackgroundColor = Color.FromArgb(255, 191, 0);
        Color hoverColor = Color.Yellow;
        bool dropdownEnter = false;

        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;

        ///
        /// Handling the window messages
        ///
        protected override void WndProc(ref Message message)
        {
            base.WndProc(ref message);

            if (message.Msg == WM_NCHITTEST && (int)message.Result == HTCLIENT)
                message.Result = (IntPtr)HTCAPTION;
        }

        public Form1()
        {
            InitializeComponent();
            volumeSlider.Value = (int)defaultPlaybackDevice.Volume;
            InitializeOutputDevices();
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
            // Run the message loop on another thread so we're compatible with a console mode app
            var t = new Thread(() => {
                frm = new Form();
                var dummy = frm.Handle;
                frm.BeginInvoke(new MethodInvoker(() => mre.Set()));
                Application.Run();
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

        private void radio1PictureBox_Click(object sender, EventArgs e)
        {
            radioWindowsMediaPlayer.URL = "https://icecast9.play.cz/casrock192.mp3";
        }

        private void radio2PictureBox_Click(object sender, EventArgs e)
        {
            radioWindowsMediaPlayer.URL = "http://icecast4.play.cz/kiss128.mp3";
        }

        private void ChangeBackgroundColorMouseEnter(object sender, EventArgs e)
        {
            var pictureBox = (PictureBox)sender;
            pictureBox.BackColor = hoverColor;
        }

        private void ChangeBackgroundColorMouseLeave(object sender, EventArgs e)
        {
            var pictureBox = (PictureBox)sender;
            pictureBox.BackColor = controlBackgroundColor;
        }

        private void prevPictureBox_Click(object sender, EventArgs e)
        {
            Send(AppCommands.MediaPrevious);
        }

        private void pausePlayPictureBox_Click(object sender, EventArgs e)
        {
            Send(AppCommands.MediaPlayPause);
        }

        private void nextPictureBox_Click(object sender, EventArgs e)
        {
            Send(AppCommands.MediaNext);
        }

        private void radioGroupBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics gfx = e.Graphics;
            Pen p = new Pen(controlBackgroundColor, 1);
            gfx.DrawLine(p, 0, 5, 0, e.ClipRectangle.Height - 2);
            gfx.DrawLine(p, 0, 5, 10, 5);
            gfx.DrawLine(p, 42, 5, e.ClipRectangle.Width - 2, 5);
            gfx.DrawLine(p, e.ClipRectangle.Width - 2, 5, e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 2);
            gfx.DrawLine(p, e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 2, 0, e.ClipRectangle.Height - 2);
        }

        private void outputDeviceDropDown_DrawItem(object sender, DrawItemEventArgs e)
        {
            int index = e.Index >= 0 ? e.Index : 0;
            SolidBrush brush;
            if (dropdownEnter)
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
            dropdownEnter = false;
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

        private void outputDeviceDropDown_MouseEnter(object sender, EventArgs e)
        {
            dropdownEnter = true;
            var pictureBox = (FlatComboBox)sender;
            pictureBox.BorderColor = hoverColor;
        }

        private void outputDeviceDropDown_MouseLeave(object sender, EventArgs e)
        {
            dropdownEnter = false;
            var pictureBox = (FlatComboBox)sender;
            pictureBox.BorderColor = controlBackgroundColor;
        }

        private void volumeSlider_ValueChanged()
        {
            defaultPlaybackDevice.Volume = volumeSlider.Value;
            volumeLabel.Text = volumeSlider.Value.ToString();
        }

        private void volumeSlider_MouseEnter(object sender, EventArgs e)
        {
            var trackBar = (Ce_TrackBar)sender;
            trackBar.SlideColor = hoverColor;
            trackBar.BallColor = hoverColor;
            volumeLabel.ForeColor = hoverColor;
        }

        private void volumeSlider_MouseLeave(object sender, EventArgs e)
        {
            var trackBar = (Ce_TrackBar)sender;
            trackBar.SlideColor = controlBackgroundColor;
            trackBar.BallColor = controlBackgroundColor;
            volumeLabel.ForeColor = controlBackgroundColor;
        }

        private void minimizePictureBox_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void closePictureBox_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
