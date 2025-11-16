using System.Data;
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace ContinuousAudioOverlay
{
    public partial class SettingsForm : Form
    {
        BassService bassService;
        bool initComplete = false;
        List<Radio> radioList;
        Color controlBackgroundColor = Color.FromArgb(255, 191, 0);
        Color hoverColor = Color.Yellow;
        bool radioDropDownListEnter = false;
        private const int HTCAPTION = 0x2;
        private const int WM_NCLBUTTONDOWN = 0xA1;

        public SettingsForm()
        {
            bassService = new BassService();

            InitializeComponent();

            Shown += async (_, __) => await InitializeUi();

            initComplete = true;
            this.FormClosing += new FormClosingEventHandler(SettingsForm_FormClosing);
        }

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        private async Task InitializeUi()
        {
            await InitializeRadioList();
        }

        public async Task InitializeRadioList()
        {
            radioList = await bassService.GetRadioList();
            radioDropDownList.Items.Clear();
            radioDropDownList.Items.AddRange(radioList.Select(radio => radio.RadioName).ToArray());
            radioDropDownList.SelectedIndex = -1;
        }

        private void radioDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int currentIndex = radioDropDownList.SelectedIndex;
            if (currentIndex == -1)
            {
                return;
            }

            editRadioNameTB.Text = radioList[currentIndex].RadioName;
            editRadioURLTB.Text = radioList[currentIndex].RadioURL;
        }

        private async void addRadioButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(addRadioNameTB.Text))
            {
                MessageBox.Show("Error: Unable to add radio. Please ensure that a name is entered for the radio.",
                    "Radio not added",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(addRadioURLTB.Text))
            {
                MessageBox.Show("Error: Unable to add radio. Please ensure that a URL is entered for the radio.",
                    "Radio not added",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                string radioName = addRadioNameTB.Text;
                Radio radio = new Radio();
                radio.RadioName = addRadioNameTB.Text;
                radio.RadioURL = addRadioURLTB.Text;
                radioList.Add(radio);
                await updateRadioList();
                MessageBox.Show($"Radio \"{radioName}\" added successfully.",
                    "Radio added",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private async void editRadioButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(editRadioNameTB.Text))
            {
                MessageBox.Show("Error: Unable to edit radio. Please ensure that a name is entered for the radio.",
                    "Radio not edited",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(editRadioURLTB.Text))
            {
                MessageBox.Show("Error: Unable to edit radio. Please ensure that a URL is entered for the radio.",
                    "Radio not edited",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                string radioName = editRadioNameTB.Text;
                int currentIndex = radioDropDownList.SelectedIndex;
                radioList[currentIndex].RadioName = editRadioNameTB.Text;
                radioList[currentIndex].RadioURL = editRadioURLTB.Text;
                await updateRadioList();
                MessageBox.Show($"Radio \"{radioName}\" edited successfully.",
                    "Radio edited",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private async void removeRadioButton_Click(object sender, EventArgs e)
        {
            string radioName = editRadioNameTB.Text;
            int currentIndex = radioDropDownList.SelectedIndex;
            if (currentIndex == -1)
            {
                MessageBox.Show("Error: Unable to remove radio. No radio selected.",
                    "Radio not removed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            DialogResult result = MessageBox.Show($"Are you sure you want to remove radio \"{radioName}\" from the list?",
                "Remove Radio",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                radioList.RemoveAt(currentIndex);
                await updateRadioList();
                MessageBox.Show($"Radio \"{radioName}\" removed successfully.",
                    "Radio removed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

        }

        private async Task updateRadioList()
        {
            bassService.SaveRadioList(radioList);
            await InitializeRadioList();
            addRadioNameTB.Text = string.Empty;
            addRadioURLTB.Text = string.Empty;
            editRadioNameTB.Text = string.Empty;
            editRadioURLTB.Text = string.Empty;
        }

        private void radioDropDownList_DrawItem(object sender, DrawItemEventArgs e)
        {
            int index = e.Index >= 0 ? e.Index : 0;
            SolidBrush brush;
            if (radioDropDownListEnter || radioDropDownList.DroppedDown)
            {
                brush = new SolidBrush(hoverColor);
            }
            else
            {
                brush = new SolidBrush(controlBackgroundColor);
            }
            e.DrawBackground();
            if (radioDropDownList.Items.Count > 0)
            {
                e.Graphics.DrawString(radioDropDownList.Items[index]?.ToString(), e.Font, brush, e.Bounds, StringFormat.GenericDefault);
            }
            e.DrawFocusRectangle();
        }

        private void radioDropDownList_DropDownClosed(object sender, EventArgs e)
        {
            settingsLabel.Focus();
            var pictureBox = (FlatComboBox)sender;
            pictureBox.BorderColor = controlBackgroundColor;
            radioDropDownListEnter = false;
        }

        private void radioDropDownList_MouseEnter(object sender, EventArgs e)
        {
            radioDropDownListEnter = true;
            var pictureBox = (FlatComboBox)sender;
            pictureBox.BorderColor = hoverColor;
        }

        private void radioDropDownList_MouseLeave(object sender, EventArgs e)
        {
            radioDropDownListEnter = false;
            var pictureBox = (FlatComboBox)sender;
            pictureBox.BorderColor = controlBackgroundColor;
        }

        private void SettingsForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void minimizePictureBox_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void closePictureBox_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void SettingsForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }

        private async void testAddRadioButton_Click(object sender, EventArgs e)
        {
            ReleaseBassResources();
            if (testAddRadioButton.Text == "Test")
            {
                testAddRadioButton.Text = "Stop";
                testEditRadioButton.Text = "Test";
                await bassService.PlayRadio(addRadioURLTB.Text);
            }
            else
            {
                testAddRadioButton.Text = "Test";
            }
        }

        private async void testEditRadioButton_Click(object sender, EventArgs e)
        {
            ReleaseBassResources();
            if (testEditRadioButton.Text == "Test")
            {
                testEditRadioButton.Text = "Stop";
                testAddRadioButton.Text = "Test";
                await bassService.PlayRadio(editRadioURLTB.Text);
            }
            else
            {
                testEditRadioButton.Text = "Test";
            }
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ReleaseBassResources();
        }

        private void ReleaseBassResources()
        {
            if (bassService.BassInitialized())
            {
                bassService.ReleaseBassResources();
            }
        }
    }
}
