namespace ContinuousAudioOverlay
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            PauseRadioButton = new Button();
            MinimizePictureBox = new PictureBox();
            ClosePictureBox = new PictureBox();
            PrevPictureBox = new PictureBox();
            PausePlayPictureBox = new PictureBox();
            NextPictureBox = new PictureBox();
            VolumeSlider = new TrackBarCustom();
            MutePictureBox = new PictureBox();
            ReduceVolumePictureBox = new PictureBox();
            VolumeLabel = new Label();
            IncreaseVolumePictureBox = new PictureBox();
            OutputDeviceDropDown = new FlatComboBox();
            titleTextBox = new TextBox();
            RadioDropDownList = new FlatComboBox();
            ResumeRadioButton = new Button();
            ThumbnailPictureBox = new PictureBox();
            SourceLabel = new Label();
            FoldPictureBox = new PictureBox();
            SettingsPictureBox = new PictureBox();
            PreviousOutputDevicePictureBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)MinimizePictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ClosePictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PrevPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PausePlayPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NextPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)VolumeSlider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MutePictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ReduceVolumePictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)IncreaseVolumePictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ThumbnailPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)FoldPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SettingsPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PreviousOutputDevicePictureBox).BeginInit();
            SuspendLayout();
            // 
            // PauseRadioButton
            // 
            PauseRadioButton.BackColor = Color.FromArgb(255, 191, 0);
            PauseRadioButton.FlatAppearance.BorderSize = 0;
            PauseRadioButton.FlatStyle = FlatStyle.Flat;
            PauseRadioButton.ForeColor = Color.FromArgb(51, 51, 51);
            PauseRadioButton.Location = new Point(15, 45);
            PauseRadioButton.Name = "PauseRadioButton";
            PauseRadioButton.Size = new Size(110, 20);
            PauseRadioButton.TabIndex = 1;
            PauseRadioButton.Text = "Stop R";
            PauseRadioButton.UseVisualStyleBackColor = false;
            PauseRadioButton.Click += PauseRadioButton_Click;
            PauseRadioButton.MouseEnter += ChangeBackgroundColorMouseEnter;
            PauseRadioButton.MouseLeave += ChangeBackgroundColorMouseLeave;
            // 
            // MinimizePictureBox
            // 
            MinimizePictureBox.BackColor = Color.FromArgb(255, 191, 0);
            MinimizePictureBox.Image = Properties.Resources.Minimize;
            MinimizePictureBox.Location = new Point(202, 8);
            MinimizePictureBox.Name = "MinimizePictureBox";
            MinimizePictureBox.Size = new Size(20, 20);
            MinimizePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            MinimizePictureBox.TabIndex = 2;
            MinimizePictureBox.TabStop = false;
            MinimizePictureBox.Click += MinimizePictureBox_Click;
            MinimizePictureBox.MouseEnter += ChangeBackgroundColorMouseEnter;
            MinimizePictureBox.MouseLeave += ChangeBackgroundColorMouseLeave;
            // 
            // ClosePictureBox
            // 
            ClosePictureBox.BackColor = Color.FromArgb(255, 191, 0);
            ClosePictureBox.Image = Properties.Resources.Close;
            ClosePictureBox.Location = new Point(228, 8);
            ClosePictureBox.Name = "ClosePictureBox";
            ClosePictureBox.Size = new Size(20, 20);
            ClosePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            ClosePictureBox.TabIndex = 3;
            ClosePictureBox.TabStop = false;
            ClosePictureBox.Click += ClosePictureBox_Click;
            ClosePictureBox.MouseEnter += ChangeBackgroundColorMouseEnter;
            ClosePictureBox.MouseLeave += ChangeBackgroundColorMouseLeave;
            // 
            // PrevPictureBox
            // 
            PrevPictureBox.BackColor = Color.FromArgb(255, 191, 0);
            PrevPictureBox.Image = Properties.Resources.PrevButton;
            PrevPictureBox.Location = new Point(14, 225);
            PrevPictureBox.Name = "PrevPictureBox";
            PrevPictureBox.Size = new Size(72, 69);
            PrevPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            PrevPictureBox.TabIndex = 4;
            PrevPictureBox.TabStop = false;
            PrevPictureBox.Click += PrevPictureBox_Click;
            PrevPictureBox.MouseEnter += ChangeBackgroundColorMouseEnter;
            PrevPictureBox.MouseLeave += ChangeBackgroundColorMouseLeave;
            // 
            // PausePlayPictureBox
            // 
            PausePlayPictureBox.BackColor = Color.FromArgb(255, 191, 0);
            PausePlayPictureBox.Image = Properties.Resources.PausePlayButton;
            PausePlayPictureBox.Location = new Point(95, 225);
            PausePlayPictureBox.Name = "PausePlayPictureBox";
            PausePlayPictureBox.Size = new Size(72, 69);
            PausePlayPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            PausePlayPictureBox.TabIndex = 5;
            PausePlayPictureBox.TabStop = false;
            PausePlayPictureBox.Click += PausePlayPictureBox_Click;
            PausePlayPictureBox.MouseEnter += ChangeBackgroundColorMouseEnter;
            PausePlayPictureBox.MouseLeave += ChangeBackgroundColorMouseLeave;
            // 
            // NextPictureBox
            // 
            NextPictureBox.BackColor = Color.FromArgb(255, 191, 0);
            NextPictureBox.Image = Properties.Resources.NextButton;
            NextPictureBox.Location = new Point(176, 225);
            NextPictureBox.Name = "NextPictureBox";
            NextPictureBox.Size = new Size(72, 69);
            NextPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            NextPictureBox.TabIndex = 6;
            NextPictureBox.TabStop = false;
            NextPictureBox.Click += NextPictureBox_Click;
            NextPictureBox.MouseEnter += ChangeBackgroundColorMouseEnter;
            NextPictureBox.MouseLeave += ChangeBackgroundColorMouseLeave;
            // 
            // VolumeSlider
            // 
            VolumeSlider.Location = new Point(12, 300);
            VolumeSlider.Maximum = 100;
            VolumeSlider.Name = "VolumeSlider";
            VolumeSlider.Size = new Size(236, 45);
            VolumeSlider.TabIndex = 7;
            VolumeSlider.TickStyle = TickStyle.None;
            VolumeSlider.ValueChanged += VolumeSlider_ValueChanged;
            // 
            // MutePictureBox
            // 
            MutePictureBox.BackColor = Color.FromArgb(255, 191, 0);
            MutePictureBox.Image = Properties.Resources.Unmute;
            MutePictureBox.Location = new Point(14, 333);
            MutePictureBox.Name = "MutePictureBox";
            MutePictureBox.Size = new Size(22, 20);
            MutePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            MutePictureBox.TabIndex = 8;
            MutePictureBox.TabStop = false;
            MutePictureBox.Click += MutePictureBox_Click;
            MutePictureBox.MouseEnter += ChangeBackgroundColorMouseEnter;
            MutePictureBox.MouseLeave += ChangeBackgroundColorMouseLeave;
            // 
            // ReduceVolumePictureBox
            // 
            ReduceVolumePictureBox.BackColor = Color.FromArgb(255, 191, 0);
            ReduceVolumePictureBox.Image = Properties.Resources.ReduceVolume;
            ReduceVolumePictureBox.Location = new Point(95, 333);
            ReduceVolumePictureBox.Name = "ReduceVolumePictureBox";
            ReduceVolumePictureBox.Size = new Size(22, 20);
            ReduceVolumePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            ReduceVolumePictureBox.TabIndex = 9;
            ReduceVolumePictureBox.TabStop = false;
            ReduceVolumePictureBox.Click += ReduceVolumePictureBox_Click;
            ReduceVolumePictureBox.MouseEnter += ChangeBackgroundColorMouseEnter;
            ReduceVolumePictureBox.MouseLeave += ChangeBackgroundColorMouseLeave;
            // 
            // VolumeLabel
            // 
            VolumeLabel.AutoSize = true;
            VolumeLabel.ForeColor = Color.FromArgb(255, 191, 0);
            VolumeLabel.Location = new Point(123, 338);
            VolumeLabel.Name = "VolumeLabel";
            VolumeLabel.Size = new Size(21, 13);
            VolumeLabel.TabIndex = 10;
            VolumeLabel.Text = "00";
            // 
            // IncreaseVolumePictureBox
            // 
            IncreaseVolumePictureBox.BackColor = Color.FromArgb(255, 191, 0);
            IncreaseVolumePictureBox.Image = Properties.Resources.IncreaseVolume;
            IncreaseVolumePictureBox.Location = new Point(150, 333);
            IncreaseVolumePictureBox.Name = "IncreaseVolumePictureBox";
            IncreaseVolumePictureBox.Size = new Size(22, 20);
            IncreaseVolumePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            IncreaseVolumePictureBox.TabIndex = 11;
            IncreaseVolumePictureBox.TabStop = false;
            IncreaseVolumePictureBox.Click += IncreaseVolumePictureBox_Click;
            IncreaseVolumePictureBox.MouseEnter += ChangeBackgroundColorMouseEnter;
            IncreaseVolumePictureBox.MouseLeave += ChangeBackgroundColorMouseLeave;
            // 
            // OutputDeviceDropDown
            // 
            OutputDeviceDropDown.BackColor = Color.FromArgb(51, 51, 51);
            OutputDeviceDropDown.BorderColor = Color.FromArgb(255, 191, 0);
            OutputDeviceDropDown.ButtonColor = Color.FromArgb(51, 51, 51);
            OutputDeviceDropDown.DrawMode = DrawMode.OwnerDrawFixed;
            OutputDeviceDropDown.DropDownStyle = ComboBoxStyle.DropDownList;
            OutputDeviceDropDown.FormattingEnabled = true;
            OutputDeviceDropDown.Location = new Point(14, 371);
            OutputDeviceDropDown.Name = "OutputDeviceDropDown";
            OutputDeviceDropDown.Size = new Size(207, 21);
            OutputDeviceDropDown.TabIndex = 12;
            OutputDeviceDropDown.DrawItem += OutputDeviceDropDown_DrawItem;
            OutputDeviceDropDown.SelectedIndexChanged += OutputDeviceDropDown_SelectedIndexChanged;
            OutputDeviceDropDown.DropDownClosed += OutputDeviceDropDown_DropDownClosed;
            OutputDeviceDropDown.MouseEnter += OutputDeviceDropDown_MouseEnter;
            OutputDeviceDropDown.MouseLeave += OutputDeviceDropDown_MouseLeave;
            OutputDeviceDropDown.MouseHover += OutputDeviceDropDown_MouseEnter;
            // 
            // titleTextBox
            // 
            titleTextBox.BackColor = Color.FromArgb(51, 51, 51);
            titleTextBox.BorderStyle = BorderStyle.None;
            titleTextBox.ForeColor = Color.FromArgb(255, 191, 0);
            titleTextBox.Location = new Point(15, 163);
            titleTextBox.Multiline = true;
            titleTextBox.Name = "titleTextBox";
            titleTextBox.ReadOnly = true;
            titleTextBox.Size = new Size(234, 56);
            titleTextBox.TabIndex = 13;
            titleTextBox.TextAlign = HorizontalAlignment.Center;
            titleTextBox.MouseDown += MoveFormOnElementMouseDown;
            // 
            // RadioDropDownList
            // 
            RadioDropDownList.BackColor = Color.FromArgb(51, 51, 51);
            RadioDropDownList.BorderColor = Color.FromArgb(255, 191, 0);
            RadioDropDownList.ButtonColor = Color.FromArgb(51, 51, 51);
            RadioDropDownList.DrawMode = DrawMode.OwnerDrawFixed;
            RadioDropDownList.DropDownStyle = ComboBoxStyle.DropDownList;
            RadioDropDownList.FormattingEnabled = true;
            RadioDropDownList.Location = new Point(15, 71);
            RadioDropDownList.Name = "RadioDropDownList";
            RadioDropDownList.Size = new Size(233, 21);
            RadioDropDownList.TabIndex = 14;
            RadioDropDownList.DrawItem += RadioDropDownList_DrawItem;
            RadioDropDownList.SelectedIndexChanged += RadioDropDownList_SelectedIndexChanged;
            RadioDropDownList.DropDownClosed += RadioDropDownList_DropDownClosed;
            RadioDropDownList.MouseEnter += RadioDropDownList_MouseEnter;
            RadioDropDownList.MouseLeave += RadioDropDownList_MouseLeave;
            RadioDropDownList.MouseHover += RadioDropDownList_MouseEnter;
            // 
            // ResumeRadioButton
            // 
            ResumeRadioButton.BackColor = Color.FromArgb(255, 191, 0);
            ResumeRadioButton.FlatAppearance.BorderSize = 0;
            ResumeRadioButton.FlatStyle = FlatStyle.Flat;
            ResumeRadioButton.ForeColor = Color.FromArgb(51, 51, 51);
            ResumeRadioButton.Location = new Point(137, 45);
            ResumeRadioButton.Name = "ResumeRadioButton";
            ResumeRadioButton.Size = new Size(110, 20);
            ResumeRadioButton.TabIndex = 15;
            ResumeRadioButton.Text = "Prev/Resume R";
            ResumeRadioButton.UseVisualStyleBackColor = false;
            ResumeRadioButton.Click += ResumeRadioButton_Click;
            ResumeRadioButton.MouseEnter += ChangeBackgroundColorMouseEnter;
            ResumeRadioButton.MouseLeave += ChangeBackgroundColorMouseLeave;
            // 
            // ThumbnailPictureBox
            // 
            ThumbnailPictureBox.Location = new Point(80, 102);
            ThumbnailPictureBox.Name = "ThumbnailPictureBox";
            ThumbnailPictureBox.Size = new Size(100, 55);
            ThumbnailPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            ThumbnailPictureBox.TabIndex = 16;
            ThumbnailPictureBox.TabStop = false;
            ThumbnailPictureBox.Paint += ThumbnailPictureBox_Paint;
            ThumbnailPictureBox.MouseDown += MoveFormOnElementMouseDown;
            // 
            // SourceLabel
            // 
            SourceLabel.AutoSize = true;
            SourceLabel.ForeColor = Color.FromArgb(255, 191, 0);
            SourceLabel.Location = new Point(103, 15);
            SourceLabel.MaximumSize = new Size(100, 20);
            SourceLabel.Name = "SourceLabel";
            SourceLabel.Size = new Size(78, 13);
            SourceLabel.TabIndex = 17;
            SourceLabel.Text = "SourceLabel";
            SourceLabel.MouseDown += MoveFormOnElementMouseDown;
            // 
            // FoldPictureBox
            // 
            FoldPictureBox.BackColor = Color.FromArgb(255, 191, 0);
            FoldPictureBox.Image = (Image)resources.GetObject("FoldPictureBox.Image");
            FoldPictureBox.Location = new Point(16, 8);
            FoldPictureBox.Name = "FoldPictureBox";
            FoldPictureBox.Size = new Size(20, 20);
            FoldPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            FoldPictureBox.TabIndex = 18;
            FoldPictureBox.TabStop = false;
            FoldPictureBox.Click += FoldPictureBox_Click;
            FoldPictureBox.MouseEnter += ChangeBackgroundColorMouseEnter;
            FoldPictureBox.MouseLeave += ChangeBackgroundColorMouseLeave;
            // 
            // SettingsPictureBox
            // 
            SettingsPictureBox.BackColor = Color.FromArgb(255, 191, 0);
            SettingsPictureBox.Image = Properties.Resources.Settings;
            SettingsPictureBox.Location = new Point(42, 8);
            SettingsPictureBox.Name = "SettingsPictureBox";
            SettingsPictureBox.Size = new Size(20, 20);
            SettingsPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            SettingsPictureBox.TabIndex = 19;
            SettingsPictureBox.TabStop = false;
            SettingsPictureBox.Click += SettingsPictureBox_Click;
            SettingsPictureBox.MouseEnter += ChangeBackgroundColorMouseEnter;
            SettingsPictureBox.MouseLeave += ChangeBackgroundColorMouseLeave;
            // 
            // PreviousOutputDevicePictureBox
            // 
            PreviousOutputDevicePictureBox.BackColor = Color.FromArgb(255, 191, 0);
            PreviousOutputDevicePictureBox.Image = (Image)resources.GetObject("PreviousOutputDevicePictureBox.Image");
            PreviousOutputDevicePictureBox.Location = new Point(227, 371);
            PreviousOutputDevicePictureBox.Name = "PreviousOutputDevicePictureBox";
            PreviousOutputDevicePictureBox.Size = new Size(20, 20);
            PreviousOutputDevicePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            PreviousOutputDevicePictureBox.TabIndex = 20;
            PreviousOutputDevicePictureBox.TabStop = false;
            PreviousOutputDevicePictureBox.Click += PreviousOutputDevicePictureBox_Click;
            PreviousOutputDevicePictureBox.MouseEnter += ChangeBackgroundColorMouseEnter;
            PreviousOutputDevicePictureBox.MouseLeave += ChangeBackgroundColorMouseLeave;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(51, 51, 51);
            ClientSize = new Size(260, 409);
            Controls.Add(PreviousOutputDevicePictureBox);
            Controls.Add(SettingsPictureBox);
            Controls.Add(FoldPictureBox);
            Controls.Add(SourceLabel);
            Controls.Add(ThumbnailPictureBox);
            Controls.Add(ResumeRadioButton);
            Controls.Add(RadioDropDownList);
            Controls.Add(titleTextBox);
            Controls.Add(OutputDeviceDropDown);
            Controls.Add(IncreaseVolumePictureBox);
            Controls.Add(VolumeLabel);
            Controls.Add(ReduceVolumePictureBox);
            Controls.Add(MutePictureBox);
            Controls.Add(VolumeSlider);
            Controls.Add(NextPictureBox);
            Controls.Add(PausePlayPictureBox);
            Controls.Add(PrevPictureBox);
            Controls.Add(ClosePictureBox);
            Controls.Add(MinimizePictureBox);
            Controls.Add(PauseRadioButton);
            Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(260, 409);
            MinimumSize = new Size(40, 30);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ContinuousAudioOverlay";
            TopMost = true;
            Load += Form1_Load;
            Paint += Form1_Paint;
            Resize += Form1_Resize;
            ((System.ComponentModel.ISupportInitialize)MinimizePictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)ClosePictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)PrevPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)PausePlayPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)NextPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)VolumeSlider).EndInit();
            ((System.ComponentModel.ISupportInitialize)MutePictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)ReduceVolumePictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)IncreaseVolumePictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)ThumbnailPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)FoldPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)SettingsPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)PreviousOutputDevicePictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button PauseRadioButton;
        private PictureBox MinimizePictureBox;
        private PictureBox ClosePictureBox;
        private PictureBox PrevPictureBox;
        private PictureBox PausePlayPictureBox;
        private PictureBox NextPictureBox;
        private TrackBarCustom VolumeSlider;
        private PictureBox MutePictureBox;
        private PictureBox ReduceVolumePictureBox;
        private Label VolumeLabel;
        private PictureBox IncreaseVolumePictureBox;
        private FlatComboBox OutputDeviceDropDown;
        private TextBox titleTextBox;
        private FlatComboBox RadioDropDownList;
        private Button ResumeRadioButton;
        private PictureBox ThumbnailPictureBox;
        private Label SourceLabel;
        private PictureBox FoldPictureBox;
        private PictureBox SettingsPictureBox;
        private PictureBox PreviousOutputDevicePictureBox;
    }
}
