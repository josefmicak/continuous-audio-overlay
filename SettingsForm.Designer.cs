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
            radioDropDownList = new FlatComboBox();
            editRadioButton = new Button();
            editRadioURLTB = new TextBox();
            editRadioNameTB = new TextBox();
            removeRadioButton = new Button();
            addRadioNameTB = new TextBox();
            addRadioURLTB = new TextBox();
            addRadioButton = new Button();
            settingsLabel = new Label();
            addRadioLabel = new Label();
            addRadioURL = new Label();
            editRadioName = new Label();
            editRadioURL = new Label();
            closePictureBox = new PictureBox();
            minimizePictureBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)closePictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)minimizePictureBox).BeginInit();
            SuspendLayout();
            // 
            // radioDropDownList
            // 
            radioDropDownList.BackColor = Color.FromArgb(51, 51, 51);
            radioDropDownList.BorderColor = Color.FromArgb(255, 191, 0);
            radioDropDownList.ButtonColor = Color.FromArgb(51, 51, 51);
            radioDropDownList.DrawMode = DrawMode.OwnerDrawFixed;
            radioDropDownList.DropDownStyle = ComboBoxStyle.DropDownList;
            radioDropDownList.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            radioDropDownList.FormattingEnabled = true;
            radioDropDownList.Location = new Point(9, 191);
            radioDropDownList.Name = "radioDropDownList";
            radioDropDownList.Size = new Size(233, 21);
            radioDropDownList.TabIndex = 12;
            radioDropDownList.DrawItem += radioDropDownList_DrawItem;
            radioDropDownList.SelectedIndexChanged += radioDropDownList_SelectedIndexChanged;
            radioDropDownList.DropDownClosed += radioDropDownList_DropDownClosed;
            radioDropDownList.MouseEnter += radioDropDownList_MouseEnter;
            radioDropDownList.MouseLeave += radioDropDownList_MouseLeave;
            radioDropDownList.MouseHover += radioDropDownList_MouseEnter;
            // 
            // editRadioButton
            // 
            editRadioButton.BackColor = Color.FromArgb(255, 191, 0);
            editRadioButton.FlatAppearance.BorderSize = 0;
            editRadioButton.FlatStyle = FlatStyle.Flat;
            editRadioButton.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            editRadioButton.ForeColor = Color.FromArgb(51, 51, 51);
            editRadioButton.Location = new Point(9, 356);
            editRadioButton.Name = "editRadioButton";
            editRadioButton.Size = new Size(110, 20);
            editRadioButton.TabIndex = 1;
            editRadioButton.Text = "Edit";
            editRadioButton.UseVisualStyleBackColor = false;
            editRadioButton.Click += editRadioButton_Click;
            editRadioButton.MouseEnter += ChangeBackgroundColorMouseEnter;
            editRadioButton.MouseLeave += ChangeBackgroundColorMouseLeave;
            // 
            // editRadioURLTB
            // 
            editRadioURLTB.BackColor = Color.FromArgb(51, 51, 51);
            editRadioURLTB.BorderStyle = BorderStyle.FixedSingle;
            editRadioURLTB.ForeColor = Color.FromArgb(255, 191, 0);
            editRadioURLTB.Location = new Point(9, 308);
            editRadioURLTB.Name = "editRadioURLTB";
            editRadioURLTB.Size = new Size(233, 23);
            editRadioURLTB.TabIndex = 2;
            // 
            // editRadioNameTB
            // 
            editRadioNameTB.BackColor = Color.FromArgb(51, 51, 51);
            editRadioNameTB.BorderStyle = BorderStyle.FixedSingle;
            editRadioNameTB.ForeColor = Color.FromArgb(255, 191, 0);
            editRadioNameTB.Location = new Point(9, 249);
            editRadioNameTB.Name = "editRadioNameTB";
            editRadioNameTB.Size = new Size(233, 23);
            editRadioNameTB.TabIndex = 3;
            // 
            // removeRadioButton
            // 
            removeRadioButton.BackColor = Color.FromArgb(255, 191, 0);
            removeRadioButton.FlatAppearance.BorderSize = 0;
            removeRadioButton.FlatStyle = FlatStyle.Flat;
            removeRadioButton.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            removeRadioButton.ForeColor = Color.FromArgb(51, 51, 51);
            removeRadioButton.Location = new Point(132, 356);
            removeRadioButton.Name = "removeRadioButton";
            removeRadioButton.Size = new Size(110, 20);
            removeRadioButton.TabIndex = 4;
            removeRadioButton.Text = "Remove";
            removeRadioButton.UseVisualStyleBackColor = false;
            removeRadioButton.Click += removeRadioButton_Click;
            removeRadioButton.MouseEnter += ChangeBackgroundColorMouseEnter;
            removeRadioButton.MouseLeave += ChangeBackgroundColorMouseLeave;
            // 
            // addRadioNameTB
            // 
            addRadioNameTB.BackColor = Color.FromArgb(51, 51, 51);
            addRadioNameTB.BorderStyle = BorderStyle.FixedSingle;
            addRadioNameTB.ForeColor = Color.FromArgb(255, 191, 0);
            addRadioNameTB.Location = new Point(9, 51);
            addRadioNameTB.Name = "addRadioNameTB";
            addRadioNameTB.Size = new Size(233, 23);
            addRadioNameTB.TabIndex = 5;
            // 
            // addRadioURLTB
            // 
            addRadioURLTB.BackColor = Color.FromArgb(51, 51, 51);
            addRadioURLTB.BorderStyle = BorderStyle.FixedSingle;
            addRadioURLTB.ForeColor = Color.FromArgb(255, 191, 0);
            addRadioURLTB.Location = new Point(9, 106);
            addRadioURLTB.Name = "addRadioURLTB";
            addRadioURLTB.Size = new Size(233, 23);
            addRadioURLTB.TabIndex = 6;
            // 
            // addRadioButton
            // 
            addRadioButton.BackColor = Color.FromArgb(255, 191, 0);
            addRadioButton.FlatAppearance.BorderSize = 0;
            addRadioButton.FlatStyle = FlatStyle.Flat;
            addRadioButton.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            addRadioButton.ForeColor = Color.FromArgb(51, 51, 51);
            addRadioButton.Location = new Point(72, 148);
            addRadioButton.Name = "addRadioButton";
            addRadioButton.Size = new Size(110, 20);
            addRadioButton.TabIndex = 7;
            addRadioButton.Text = "Add";
            addRadioButton.UseVisualStyleBackColor = false;
            addRadioButton.Click += addRadioButton_Click;
            addRadioButton.MouseEnter += ChangeBackgroundColorMouseEnter;
            addRadioButton.MouseLeave += ChangeBackgroundColorMouseLeave;
            // 
            // settingsLabel
            // 
            settingsLabel.AutoSize = true;
            settingsLabel.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            settingsLabel.ForeColor = Color.FromArgb(255, 191, 0);
            settingsLabel.Location = new Point(100, 15);
            settingsLabel.MaximumSize = new Size(100, 20);
            settingsLabel.Name = "settingsLabel";
            settingsLabel.Size = new Size(53, 13);
            settingsLabel.TabIndex = 18;
            settingsLabel.Text = "Settings";
            // 
            // addRadioLabel
            // 
            addRadioLabel.AutoSize = true;
            addRadioLabel.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            addRadioLabel.ForeColor = Color.FromArgb(255, 191, 0);
            addRadioLabel.Location = new Point(9, 35);
            addRadioLabel.Name = "addRadioLabel";
            addRadioLabel.Size = new Size(43, 13);
            addRadioLabel.TabIndex = 19;
            addRadioLabel.Text = "Name:";
            // 
            // addRadioURL
            // 
            addRadioURL.AutoSize = true;
            addRadioURL.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            addRadioURL.ForeColor = Color.FromArgb(255, 191, 0);
            addRadioURL.Location = new Point(9, 90);
            addRadioURL.Name = "addRadioURL";
            addRadioURL.Size = new Size(36, 13);
            addRadioURL.TabIndex = 20;
            addRadioURL.Text = "URL:";
            // 
            // editRadioName
            // 
            editRadioName.AutoSize = true;
            editRadioName.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            editRadioName.ForeColor = Color.FromArgb(255, 191, 0);
            editRadioName.Location = new Point(9, 233);
            editRadioName.Name = "editRadioName";
            editRadioName.Size = new Size(43, 13);
            editRadioName.TabIndex = 21;
            editRadioName.Text = "Name:";
            // 
            // editRadioURL
            // 
            editRadioURL.AutoSize = true;
            editRadioURL.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            editRadioURL.ForeColor = Color.FromArgb(255, 191, 0);
            editRadioURL.Location = new Point(9, 292);
            editRadioURL.Name = "editRadioURL";
            editRadioURL.Size = new Size(36, 13);
            editRadioURL.TabIndex = 22;
            editRadioURL.Text = "URL:";
            // 
            // closePictureBox
            // 
            closePictureBox.BackColor = Color.FromArgb(255, 191, 0);
            closePictureBox.Image = Properties.Resources.Close;
            closePictureBox.Location = new Point(222, 8);
            closePictureBox.Name = "closePictureBox";
            closePictureBox.Size = new Size(20, 20);
            closePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            closePictureBox.TabIndex = 23;
            closePictureBox.TabStop = false;
            closePictureBox.Click += closePictureBox_Click;
            closePictureBox.MouseEnter += ChangeBackgroundColorMouseEnter;
            closePictureBox.MouseLeave += ChangeBackgroundColorMouseLeave;
            // 
            // minimizePictureBox
            // 
            minimizePictureBox.BackColor = Color.FromArgb(255, 191, 0);
            minimizePictureBox.Image = Properties.Resources.Minimize;
            minimizePictureBox.Location = new Point(196, 8);
            minimizePictureBox.Name = "minimizePictureBox";
            minimizePictureBox.Size = new Size(20, 20);
            minimizePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            minimizePictureBox.TabIndex = 24;
            minimizePictureBox.TabStop = false;
            minimizePictureBox.Click += minimizePictureBox_Click;
            minimizePictureBox.MouseEnter += ChangeBackgroundColorMouseEnter;
            minimizePictureBox.MouseLeave += ChangeBackgroundColorMouseLeave;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(51, 51, 51);
            ClientSize = new Size(255, 394);
            Controls.Add(minimizePictureBox);
            Controls.Add(closePictureBox);
            Controls.Add(editRadioURL);
            Controls.Add(editRadioName);
            Controls.Add(addRadioURL);
            Controls.Add(addRadioLabel);
            Controls.Add(settingsLabel);
            Controls.Add(addRadioButton);
            Controls.Add(addRadioURLTB);
            Controls.Add(addRadioNameTB);
            Controls.Add(removeRadioButton);
            Controls.Add(editRadioNameTB);
            Controls.Add(editRadioURLTB);
            Controls.Add(editRadioButton);
            Controls.Add(radioDropDownList);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            Name = "SettingsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Settings";
            TopMost = true;
            Paint += SettingsForm_Paint;
            MouseDown += SettingsForm_MouseDown;
            ((System.ComponentModel.ISupportInitialize)closePictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)minimizePictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlatComboBox radioDropDownList;
        private Button editRadioButton;
        private TextBox editRadioURLTB;
        private TextBox editRadioNameTB;
        private Button removeRadioButton;
        private TextBox addRadioNameTB;
        private TextBox addRadioURLTB;
        private Button addRadioButton;
        private Label settingsLabel;
        private Label addRadioLabel;
        private Label addRadioURL;
        private Label editRadioName;
        private Label editRadioURL;
        private PictureBox closePictureBox;
        private PictureBox minimizePictureBox;
    }
}