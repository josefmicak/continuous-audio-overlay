namespace ContinuousAudioOverlay
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.volumeLabel = new System.Windows.Forms.Label();
            this.radioWindowsMediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.radioGroupBox = new System.Windows.Forms.GroupBox();
            this.radio1PictureBox = new System.Windows.Forms.PictureBox();
            this.radio2PictureBox = new System.Windows.Forms.PictureBox();
            this.volumeSlider = new Ce_TrackBar();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.outputDeviceDropDown = new ContinuousAudioOverlay.FlatComboBox();
            this.mutePictureBox = new System.Windows.Forms.PictureBox();
            this.increaseVolumePictureBox = new System.Windows.Forms.PictureBox();
            this.reduceVolumePictureBox = new System.Windows.Forms.PictureBox();
            this.closePictureBox = new System.Windows.Forms.PictureBox();
            this.minimizePictureBox = new System.Windows.Forms.PictureBox();
            this.pausePlayPictureBox = new System.Windows.Forms.PictureBox();
            this.nextPictureBox = new System.Windows.Forms.PictureBox();
            this.prevPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.radioWindowsMediaPlayer)).BeginInit();
            this.radioGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radio1PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radio2PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mutePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.increaseVolumePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reduceVolumePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.closePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimizePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pausePlayPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prevPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // volumeLabel
            // 
            this.volumeLabel.AutoSize = true;
            this.volumeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.volumeLabel.Location = new System.Drawing.Point(123, 343);
            this.volumeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.volumeLabel.Name = "volumeLabel";
            this.volumeLabel.Size = new System.Drawing.Size(21, 13);
            this.volumeLabel.TabIndex = 8;
            this.volumeLabel.Text = "00";
            // 
            // radioWindowsMediaPlayer
            // 
            this.radioWindowsMediaPlayer.Enabled = true;
            this.radioWindowsMediaPlayer.Location = new System.Drawing.Point(8, 77);
            this.radioWindowsMediaPlayer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radioWindowsMediaPlayer.Name = "radioWindowsMediaPlayer";
            this.radioWindowsMediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("radioWindowsMediaPlayer.OcxState")));
            this.radioWindowsMediaPlayer.Size = new System.Drawing.Size(233, 77);
            this.radioWindowsMediaPlayer.TabIndex = 0;
            // 
            // radioGroupBox
            // 
            this.radioGroupBox.Controls.Add(this.radioWindowsMediaPlayer);
            this.radioGroupBox.Controls.Add(this.radio1PictureBox);
            this.radioGroupBox.Controls.Add(this.radio2PictureBox);
            this.radioGroupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.radioGroupBox.Location = new System.Drawing.Point(14, 30);
            this.radioGroupBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radioGroupBox.Name = "radioGroupBox";
            this.radioGroupBox.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radioGroupBox.Size = new System.Drawing.Size(248, 160);
            this.radioGroupBox.TabIndex = 12;
            this.radioGroupBox.TabStop = false;
            this.radioGroupBox.Text = "Rádio";
            this.radioGroupBox.Paint += new System.Windows.Forms.PaintEventHandler(this.radioGroupBox_Paint);
            // 
            // radio1PictureBox
            // 
            this.radio1PictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.radio1PictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.radio1PictureBox.Image = global::ContinuousAudioOverlay.Properties.Resources.Logo_Rock_bez_pozadi;
            this.radio1PictureBox.Location = new System.Drawing.Point(65, 19);
            this.radio1PictureBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radio1PictureBox.Name = "radio1PictureBox";
            this.radio1PictureBox.Size = new System.Drawing.Size(66, 51);
            this.radio1PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.radio1PictureBox.TabIndex = 10;
            this.radio1PictureBox.TabStop = false;
            this.radio1PictureBox.Click += new System.EventHandler(this.radio1PictureBox_Click);
            this.radio1PictureBox.MouseEnter += new System.EventHandler(this.ChangeBackgroundColorMouseEnter);
            this.radio1PictureBox.MouseLeave += new System.EventHandler(this.ChangeBackgroundColorMouseLeave);
            // 
            // radio2PictureBox
            // 
            this.radio2PictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.radio2PictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.radio2PictureBox.Image = global::ContinuousAudioOverlay.Properties.Resources.Kiss_BeHappy;
            this.radio2PictureBox.Location = new System.Drawing.Point(139, 19);
            this.radio2PictureBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radio2PictureBox.Name = "radio2PictureBox";
            this.radio2PictureBox.Size = new System.Drawing.Size(66, 51);
            this.radio2PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.radio2PictureBox.TabIndex = 11;
            this.radio2PictureBox.TabStop = false;
            this.radio2PictureBox.Click += new System.EventHandler(this.radio2PictureBox_Click);
            this.radio2PictureBox.MouseEnter += new System.EventHandler(this.ChangeBackgroundColorMouseEnter);
            this.radio2PictureBox.MouseLeave += new System.EventHandler(this.ChangeBackgroundColorMouseLeave);
            // 
            // volumeSlider
            // 
            this.volumeSlider.BallColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.volumeSlider.JumpToMouse = false;
            this.volumeSlider.Location = new System.Drawing.Point(14, 315);
            this.volumeSlider.Maximum = 100;
            this.volumeSlider.Minimum = 0;
            this.volumeSlider.MinimumSize = new System.Drawing.Size(47, 22);
            this.volumeSlider.Name = "volumeSlider";
            this.volumeSlider.Size = new System.Drawing.Size(248, 22);
            this.volumeSlider.SlideColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.volumeSlider.TabIndex = 18;
            this.volumeSlider.Text = "ce_TrackBar1";
            this.volumeSlider.Value = 0;
            this.volumeSlider.ValueDivison = Ce_TrackBar.ValueDivisor.By1;
            this.volumeSlider.ValueToSet = 0F;
            this.volumeSlider.ValueChanged += new Ce_TrackBar.ValueChangedEventHandler(this.volumeSlider_ValueChanged);
            this.volumeSlider.MouseEnter += new System.EventHandler(this.volumeSlider_MouseEnter);
            this.volumeSlider.MouseLeave += new System.EventHandler(this.volumeSlider_MouseLeave);
            // 
            // titleTextBox
            // 
            this.titleTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.titleTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.titleTextBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.titleTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.titleTextBox.Location = new System.Drawing.Point(14, 196);
            this.titleTextBox.Multiline = true;
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.ReadOnly = true;
            this.titleTextBox.Size = new System.Drawing.Size(249, 43);
            this.titleTextBox.TabIndex = 22;
            this.titleTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // outputDeviceDropDown
            // 
            this.outputDeviceDropDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.outputDeviceDropDown.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.outputDeviceDropDown.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.outputDeviceDropDown.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.outputDeviceDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.outputDeviceDropDown.ForeColor = System.Drawing.SystemColors.ControlText;
            this.outputDeviceDropDown.FormattingEnabled = true;
            this.outputDeviceDropDown.Location = new System.Drawing.Point(14, 366);
            this.outputDeviceDropDown.Name = "outputDeviceDropDown";
            this.outputDeviceDropDown.Size = new System.Drawing.Size(248, 21);
            this.outputDeviceDropDown.TabIndex = 16;
            this.outputDeviceDropDown.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.outputDeviceDropDown_DrawItem);
            this.outputDeviceDropDown.SelectedIndexChanged += new System.EventHandler(this.outputDeviceDropDown_SelectedIndexChanged);
            this.outputDeviceDropDown.DropDownClosed += new System.EventHandler(this.outputDeviceDropDown_DropDownClosed);
            this.outputDeviceDropDown.MouseEnter += new System.EventHandler(this.outputDeviceDropDown_MouseEnter);
            this.outputDeviceDropDown.MouseLeave += new System.EventHandler(this.outputDeviceDropDown_MouseLeave);
            this.outputDeviceDropDown.MouseHover += new System.EventHandler(this.outputDeviceDropDown_MouseEnter);
            // 
            // mutePictureBox
            // 
            this.mutePictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.mutePictureBox.Image = global::ContinuousAudioOverlay.Properties.Resources.Unmute;
            this.mutePictureBox.Location = new System.Drawing.Point(14, 338);
            this.mutePictureBox.Name = "mutePictureBox";
            this.mutePictureBox.Size = new System.Drawing.Size(22, 20);
            this.mutePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mutePictureBox.TabIndex = 26;
            this.mutePictureBox.TabStop = false;
            this.mutePictureBox.Click += new System.EventHandler(this.mutePictureBox_Click);
            this.mutePictureBox.MouseEnter += new System.EventHandler(this.ChangeBackgroundColorMouseEnter);
            this.mutePictureBox.MouseLeave += new System.EventHandler(this.ChangeBackgroundColorMouseLeave);
            // 
            // increaseVolumePictureBox
            // 
            this.increaseVolumePictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.increaseVolumePictureBox.Image = ((System.Drawing.Image)(resources.GetObject("increaseVolumePictureBox.Image")));
            this.increaseVolumePictureBox.Location = new System.Drawing.Point(150, 338);
            this.increaseVolumePictureBox.Name = "increaseVolumePictureBox";
            this.increaseVolumePictureBox.Size = new System.Drawing.Size(22, 20);
            this.increaseVolumePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.increaseVolumePictureBox.TabIndex = 25;
            this.increaseVolumePictureBox.TabStop = false;
            this.increaseVolumePictureBox.Click += new System.EventHandler(this.increaseVolumePictureBox_Click);
            this.increaseVolumePictureBox.MouseEnter += new System.EventHandler(this.ChangeBackgroundColorMouseEnter);
            this.increaseVolumePictureBox.MouseLeave += new System.EventHandler(this.ChangeBackgroundColorMouseLeave);
            // 
            // reduceVolumePictureBox
            // 
            this.reduceVolumePictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.reduceVolumePictureBox.Image = ((System.Drawing.Image)(resources.GetObject("reduceVolumePictureBox.Image")));
            this.reduceVolumePictureBox.Location = new System.Drawing.Point(95, 338);
            this.reduceVolumePictureBox.Name = "reduceVolumePictureBox";
            this.reduceVolumePictureBox.Size = new System.Drawing.Size(22, 20);
            this.reduceVolumePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.reduceVolumePictureBox.TabIndex = 23;
            this.reduceVolumePictureBox.TabStop = false;
            this.reduceVolumePictureBox.Click += new System.EventHandler(this.reduceVolumePictureBox_Click);
            this.reduceVolumePictureBox.MouseEnter += new System.EventHandler(this.ChangeBackgroundColorMouseEnter);
            this.reduceVolumePictureBox.MouseLeave += new System.EventHandler(this.ChangeBackgroundColorMouseLeave);
            // 
            // closePictureBox
            // 
            this.closePictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.closePictureBox.Image = ((System.Drawing.Image)(resources.GetObject("closePictureBox.Image")));
            this.closePictureBox.Location = new System.Drawing.Point(242, 4);
            this.closePictureBox.Name = "closePictureBox";
            this.closePictureBox.Size = new System.Drawing.Size(20, 20);
            this.closePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.closePictureBox.TabIndex = 20;
            this.closePictureBox.TabStop = false;
            this.closePictureBox.Click += new System.EventHandler(this.closePictureBox_Click);
            this.closePictureBox.MouseEnter += new System.EventHandler(this.ChangeBackgroundColorMouseEnter);
            this.closePictureBox.MouseLeave += new System.EventHandler(this.ChangeBackgroundColorMouseLeave);
            // 
            // minimizePictureBox
            // 
            this.minimizePictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.minimizePictureBox.Image = global::ContinuousAudioOverlay.Properties.Resources.Minimize;
            this.minimizePictureBox.Location = new System.Drawing.Point(216, 4);
            this.minimizePictureBox.Name = "minimizePictureBox";
            this.minimizePictureBox.Size = new System.Drawing.Size(20, 20);
            this.minimizePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.minimizePictureBox.TabIndex = 19;
            this.minimizePictureBox.TabStop = false;
            this.minimizePictureBox.Click += new System.EventHandler(this.minimizePictureBox_Click);
            this.minimizePictureBox.MouseEnter += new System.EventHandler(this.ChangeBackgroundColorMouseEnter);
            this.minimizePictureBox.MouseLeave += new System.EventHandler(this.ChangeBackgroundColorMouseLeave);
            // 
            // pausePlayPictureBox
            // 
            this.pausePlayPictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.pausePlayPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("pausePlayPictureBox.Image")));
            this.pausePlayPictureBox.Location = new System.Drawing.Point(95, 240);
            this.pausePlayPictureBox.Name = "pausePlayPictureBox";
            this.pausePlayPictureBox.Size = new System.Drawing.Size(87, 69);
            this.pausePlayPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pausePlayPictureBox.TabIndex = 15;
            this.pausePlayPictureBox.TabStop = false;
            this.pausePlayPictureBox.Click += new System.EventHandler(this.pausePlayPictureBox_Click);
            this.pausePlayPictureBox.MouseEnter += new System.EventHandler(this.ChangeBackgroundColorMouseEnter);
            this.pausePlayPictureBox.MouseLeave += new System.EventHandler(this.ChangeBackgroundColorMouseLeave);
            // 
            // nextPictureBox
            // 
            this.nextPictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.nextPictureBox.Image = global::ContinuousAudioOverlay.Properties.Resources.NextButton;
            this.nextPictureBox.Location = new System.Drawing.Point(190, 240);
            this.nextPictureBox.Name = "nextPictureBox";
            this.nextPictureBox.Size = new System.Drawing.Size(72, 69);
            this.nextPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.nextPictureBox.TabIndex = 14;
            this.nextPictureBox.TabStop = false;
            this.nextPictureBox.Click += new System.EventHandler(this.nextPictureBox_Click);
            this.nextPictureBox.MouseEnter += new System.EventHandler(this.ChangeBackgroundColorMouseEnter);
            this.nextPictureBox.MouseLeave += new System.EventHandler(this.ChangeBackgroundColorMouseLeave);
            // 
            // prevPictureBox
            // 
            this.prevPictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.prevPictureBox.Image = global::ContinuousAudioOverlay.Properties.Resources.PrevButton;
            this.prevPictureBox.Location = new System.Drawing.Point(14, 240);
            this.prevPictureBox.Name = "prevPictureBox";
            this.prevPictureBox.Size = new System.Drawing.Size(72, 69);
            this.prevPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.prevPictureBox.TabIndex = 13;
            this.prevPictureBox.TabStop = false;
            this.prevPictureBox.Click += new System.EventHandler(this.prevPictureBox_Click);
            this.prevPictureBox.MouseEnter += new System.EventHandler(this.ChangeBackgroundColorMouseEnter);
            this.prevPictureBox.MouseLeave += new System.EventHandler(this.ChangeBackgroundColorMouseLeave);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(275, 404);
            this.Controls.Add(this.mutePictureBox);
            this.Controls.Add(this.increaseVolumePictureBox);
            this.Controls.Add(this.reduceVolumePictureBox);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.closePictureBox);
            this.Controls.Add(this.minimizePictureBox);
            this.Controls.Add(this.volumeSlider);
            this.Controls.Add(this.outputDeviceDropDown);
            this.Controls.Add(this.pausePlayPictureBox);
            this.Controls.Add(this.nextPictureBox);
            this.Controls.Add(this.prevPictureBox);
            this.Controls.Add(this.radioGroupBox);
            this.Controls.Add(this.volumeLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(275, 404);
            this.MinimumSize = new System.Drawing.Size(275, 404);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Continuous Audio Overlay";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.radioWindowsMediaPlayer)).EndInit();
            this.radioGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radio1PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radio2PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mutePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.increaseVolumePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reduceVolumePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.closePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimizePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pausePlayPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prevPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer radioWindowsMediaPlayer;
        private System.Windows.Forms.Label volumeLabel;
        private System.Windows.Forms.PictureBox radio1PictureBox;
        private System.Windows.Forms.PictureBox radio2PictureBox;
        private System.Windows.Forms.GroupBox radioGroupBox;
        private System.Windows.Forms.PictureBox prevPictureBox;
        private System.Windows.Forms.PictureBox nextPictureBox;
        private System.Windows.Forms.PictureBox pausePlayPictureBox;
        private FlatComboBox outputDeviceDropDown;
        private Ce_TrackBar volumeSlider;
        private System.Windows.Forms.PictureBox minimizePictureBox;
        private System.Windows.Forms.PictureBox closePictureBox;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.PictureBox reduceVolumePictureBox;
        private System.Windows.Forms.PictureBox increaseVolumePictureBox;
        private System.Windows.Forms.PictureBox mutePictureBox;
    }
}

