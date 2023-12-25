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
            pictureBox1 = new PictureBox();
            volumeSlider = new TrackBarCustom();
            mutePictureBox = new PictureBox();
            reduceVolumePictureBox = new PictureBox();
            volumeLabel = new Label();
            increaseVolumePictureBox = new PictureBox();
            outputDeviceDropDown = new FlatComboBox();
            titleTextBox = new TextBox();
            radioDropDownList = new FlatComboBox();
            ((System.ComponentModel.ISupportInitialize)minimizePictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)closePictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)prevPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pausePlayPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)volumeSlider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)mutePictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)reduceVolumePictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)increaseVolumePictureBox).BeginInit();
            SuspendLayout();
            // 
            // pauseRadioButton
            // 
            pauseRadioButton.BackColor = Color.FromArgb(255, 191, 0);
            pauseRadioButton.FlatAppearance.BorderSize = 0;
            pauseRadioButton.FlatStyle = FlatStyle.Flat;
            pauseRadioButton.ForeColor = Color.FromArgb(51, 51, 51);
            pauseRadioButton.Location = new Point(82, 45);
            pauseRadioButton.Name = "pauseRadioButton";
            pauseRadioButton.Size = new Size(100, 20);
            pauseRadioButton.TabIndex = 1;
            pauseRadioButton.Text = "Stop Radio";
            pauseRadioButton.UseVisualStyleBackColor = false;
            pauseRadioButton.Click += pauseRadioButton_Click;
            pauseRadioButton.MouseEnter += ChangeBackgroundColorMouseEnter;
            pauseRadioButton.MouseLeave += ChangeBackgroundColorMouseLeave;
            // 
            // minimizePictureBox
            // 
            minimizePictureBox.BackColor = Color.FromArgb(255, 191, 0);
            minimizePictureBox.Image = Properties.Resources.Minimize;
            minimizePictureBox.Location = new Point(202, 4);
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
            closePictureBox.Location = new Point(228, 4);
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
            prevPictureBox.Location = new Point(14, 160);
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
            pausePlayPictureBox.Location = new Point(95, 160);
            pausePlayPictureBox.Name = "pausePlayPictureBox";
            pausePlayPictureBox.Size = new Size(72, 69);
            pausePlayPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pausePlayPictureBox.TabIndex = 5;
            pausePlayPictureBox.TabStop = false;
            pausePlayPictureBox.Click += pausePlayPictureBox_Click;
            pausePlayPictureBox.MouseEnter += ChangeBackgroundColorMouseEnter;
            pausePlayPictureBox.MouseLeave += ChangeBackgroundColorMouseLeave;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(255, 191, 0);
            pictureBox1.Image = Properties.Resources.NextButton;
            pictureBox1.Location = new Point(176, 160);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(72, 69);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            pictureBox1.MouseEnter += ChangeBackgroundColorMouseEnter;
            pictureBox1.MouseLeave += ChangeBackgroundColorMouseLeave;
            // 
            // volumeSlider
            // 
            volumeSlider.Location = new Point(12, 235);
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
            mutePictureBox.Image = Properties.Resources.Mute;
            mutePictureBox.Location = new Point(14, 268);
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
            reduceVolumePictureBox.Location = new Point(95, 268);
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
            volumeLabel.Location = new Point(123, 273);
            volumeLabel.Name = "volumeLabel";
            volumeLabel.Size = new Size(21, 13);
            volumeLabel.TabIndex = 10;
            volumeLabel.Text = "00";
            // 
            // increaseVolumePictureBox
            // 
            increaseVolumePictureBox.BackColor = Color.FromArgb(255, 191, 0);
            increaseVolumePictureBox.Image = Properties.Resources.IncreaseVolume;
            increaseVolumePictureBox.Location = new Point(150, 268);
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
            outputDeviceDropDown.Location = new Point(14, 306);
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
            titleTextBox.Location = new Point(14, 111);
            titleTextBox.Multiline = true;
            titleTextBox.Name = "titleTextBox";
            titleTextBox.ReadOnly = true;
            titleTextBox.Size = new Size(234, 43);
            titleTextBox.TabIndex = 13;
            titleTextBox.TextAlign = HorizontalAlignment.Center;
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(51, 51, 51);
            ClientSize = new Size(260, 344);
            Controls.Add(radioDropDownList);
            Controls.Add(titleTextBox);
            Controls.Add(outputDeviceDropDown);
            Controls.Add(increaseVolumePictureBox);
            Controls.Add(volumeLabel);
            Controls.Add(reduceVolumePictureBox);
            Controls.Add(mutePictureBox);
            Controls.Add(volumeSlider);
            Controls.Add(pictureBox1);
            Controls.Add(pausePlayPictureBox);
            Controls.Add(prevPictureBox);
            Controls.Add(closePictureBox);
            Controls.Add(minimizePictureBox);
            Controls.Add(pauseRadioButton);
            Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(260, 344);
            MinimumSize = new Size(260, 344);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            TopMost = true;
            ((System.ComponentModel.ISupportInitialize)minimizePictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)closePictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)prevPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)pausePlayPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)volumeSlider).EndInit();
            ((System.ComponentModel.ISupportInitialize)mutePictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)reduceVolumePictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)increaseVolumePictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button pauseRadioButton;
        private PictureBox minimizePictureBox;
        private PictureBox closePictureBox;
        private PictureBox prevPictureBox;
        private PictureBox pausePlayPictureBox;
        private PictureBox pictureBox1;
        private TrackBarCustom volumeSlider;
        private PictureBox mutePictureBox;
        private PictureBox reduceVolumePictureBox;
        private Label volumeLabel;
        private PictureBox increaseVolumePictureBox;
        private FlatComboBox outputDeviceDropDown;
        private TextBox titleTextBox;
        private FlatComboBox radioDropDownList;
    }
}
