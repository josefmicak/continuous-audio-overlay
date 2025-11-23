namespace ContinuousAudioOverlay
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            RadioDropDownList = new FlatComboBox();
            EditRadioButton = new Button();
            EditRadioURLTB = new TextBox();
            EditRadioNameTB = new TextBox();
            RemoveRadioButton = new Button();
            AddRadioNameTB = new TextBox();
            AddRadioURLTB = new TextBox();
            AddRadioButton = new Button();
            SettingsLabel = new Label();
            AddRadioLabel = new Label();
            AddRadioURL = new Label();
            EditRadioName = new Label();
            EditRadioURL = new Label();
            ClosePictureBox = new PictureBox();
            MinimizePictureBox = new PictureBox();
            TestAddRadioButton = new Button();
            TestEditRadioButton = new Button();
            ((System.ComponentModel.ISupportInitialize)ClosePictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MinimizePictureBox).BeginInit();
            SuspendLayout();
            // 
            // RadioDropDownList
            // 
            RadioDropDownList.BackColor = Color.FromArgb(51, 51, 51);
            RadioDropDownList.BorderColor = Color.FromArgb(255, 191, 0);
            RadioDropDownList.ButtonColor = Color.FromArgb(51, 51, 51);
            RadioDropDownList.DrawMode = DrawMode.OwnerDrawFixed;
            RadioDropDownList.DropDownStyle = ComboBoxStyle.DropDownList;
            RadioDropDownList.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            RadioDropDownList.FormattingEnabled = true;
            RadioDropDownList.Location = new Point(9, 191);
            RadioDropDownList.Name = "RadioDropDownList";
            RadioDropDownList.Size = new Size(233, 21);
            RadioDropDownList.TabIndex = 12;
            RadioDropDownList.DrawItem += RadioDropDownList_DrawItem;
            RadioDropDownList.SelectedIndexChanged += RadioDropDownList_SelectedIndexChanged;
            RadioDropDownList.DropDownClosed += RadioDropDownList_DropDownClosed;
            RadioDropDownList.MouseEnter += RadioDropDownList_MouseEnter;
            RadioDropDownList.MouseLeave += RadioDropDownList_MouseLeave;
            RadioDropDownList.MouseHover += RadioDropDownList_MouseEnter;
            // 
            // EditRadioButton
            // 
            EditRadioButton.BackColor = Color.FromArgb(255, 191, 0);
            EditRadioButton.FlatAppearance.BorderSize = 0;
            EditRadioButton.FlatStyle = FlatStyle.Flat;
            EditRadioButton.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            EditRadioButton.ForeColor = Color.FromArgb(51, 51, 51);
            EditRadioButton.Location = new Point(9, 356);
            EditRadioButton.Name = "EditRadioButton";
            EditRadioButton.Size = new Size(110, 20);
            EditRadioButton.TabIndex = 1;
            EditRadioButton.Text = "Edit";
            EditRadioButton.UseVisualStyleBackColor = false;
            EditRadioButton.Click += EditRadioButton_Click;
            EditRadioButton.MouseEnter += ChangeBackgroundColorMouseEnter;
            EditRadioButton.MouseLeave += ChangeBackgroundColorMouseLeave;
            // 
            // EditRadioURLTB
            // 
            EditRadioURLTB.BackColor = Color.FromArgb(51, 51, 51);
            EditRadioURLTB.BorderStyle = BorderStyle.FixedSingle;
            EditRadioURLTB.ForeColor = Color.FromArgb(255, 191, 0);
            EditRadioURLTB.Location = new Point(9, 308);
            EditRadioURLTB.Name = "EditRadioURLTB";
            EditRadioURLTB.Size = new Size(233, 23);
            EditRadioURLTB.TabIndex = 2;
            // 
            // EditRadioNameTB
            // 
            EditRadioNameTB.BackColor = Color.FromArgb(51, 51, 51);
            EditRadioNameTB.BorderStyle = BorderStyle.FixedSingle;
            EditRadioNameTB.ForeColor = Color.FromArgb(255, 191, 0);
            EditRadioNameTB.Location = new Point(9, 249);
            EditRadioNameTB.Name = "EditRadioNameTB";
            EditRadioNameTB.Size = new Size(233, 23);
            EditRadioNameTB.TabIndex = 3;
            // 
            // RemoveRadioButton
            // 
            RemoveRadioButton.BackColor = Color.FromArgb(255, 191, 0);
            RemoveRadioButton.FlatAppearance.BorderSize = 0;
            RemoveRadioButton.FlatStyle = FlatStyle.Flat;
            RemoveRadioButton.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            RemoveRadioButton.ForeColor = Color.FromArgb(51, 51, 51);
            RemoveRadioButton.Location = new Point(132, 356);
            RemoveRadioButton.Name = "RemoveRadioButton";
            RemoveRadioButton.Size = new Size(110, 20);
            RemoveRadioButton.TabIndex = 4;
            RemoveRadioButton.Text = "Remove";
            RemoveRadioButton.UseVisualStyleBackColor = false;
            RemoveRadioButton.Click += RemoveRadioButton_Click;
            RemoveRadioButton.MouseEnter += ChangeBackgroundColorMouseEnter;
            RemoveRadioButton.MouseLeave += ChangeBackgroundColorMouseLeave;
            // 
            // AddRadioNameTB
            // 
            AddRadioNameTB.BackColor = Color.FromArgb(51, 51, 51);
            AddRadioNameTB.BorderStyle = BorderStyle.FixedSingle;
            AddRadioNameTB.ForeColor = Color.FromArgb(255, 191, 0);
            AddRadioNameTB.Location = new Point(9, 51);
            AddRadioNameTB.Name = "AddRadioNameTB";
            AddRadioNameTB.Size = new Size(233, 23);
            AddRadioNameTB.TabIndex = 5;
            // 
            // AddRadioURLTB
            // 
            AddRadioURLTB.BackColor = Color.FromArgb(51, 51, 51);
            AddRadioURLTB.BorderStyle = BorderStyle.FixedSingle;
            AddRadioURLTB.ForeColor = Color.FromArgb(255, 191, 0);
            AddRadioURLTB.Location = new Point(9, 106);
            AddRadioURLTB.Name = "AddRadioURLTB";
            AddRadioURLTB.Size = new Size(233, 23);
            AddRadioURLTB.TabIndex = 6;
            // 
            // AddRadioButton
            // 
            AddRadioButton.BackColor = Color.FromArgb(255, 191, 0);
            AddRadioButton.FlatAppearance.BorderSize = 0;
            AddRadioButton.FlatStyle = FlatStyle.Flat;
            AddRadioButton.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            AddRadioButton.ForeColor = Color.FromArgb(51, 51, 51);
            AddRadioButton.Location = new Point(72, 148);
            AddRadioButton.Name = "AddRadioButton";
            AddRadioButton.Size = new Size(110, 20);
            AddRadioButton.TabIndex = 7;
            AddRadioButton.Text = "Add";
            AddRadioButton.UseVisualStyleBackColor = false;
            AddRadioButton.Click += AddRadioButton_Click;
            AddRadioButton.MouseEnter += ChangeBackgroundColorMouseEnter;
            AddRadioButton.MouseLeave += ChangeBackgroundColorMouseLeave;
            // 
            // SettingsLabel
            // 
            SettingsLabel.AutoSize = true;
            SettingsLabel.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            SettingsLabel.ForeColor = Color.FromArgb(255, 191, 0);
            SettingsLabel.Location = new Point(100, 15);
            SettingsLabel.MaximumSize = new Size(100, 20);
            SettingsLabel.Name = "SettingsLabel";
            SettingsLabel.Size = new Size(53, 13);
            SettingsLabel.TabIndex = 18;
            SettingsLabel.Text = "Settings";
            // 
            // AddRadioLabel
            // 
            AddRadioLabel.AutoSize = true;
            AddRadioLabel.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            AddRadioLabel.ForeColor = Color.FromArgb(255, 191, 0);
            AddRadioLabel.Location = new Point(9, 35);
            AddRadioLabel.Name = "AddRadioLabel";
            AddRadioLabel.Size = new Size(43, 13);
            AddRadioLabel.TabIndex = 19;
            AddRadioLabel.Text = "Name:";
            // 
            // AddRadioURL
            // 
            AddRadioURL.AutoSize = true;
            AddRadioURL.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            AddRadioURL.ForeColor = Color.FromArgb(255, 191, 0);
            AddRadioURL.Location = new Point(9, 90);
            AddRadioURL.Name = "AddRadioURL";
            AddRadioURL.Size = new Size(36, 13);
            AddRadioURL.TabIndex = 20;
            AddRadioURL.Text = "URL:";
            // 
            // EditRadioName
            // 
            EditRadioName.AutoSize = true;
            EditRadioName.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            EditRadioName.ForeColor = Color.FromArgb(255, 191, 0);
            EditRadioName.Location = new Point(9, 233);
            EditRadioName.Name = "EditRadioName";
            EditRadioName.Size = new Size(43, 13);
            EditRadioName.TabIndex = 21;
            EditRadioName.Text = "Name:";
            // 
            // EditRadioURL
            // 
            EditRadioURL.AutoSize = true;
            EditRadioURL.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            EditRadioURL.ForeColor = Color.FromArgb(255, 191, 0);
            EditRadioURL.Location = new Point(9, 292);
            EditRadioURL.Name = "EditRadioURL";
            EditRadioURL.Size = new Size(36, 13);
            EditRadioURL.TabIndex = 22;
            EditRadioURL.Text = "URL:";
            // 
            // ClosePictureBox
            // 
            ClosePictureBox.BackColor = Color.FromArgb(255, 191, 0);
            ClosePictureBox.Image = Properties.Resources.Close;
            ClosePictureBox.Location = new Point(222, 8);
            ClosePictureBox.Name = "ClosePictureBox";
            ClosePictureBox.Size = new Size(20, 20);
            ClosePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            ClosePictureBox.TabIndex = 23;
            ClosePictureBox.TabStop = false;
            ClosePictureBox.Click += ClosePictureBox_Click;
            ClosePictureBox.MouseEnter += ChangeBackgroundColorMouseEnter;
            ClosePictureBox.MouseLeave += ChangeBackgroundColorMouseLeave;
            // 
            // MinimizePictureBox
            // 
            MinimizePictureBox.BackColor = Color.FromArgb(255, 191, 0);
            MinimizePictureBox.Image = Properties.Resources.Minimize;
            MinimizePictureBox.Location = new Point(196, 8);
            MinimizePictureBox.Name = "MinimizePictureBox";
            MinimizePictureBox.Size = new Size(20, 20);
            MinimizePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            MinimizePictureBox.TabIndex = 24;
            MinimizePictureBox.TabStop = false;
            MinimizePictureBox.Click += MinimizePictureBox_Click;
            MinimizePictureBox.MouseEnter += ChangeBackgroundColorMouseEnter;
            MinimizePictureBox.MouseLeave += ChangeBackgroundColorMouseLeave;
            // 
            // TestAddRadioButton
            // 
            TestAddRadioButton.BackColor = Color.FromArgb(255, 191, 0);
            TestAddRadioButton.FlatAppearance.BorderSize = 0;
            TestAddRadioButton.FlatStyle = FlatStyle.Flat;
            TestAddRadioButton.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            TestAddRadioButton.ForeColor = Color.FromArgb(51, 51, 51);
            TestAddRadioButton.Location = new Point(132, 80);
            TestAddRadioButton.Name = "TestAddRadioButton";
            TestAddRadioButton.Size = new Size(110, 20);
            TestAddRadioButton.TabIndex = 25;
            TestAddRadioButton.Text = "Test";
            TestAddRadioButton.UseVisualStyleBackColor = false;
            TestAddRadioButton.Click += TestAddRadioButton_Click;
            TestAddRadioButton.MouseEnter += ChangeBackgroundColorMouseEnter;
            TestAddRadioButton.MouseLeave += ChangeBackgroundColorMouseLeave;
            // 
            // TestEditRadioButton
            // 
            TestEditRadioButton.BackColor = Color.FromArgb(255, 191, 0);
            TestEditRadioButton.FlatAppearance.BorderSize = 0;
            TestEditRadioButton.FlatStyle = FlatStyle.Flat;
            TestEditRadioButton.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            TestEditRadioButton.ForeColor = Color.FromArgb(51, 51, 51);
            TestEditRadioButton.Location = new Point(132, 282);
            TestEditRadioButton.Name = "TestEditRadioButton";
            TestEditRadioButton.Size = new Size(110, 20);
            TestEditRadioButton.TabIndex = 26;
            TestEditRadioButton.Text = "Test";
            TestEditRadioButton.UseVisualStyleBackColor = false;
            TestEditRadioButton.Click += TestEditRadioButton_Click;
            TestEditRadioButton.MouseEnter += ChangeBackgroundColorMouseEnter;
            TestEditRadioButton.MouseLeave += ChangeBackgroundColorMouseLeave;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(51, 51, 51);
            ClientSize = new Size(255, 394);
            Controls.Add(TestEditRadioButton);
            Controls.Add(TestAddRadioButton);
            Controls.Add(MinimizePictureBox);
            Controls.Add(ClosePictureBox);
            Controls.Add(EditRadioURL);
            Controls.Add(EditRadioName);
            Controls.Add(AddRadioURL);
            Controls.Add(AddRadioLabel);
            Controls.Add(SettingsLabel);
            Controls.Add(AddRadioButton);
            Controls.Add(AddRadioURLTB);
            Controls.Add(AddRadioNameTB);
            Controls.Add(RemoveRadioButton);
            Controls.Add(EditRadioNameTB);
            Controls.Add(EditRadioURLTB);
            Controls.Add(EditRadioButton);
            Controls.Add(RadioDropDownList);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            Name = "SettingsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Settings";
            TopMost = true;
            Paint += SettingsForm_Paint;
            MouseDown += SettingsForm_MouseDown;
            ((System.ComponentModel.ISupportInitialize)ClosePictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)MinimizePictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlatComboBox RadioDropDownList;
        private Button EditRadioButton;
        private TextBox EditRadioURLTB;
        private TextBox EditRadioNameTB;
        private Button RemoveRadioButton;
        private TextBox AddRadioNameTB;
        private TextBox AddRadioURLTB;
        private Button AddRadioButton;
        private Label SettingsLabel;
        private Label AddRadioLabel;
        private Label AddRadioURL;
        private Label EditRadioName;
        private Label EditRadioURL;
        private PictureBox ClosePictureBox;
        private PictureBox MinimizePictureBox;
        private Button TestAddRadioButton;
        private Button TestEditRadioButton;
    }
}