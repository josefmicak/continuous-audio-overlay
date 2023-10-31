using AudioSwitcher.AudioApi;
using AudioSwitcher.AudioApi.CoreAudio;
using NAudio.CoreAudioApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace ContinuousAudioOverlay
{
    public partial class Form1 : Form
    {
        CoreAudioDevice defaultPlaybackDevice = new CoreAudioController().DefaultPlaybackDevice;
        IEnumerable<CoreAudioDevice> devices = new CoreAudioController().GetPlaybackDevices();

        public Form1()
        {
            InitializeComponent();
            trackBar1.Value = (int)defaultPlaybackDevice.Volume;
            InitializeOutputDevices();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "https://icecast9.play.cz/casrock192.mp3";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "http://icecast4.play.cz/kiss128.mp3";
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

        private void button3_Click(object sender, EventArgs e)
        {
            Send(AppCommands.MediaPlayPause);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Send(AppCommands.MediaPrevious);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Send(AppCommands.MediaNext);
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            defaultPlaybackDevice.Volume = trackBar1.Value;
            label1.Text = trackBar1.Value.ToString();
        }

        public void InitializeOutputDevices()
        {
            foreach (CoreAudioDevice d in devices)
            {
                if(d.Name == "Speakers" || d.Name == "Headphones")
                {
                    comboBox1.Items.Add(d.FullName);
                }
                if (d.IsDefaultDevice)
                {
                    comboBox1.SelectedIndex = comboBox1.Items.Count - 1;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (CoreAudioDevice d in devices)
            {
                if (d.FullName == comboBox1.Text)
                {
                    d.SetAsDefault();
                    defaultPlaybackDevice = d;
                    trackBar1.Value = (int)d.Volume;
                } 
            }
        }
    }
}
