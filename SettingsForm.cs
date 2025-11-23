using System.Data;
using System.Runtime.InteropServices;

namespace ContinuousAudioOverlay
{
    public partial class SettingsForm : Form
    {
        private BassService _bassService;
        private List<Radio>? _radioList;
        private Color _controlBackgroundColor = Color.FromArgb(255, 191, 0);
        private Color _hoverColor = Color.Yellow;
        private bool _radioDropDownListEnter = false;
        private const int HTCAPTION = 0x2;
        private const int WM_NCLBUTTONDOWN = 0xA1;

        public SettingsForm()
        {
            _bassService = new BassService();

            InitializeComponent();

            Shown += async (_, __) => await InitializeUi();

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
            _radioList = await _bassService.GetRadioList();
            RadioDropDownList.Items.Clear();
            RadioDropDownList.Items.AddRange(_radioList.Select(radio => radio.RadioName).ToArray());
            RadioDropDownList.SelectedIndex = -1;
        }

        private void RadioDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int currentIndex = RadioDropDownList.SelectedIndex;
            if (currentIndex == -1)
            {
                return;
            }

            if (_radioList?.ElementAtOrDefault(currentIndex) is Radio radio)
            {
                EditRadioNameTB.Text = radio.RadioName;
                EditRadioURLTB.Text = radio.RadioURL;
            }
        }

        private async void AddRadioButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(AddRadioNameTB.Text))
            {
                MessageBox.Show("Error: Unable to add radio. Please ensure that a name is entered for the radio.",
                    "Radio not added",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(AddRadioURLTB.Text))
            {
                MessageBox.Show("Error: Unable to add radio. Please ensure that a URL is entered for the radio.",
                    "Radio not added",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                string radioName = AddRadioNameTB.Text;
                Radio radio = new Radio(radioName, AddRadioURLTB.Text);
                _radioList?.Add(radio);
                await UpdateRadioList();
                MessageBox.Show($"Radio \"{radioName}\" added successfully.",
                    "Radio added",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private async void EditRadioButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(EditRadioNameTB.Text))
            {
                MessageBox.Show("Error: Unable to edit radio. Please ensure that a name is entered for the radio.",
                    "Radio not edited",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(EditRadioURLTB.Text))
            {
                MessageBox.Show("Error: Unable to edit radio. Please ensure that a URL is entered for the radio.",
                    "Radio not edited",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                string radioName = EditRadioNameTB.Text;
                int currentIndex = RadioDropDownList.SelectedIndex;
                if (_radioList?.ElementAtOrDefault(currentIndex) is Radio radio)
                {
                    radio.RadioName = EditRadioNameTB.Text;
                    radio.RadioURL = EditRadioURLTB.Text;
                }
                await UpdateRadioList();
                MessageBox.Show($"Radio \"{radioName}\" edited successfully.",
                    "Radio edited",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private async void RemoveRadioButton_Click(object sender, EventArgs e)
        {
            string radioName = EditRadioNameTB.Text;
            int currentIndex = RadioDropDownList.SelectedIndex;
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
                _radioList?.RemoveAt(currentIndex);
                await UpdateRadioList();
                MessageBox.Show($"Radio \"{radioName}\" removed successfully.",
                    "Radio removed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

        }

        private async Task UpdateRadioList()
        {
            if (_radioList != null)
            {
                _bassService.SaveRadioList(_radioList);
            }
            await InitializeRadioList();
            AddRadioNameTB.Text = string.Empty;
            AddRadioURLTB.Text = string.Empty;
            EditRadioNameTB.Text = string.Empty;
            EditRadioURLTB.Text = string.Empty;
        }

        private void RadioDropDownList_DrawItem(object sender, DrawItemEventArgs e)
        {
            int index = e.Index >= 0 ? e.Index : 0;
            SolidBrush brush;
            if (_radioDropDownListEnter || RadioDropDownList.DroppedDown)
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

        private void RadioDropDownList_DropDownClosed(object sender, EventArgs e)
        {
            SettingsLabel.Focus();
            var pictureBox = (FlatComboBox)sender;
            pictureBox.BorderColor = _controlBackgroundColor;
            _radioDropDownListEnter = false;
        }

        private void RadioDropDownList_MouseEnter(object sender, EventArgs e)
        {
            _radioDropDownListEnter = true;
            var pictureBox = (FlatComboBox)sender;
            pictureBox.BorderColor = _hoverColor;
        }

        private void RadioDropDownList_MouseLeave(object sender, EventArgs e)
        {
            _radioDropDownListEnter = false;
            var pictureBox = (FlatComboBox)sender;
            pictureBox.BorderColor = _controlBackgroundColor;
        }

        private void SettingsForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void MinimizePictureBox_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ClosePictureBox_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void SettingsForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }

        private async void TestAddRadioButton_Click(object sender, EventArgs e)
        {
            ReleaseBassResources();
            if (TestAddRadioButton.Text == "Test")
            {
                TestAddRadioButton.Text = "Stop";
                TestEditRadioButton.Text = "Test";
                await _bassService.PlayRadio(AddRadioURLTB.Text);
            }
            else
            {
                TestAddRadioButton.Text = "Test";
            }
        }

        private async void TestEditRadioButton_Click(object sender, EventArgs e)
        {
            ReleaseBassResources();
            if (TestEditRadioButton.Text == "Test")
            {
                TestEditRadioButton.Text = "Stop";
                TestAddRadioButton.Text = "Test";
                await _bassService.PlayRadio(EditRadioURLTB.Text);
            }
            else
            {
                TestEditRadioButton.Text = "Test";
            }
        }

        private void SettingsForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            ReleaseBassResources();
        }

        private void ReleaseBassResources()
        {
            if (_bassService.BassInitialized())
            {
                _bassService.ReleaseBassResources();
            }
        }
    }
}
