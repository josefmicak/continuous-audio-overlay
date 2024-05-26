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
            pauseRadioButton = new Button();
            minimizePictureBox = new PictureBox();
            closePictureBox = new PictureBox();
            prevPictureBox = new PictureBox();
            pausePlayPictureBox = new PictureBox();
            nextPictureBox = new PictureBox();
            volumeSlider = new TrackBarCustom();
            mutePictureBox = new PictureBox();
            reduceVolumePictureBox = new PictureBox();
            volumeLabel = new Label();
            increaseVolumePictureBox = new PictureBox();
            outputDeviceDropDown = new FlatComboBox();
            titleTextBox = new TextBox();
            radioDropDownList = new FlatComboBox();
            resumeRadioButton = new Button();
            thumbnailPictureBox = new PictureBox();
            sourceLabel = new Label();
            foldPictureBox = new PictureBox();
            settingsPictureBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)minimizePictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)closePictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)prevPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pausePlayPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nextPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)volumeSlider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)mutePictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)reduceVolumePictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)increaseVolumePictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)thumbnailPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)foldPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)settingsPictureBox).BeginInit();
            SuspendLayout();
            // 
            // pauseRadioButton
            // 
            pauseRadioButton.BackColor = Color.FromArgb(255, 191, 0);
            pauseRadioButton.FlatAppearance.BorderSize = 0;
            pauseRadioButton.FlatStyle = FlatStyle.Flat;
            pauseRadioButton.ForeColor = Color.FromArgb(51, 51, 51);
            pauseRadioButton.Location = new Point(15, 45);
            pauseRadioButton.Name = "pauseRadioButton";
            pauseRadioButton.Size = new Size(110, 20);
            pauseRadioButton.TabIndex = 1;
            pauseRadioButton.Text = "Stop R";
            pauseRadioButton.UseVisualStyleBackColor = false;
            pauseRadioButton.Click += pauseRadioButton_Click;
            pauseRadioButton.MouseEnter += ChangeBackgroundColorMouseEnter;
            pauseRadioButton.MouseLeave += ChangeBackgroundColorMouseLeave;
            // 
            // minimizePictureBox
            // 
            minimizePictureBox.BackColor = Color.FromArgb(255, 191, 0);
            minimizePictureBox.Image = Properties.Resources.Minimize;
            minimizePictureBox.Location = new Point(202, 8);
            minimizePictureBox.Name = "minimizePictureBox";
            minimizePictureBox.Size = new Size(20, 20);
            minimizePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            minimizePictureBox.TabIndex = 2;
            minimizePictureBox.TabStop = false;
            minimizePictureBox.Click += minimizePictureBox_Click;
            minimizePictureBox.MouseEnter += ChangeBackgroundColorMouseEnter;
            minimizePictureBox.MouseLeave += ChangeBackgroundColorMouseLeave;
            // 
            // closePictureBox
            // 
            closePictureBox.BackColor = Color.FromArgb(255, 191, 0);
            closePictureBox.Image = Properties.Resources.Close;
            closePictureBox.Location = new Point(228, 8);
            closePictureBox.Name = "closePictureBox";
            closePictureBox.Size = new Size(20, 20);
            closePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            closePictureBox.TabIndex = 3;
            closePictureBox.TabStop = false;
            closePictureBox.Click += closePictureBox_Click;
            closePictureBox.MouseEnter += ChangeBackgroundColorMouseEnter;
            closePictureBox.MouseLeave += ChangeBackgroundColorMouseLeave;
            // 
            // prevPictureBox
            // 
            prevPictureBox.BackColor = Color.FromArgb(255, 191, 0);
            prevPictureBox.Image = Properties.Resources.PrevButton;
            prevPictureBox.Location = new Point(14, 225);
            prevPictureBox.Name = "prevPictureBox";
            prevPictureBox.Size = new Size(72, 69);
            prevPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            prevPictureBox.TabIndex = 4;
            prevPictureBox.TabStop = false;
            prevPictureBox.Click += prevPictureBox_Click;
            prevPictureBox.MouseEnter += ChangeBackgroundColorMouseEnter;
            prevPictureBox.MouseLeave += ChangeBackgroundColorMouseLeave;
            // 
            // pausePlayPictureBox
            // 
            pausePlayPictureBox.BackColor = Color.FromArgb(255, 191, 0);
            pausePlayPictureBox.Image = Properties.Resources.PausePlayButton;
            pausePlayPictureBox.Location = new Point(95, 225);
            pausePlayPictureBox.Name = "pausePlayPictureBox";
            pausePlayPictureBox.Size = new Size(72, 69);
            pausePlayPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pausePlayPictureBox.TabIndex = 5;
            pausePlayPictureBox.TabStop = false;
            pausePlayPictureBox.Click += pausePlayPictureBox_Click;
            pausePlayPictureBox.MouseEnter += ChangeBackgroundColorMouseEnter;
            pausePlayPictureBox.MouseLeave += ChangeBackgroundColorMouseLeave;
            // 
            // nextPictureBox
            // 
            nextPictureBox.BackColor = Color.FromArgb(255, 191, 0);
            nextPictureBox.Image = Properties.Resources.NextButton;
            nextPictureBox.Location = new Point(176, 225);
            nextPictureBox.Name = "nextPictureBox";
            nextPictureBox.Size = new Size(72, 69);
            nextPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            nextPictureBox.TabIndex = 6;
            nextPictureBox.TabStop = false;
            nextPictureBox.Click += nextPictureBox_Click;
            nextPictureBox.MouseEnter += ChangeBackgroundColorMouseEnter;
            nextPictureBox.MouseLeave += ChangeBackgroundColorMouseLeave;
            // 
            // volumeSlider
            // 
            volumeSlider.Location = new Point(12, 300);
            volumeSlider.Maximum = 100;
            volumeSlider.Name = "volumeSlider";
            volumeSlider.Size = new Size(236, 45);
            volumeSlider.TabIndex = 7;
            volumeSlider.TickStyle = TickStyle.None;
            volumeSlider.ValueChanged += volumeSlider_ValueChanged;
            // 
            // mutePictureBox
            // 
            mutePictureBox.BackColor = Color.FromArgb(255, 191, 0);
            mutePictureBox.Image = Properties.Resources.Unmute;
            mutePictureBox.Location = new Point(14, 333);
            mutePictureBox.Name = "mutePictureBox";
            mutePictureBox.Size = new Size(22, 20);
            mutePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            mutePictureBox.TabIndex = 8;
            mutePictureBox.TabStop = false;
            mutePictureBox.Click += mutePictureBox_Click;
            mutePictureBox.MouseEnter += ChangeBackgroundColorMouseEnter;
            mutePictureBox.MouseLeave += ChangeBackgroundColorMouseLeave;
            // 
            // reduceVolumePictureBox
            // 
            reduceVolumePictureBox.BackColor = Color.FromArgb(255, 191, 0);
            reduceVolumePictureBox.Image = Properties.Resources.ReduceVolume;
            reduceVolumePictureBox.Location = new Point(95, 333);
            reduceVolumePictureBox.Name = "reduceVolumePictureBox";
            reduceVolumePictureBox.Size = new Size(22, 20);
            reduceVolumePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            reduceVolumePictureBox.TabIndex = 9;
            reduceVolumePictureBox.TabStop = false;
            reduceVolumePictureBox.Click += reduceVolumePictureBox_Click;
            reduceVolumePictureBox.MouseEnter += ChangeBackgroundColorMouseEnter;
            reduceVolumePictureBox.MouseLeave += ChangeBackgroundColorMouseLeave;
            // 
            // volumeLabel
            // 
            volumeLabel.AutoSize = true;
            volumeLabel.ForeColor = Color.FromArgb(255, 191, 0);
            volumeLabel.Location = new Point(123, 338);
            volumeLabel.Name = "volumeLabel";
            volumeLabel.Size = new Size(21, 13);
            volumeLabel.TabIndex = 10;
            volumeLabel.Text = "00";
            // 
            // increaseVolumePictureBox
            // 
            increaseVolumePictureBox.BackColor = Color.FromArgb(255, 191, 0);
            increaseVolumePictureBox.Image = Properties.Resources.IncreaseVolume;
            increaseVolumePictureBox.Location = new Point(150, 333);
            increaseVolumePictureBox.Name = "increaseVolumePictureBox";
            increaseVolumePictureBox.Size = new Size(22, 20);
            increaseVolumePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            increaseVolumePictureBox.TabIndex = 11;
            increaseVolumePictureBox.TabStop = false;
            increaseVolumePictureBox.Click += increaseVolumePictureBox_Click;
            increaseVolumePictureBox.MouseEnter += ChangeBackgroundColorMouseEnter;
            increaseVolumePictureBox.MouseLeave += ChangeBackgroundColorMouseLeave;
            // 
            // outputDeviceDropDown
            // 
            outputDeviceDropDown.BackColor = Color.FromArgb(51, 51, 51);
            outputDeviceDropDown.BorderColor = Color.FromArgb(255, 191, 0);
            outputDeviceDropDown.ButtonColor = Color.FromArgb(51, 51, 51);
            outputDeviceDropDown.DrawMode = DrawMode.OwnerDrawFixed;
            outputDeviceDropDown.DropDownStyle = ComboBoxStyle.DropDownList;
            outputDeviceDropDown.FormattingEnabled = true;
            outputDeviceDropDown.Location = new Point(14, 371);
            outputDeviceDropDown.Name = "outputDeviceDropDown";
            outputDeviceDropDown.Size = new Size(233, 21);
            outputDeviceDropDown.TabIndex = 12;
            outputDeviceDropDown.DrawItem += outputDeviceDropDown_DrawItem;
            outputDeviceDropDown.SelectedIndexChanged += outputDeviceDropDown_SelectedIndexChanged;
            outputDeviceDropDown.DropDownClosed += outputDeviceDropDown_DropDownClosed;
            outputDeviceDropDown.MouseEnter += outputDeviceDropDown_MouseEnter;
            outputDeviceDropDown.MouseLeave += outputDeviceDropDown_MouseLeave;
            outputDeviceDropDown.MouseHover += outputDeviceDropDown_MouseEnter;
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
            // radioDropDownList
            // 
            radioDropDownList.BackColor = Color.FromArgb(51, 51, 51);
            radioDropDownList.BorderColor = Color.FromArgb(255, 191, 0);
            radioDropDownList.ButtonColor = Color.FromArgb(51, 51, 51);
            radioDropDownList.DrawMode = DrawMode.OwnerDrawFixed;
            radioDropDownList.DropDownStyle = ComboBoxStyle.DropDownList;
            radioDropDownList.FormattingEnabled = true;
            radioDropDownList.Location = new Point(15, 71);
            radioDropDownList.Name = "radioDropDownList";
            radioDropDownList.Size = new Size(233, 21);
            radioDropDownList.TabIndex = 14;
            radioDropDownList.DrawItem += radioDropDownList_DrawItem;
            radioDropDownList.SelectedIndexChanged += radioDropDownList_SelectedIndexChanged;
            radioDropDownList.DropDownClosed += radioDropDownList_DropDownClosed;
            radioDropDownList.MouseEnter += radioDropDownList_MouseEnter;
            radioDropDownList.MouseLeave += radioDropDownList_MouseLeave;
            radioDropDownList.MouseHover += radioDropDownList_MouseEnter;
            // 
            // resumeRadioButton
            // 
            resumeRadioButton.BackColor = Color.FromArgb(255, 191, 0);
            resumeRadioButton.FlatAppearance.BorderSize = 0;
            resumeRadioButton.FlatStyle = FlatStyle.Flat;
            resumeRadioButton.ForeColor = Color.FromArgb(51, 51, 51);
            resumeRadioButton.Location = new Point(137, 45);
            resumeRadioButton.Name = "resumeRadioButton";
            resumeRadioButton.Size = new Size(110, 20);
            resumeRadioButton.TabIndex = 15;
            resumeRadioButton.Text = "Prev/Resume R";
            resumeRadioButton.UseVisualStyleBackColor = false;
            resumeRadioButton.Click += resumeRadioButton_Click;
            resumeRadioButton.MouseEnter += ChangeBackgroundColorMouseEnter;
            resumeRadioButton.MouseLeave += ChangeBackgroundColorMouseLeave;
            // 
            // thumbnailPictureBox
            // 
            thumbnailPictureBox.Location = new Point(80, 102);
            thumbnailPictureBox.Name = "thumbnailPictureBox";
            thumbnailPictureBox.Size = new Size(100, 55);
            thumbnailPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            thumbnailPictureBox.TabIndex = 16;
            thumbnailPictureBox.TabStop = false;
            thumbnailPictureBox.Paint += thumbnailPictureBox_Paint;
            thumbnailPictureBox.MouseDown += MoveFormOnElementMouseDown;
            // 
            // sourceLabel
            // 
            sourceLabel.AutoSize = true;
            sourceLabel.ForeColor = Color.FromArgb(255, 191, 0);
            sourceLabel.Location = new Point(103, 15);
            sourceLabel.MaximumSize = new Size(100, 20);
            sourceLabel.Name = "sourceLabel";
            sourceLabel.Size = new Size(78, 13);
            sourceLabel.TabIndex = 17;
            sourceLabel.Text = "SourceLabel";
            sourceLabel.MouseDown += MoveFormOnElementMouseDown;
            // 
            // foldPictureBox
            // 
            foldPictureBox.BackColor = Color.FromArgb(255, 191, 0);
            foldPictureBox.Image = (Image)resources.GetObject("foldPictureBox.Image");
            foldPictureBox.Location = new Point(16, 8);
            foldPictureBox.Name = "foldPictureBox";
            foldPictureBox.Size = new Size(20, 20);
            foldPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            foldPictureBox.TabIndex = 18;
            foldPictureBox.TabStop = false;
            foldPictureBox.Click += foldPictureBox_Click;
            foldPictureBox.MouseEnter += ChangeBackgroundColorMouseEnter;
            foldPictureBox.MouseLeave += ChangeBackgroundColorMouseLeave;
            // 
            // settingsPictureBox
            // 
            settingsPictureBox.BackColor = Color.FromArgb(255, 191, 0);
            settingsPictureBox.Image = Properties.Resources.Settings;
            settingsPictureBox.Location = new Point(42, 8);
            settingsPictureBox.Name = "settingsPictureBox";
            settingsPictureBox.Size = new Size(20, 20);
            settingsPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            settingsPictureBox.TabIndex = 19;
            settingsPictureBox.TabStop = false;
            settingsPictureBox.Click += settingsPictureBox_Click;
            settingsPictureBox.MouseEnter += ChangeBackgroundColorMouseEnter;
            settingsPictureBox.MouseLeave += ChangeBackgroundColorMouseLeave;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(51, 51, 51);
            ClientSize = new Size(260, 409);
            Controls.Add(settingsPictureBox);
            Controls.Add(foldPictureBox);
            Controls.Add(sourceLabel);
            Controls.Add(thumbnailPictureBox);
            Controls.Add(resumeRadioButton);
            Controls.Add(radioDropDownList);
            Controls.Add(titleTextBox);
            Controls.Add(outputDeviceDropDown);
            Controls.Add(increaseVolumePictureBox);
            Controls.Add(volumeLabel);
            Controls.Add(reduceVolumePictureBox);
            Controls.Add(mutePictureBox);
            Controls.Add(volumeSlider);
            Controls.Add(nextPictureBox);
            Controls.Add(pausePlayPictureBox);
            Controls.Add(prevPictureBox);
            Controls.Add(closePictureBox);
            Controls.Add(minimizePictureBox);
            Controls.Add(pauseRadioButton);
            Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
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
            ((System.ComponentModel.ISupportInitialize)minimizePictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)closePictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)prevPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)pausePlayPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)nextPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)volumeSlider).EndInit();
            ((System.ComponentModel.ISupportInitialize)mutePictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)reduceVolumePictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)increaseVolumePictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)thumbnailPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)foldPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)settingsPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button pauseRadioButton;
        private PictureBox minimizePictureBox;
        private PictureBox closePictureBox;
        private PictureBox prevPictureBox;
        private PictureBox pausePlayPictureBox;
        private PictureBox nextPictureBox;
        private TrackBarCustom volumeSlider;
        private PictureBox mutePictureBox;
        private PictureBox reduceVolumePictureBox;
        private Label volumeLabel;
        private PictureBox increaseVolumePictureBox;
        private FlatComboBox outputDeviceDropDown;
        private TextBox titleTextBox;
        private FlatComboBox radioDropDownList;
        private Button resumeRadioButton;
        private PictureBox thumbnailPictureBox;
        private Label sourceLabel;
        private PictureBox foldPictureBox;
        private PictureBox settingsPictureBox;
    }
}
