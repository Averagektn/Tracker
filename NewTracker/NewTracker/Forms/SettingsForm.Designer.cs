namespace NewTracker
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
            rbTargetEllipse = new RadioButton();
            gbTarget = new GroupBox();
            rbTargetRectangle = new RadioButton();
            rbCursorEllipse = new RadioButton();
            rbCursorRectangle = new RadioButton();
            tbSourceFile = new TextBox();
            gbCursor = new GroupBox();
            tbLogFile = new TextBox();
            lblSourceFile = new Label();
            lblLogFile = new Label();
            nudSpeed = new NumericUpDown();
            lblSpeed = new Label();
            nudShotFrequency = new NumericUpDown();
            nudLogFrequency = new NumericUpDown();
            lblShotFrequency = new Label();
            lblLogFrequency = new Label();
            cbWriteUnique = new CheckBox();
            nudScreenHeight = new NumericUpDown();
            nudScreenWidth = new NumericUpDown();
            nudCursorHeight = new NumericUpDown();
            nudCursorWidth = new NumericUpDown();
            nudTargetHeight = new NumericUpDown();
            nudTargetWidth = new NumericUpDown();
            lblScreenWidth = new Label();
            lblCursorHeight = new Label();
            lblCursorWidth = new Label();
            lblTargetHeight = new Label();
            lblTargetWidth = new Label();
            lblScreenHeight = new Label();
            rbFromNetwork = new RadioButton();
            rbFromFile = new RadioButton();
            gbSourceData = new GroupBox();
            colorDialog = new ColorDialog();
            openFileDialog = new OpenFileDialog();
            btnChooseSourceFile = new Button();
            btnChooseLogFile = new Button();
            btnChooseColor = new Button();
            btnApply = new Button();
            btnCancel = new Button();
            rbUDP = new RadioButton();
            rbTCP = new RadioButton();
            gbConnectionType = new GroupBox();
            gbTarget.SuspendLayout();
            gbCursor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudSpeed).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudShotFrequency).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudLogFrequency).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudScreenHeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudScreenWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCursorHeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCursorWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudTargetHeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudTargetWidth).BeginInit();
            gbSourceData.SuspendLayout();
            gbConnectionType.SuspendLayout();
            SuspendLayout();
            // 
            // rbTargetEllipse
            // 
            rbTargetEllipse.AutoSize = true;
            rbTargetEllipse.Location = new Point(25, 25);
            rbTargetEllipse.Name = "rbTargetEllipse";
            rbTargetEllipse.Size = new Size(64, 23);
            rbTargetEllipse.TabIndex = 0;
            rbTargetEllipse.Text = "Ellipse";
            rbTargetEllipse.UseVisualStyleBackColor = true;
            // 
            // gbTarget
            // 
            gbTarget.Controls.Add(rbTargetRectangle);
            gbTarget.Controls.Add(rbTargetEllipse);
            gbTarget.Location = new Point(380, 117);
            gbTarget.Name = "gbTarget";
            gbTarget.Size = new Size(212, 83);
            gbTarget.TabIndex = 1;
            gbTarget.TabStop = false;
            gbTarget.Text = "Target";
            // 
            // rbTargetRectangle
            // 
            rbTargetRectangle.AutoSize = true;
            rbTargetRectangle.Location = new Point(25, 54);
            rbTargetRectangle.Name = "rbTargetRectangle";
            rbTargetRectangle.Size = new Size(86, 23);
            rbTargetRectangle.TabIndex = 2;
            rbTargetRectangle.Text = "Rectangle";
            rbTargetRectangle.UseVisualStyleBackColor = true;
            // 
            // rbCursorEllipse
            // 
            rbCursorEllipse.AutoSize = true;
            rbCursorEllipse.Location = new Point(23, 25);
            rbCursorEllipse.Name = "rbCursorEllipse";
            rbCursorEllipse.Size = new Size(64, 23);
            rbCursorEllipse.TabIndex = 3;
            rbCursorEllipse.TabStop = true;
            rbCursorEllipse.Text = "Ellipse";
            rbCursorEllipse.UseVisualStyleBackColor = true;
            // 
            // rbCursorRectangle
            // 
            rbCursorRectangle.AutoSize = true;
            rbCursorRectangle.Location = new Point(23, 54);
            rbCursorRectangle.Name = "rbCursorRectangle";
            rbCursorRectangle.Size = new Size(86, 23);
            rbCursorRectangle.TabIndex = 4;
            rbCursorRectangle.TabStop = true;
            rbCursorRectangle.Text = "Rectangle";
            rbCursorRectangle.UseVisualStyleBackColor = true;
            // 
            // tbSourceFile
            // 
            tbSourceFile.Location = new Point(57, 335);
            tbSourceFile.Name = "tbSourceFile";
            tbSourceFile.ReadOnly = true;
            tbSourceFile.Size = new Size(365, 26);
            tbSourceFile.TabIndex = 5;
            // 
            // gbCursor
            // 
            gbCursor.Controls.Add(rbCursorEllipse);
            gbCursor.Controls.Add(rbCursorRectangle);
            gbCursor.Location = new Point(380, 16);
            gbCursor.Name = "gbCursor";
            gbCursor.Size = new Size(212, 83);
            gbCursor.TabIndex = 2;
            gbCursor.TabStop = false;
            gbCursor.Text = "Cursor";
            // 
            // tbLogFile
            // 
            tbLogFile.Location = new Point(57, 394);
            tbLogFile.Name = "tbLogFile";
            tbLogFile.Size = new Size(365, 26);
            tbLogFile.TabIndex = 6;
            // 
            // lblSourceFile
            // 
            lblSourceFile.AutoSize = true;
            lblSourceFile.Location = new Point(57, 313);
            lblSourceFile.Name = "lblSourceFile";
            lblSourceFile.Size = new Size(71, 19);
            lblSourceFile.TabIndex = 7;
            lblSourceFile.Text = "Source file";
            // 
            // lblLogFile
            // 
            lblLogFile.AutoSize = true;
            lblLogFile.Location = new Point(57, 375);
            lblLogFile.Name = "lblLogFile";
            lblLogFile.Size = new Size(53, 19);
            lblLogFile.TabIndex = 8;
            lblLogFile.Text = "Log file";
            // 
            // nudSpeed
            // 
            nudSpeed.Location = new Point(271, 445);
            nudSpeed.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudSpeed.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudSpeed.Name = "nudSpeed";
            nudSpeed.Size = new Size(120, 26);
            nudSpeed.TabIndex = 9;
            nudSpeed.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblSpeed
            // 
            lblSpeed.AutoSize = true;
            lblSpeed.Location = new Point(271, 426);
            lblSpeed.Name = "lblSpeed";
            lblSpeed.Size = new Size(46, 19);
            lblSpeed.TabIndex = 10;
            lblSpeed.Text = "Speed";
            // 
            // nudShotFrequency
            // 
            nudShotFrequency.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            nudShotFrequency.Location = new Point(55, 232);
            nudShotFrequency.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudShotFrequency.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            nudShotFrequency.Name = "nudShotFrequency";
            nudShotFrequency.Size = new Size(120, 26);
            nudShotFrequency.TabIndex = 11;
            nudShotFrequency.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // nudLogFrequency
            // 
            nudLogFrequency.Location = new Point(56, 284);
            nudLogFrequency.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudLogFrequency.Name = "nudLogFrequency";
            nudLogFrequency.Size = new Size(120, 26);
            nudLogFrequency.TabIndex = 12;
            nudLogFrequency.Value = new decimal(new int[] { 40, 0, 0, 0 });
            // 
            // lblShotFrequency
            // 
            lblShotFrequency.AutoSize = true;
            lblShotFrequency.Location = new Point(56, 212);
            lblShotFrequency.Name = "lblShotFrequency";
            lblShotFrequency.Size = new Size(127, 19);
            lblShotFrequency.TabIndex = 13;
            lblShotFrequency.Text = "Shot frequency(ms)";
            // 
            // lblLogFrequency
            // 
            lblLogFrequency.AutoSize = true;
            lblLogFrequency.Location = new Point(57, 262);
            lblLogFrequency.Name = "lblLogFrequency";
            lblLogFrequency.Size = new Size(122, 19);
            lblLogFrequency.TabIndex = 14;
            lblLogFrequency.Text = "Log frequency(ms)";
            // 
            // cbWriteUnique
            // 
            cbWriteUnique.AutoSize = true;
            cbWriteUnique.Location = new Point(237, 477);
            cbWriteUnique.Name = "cbWriteUnique";
            cbWriteUnique.Size = new Size(212, 23);
            cbWriteUnique.TabIndex = 15;
            cbWriteUnique.Text = "Write only unique coordinates";
            cbWriteUnique.UseVisualStyleBackColor = true;
            // 
            // nudScreenHeight
            // 
            nudScreenHeight.Increment = new decimal(new int[] { 20, 0, 0, 0 });
            nudScreenHeight.Location = new Point(469, 284);
            nudScreenHeight.Maximum = new decimal(new int[] { 1080, 0, 0, 0 });
            nudScreenHeight.Minimum = new decimal(new int[] { 400, 0, 0, 0 });
            nudScreenHeight.Name = "nudScreenHeight";
            nudScreenHeight.Size = new Size(120, 26);
            nudScreenHeight.TabIndex = 16;
            nudScreenHeight.Value = new decimal(new int[] { 400, 0, 0, 0 });
            // 
            // nudScreenWidth
            // 
            nudScreenWidth.Increment = new decimal(new int[] { 20, 0, 0, 0 });
            nudScreenWidth.Location = new Point(469, 232);
            nudScreenWidth.Maximum = new decimal(new int[] { 1920, 0, 0, 0 });
            nudScreenWidth.Minimum = new decimal(new int[] { 400, 0, 0, 0 });
            nudScreenWidth.Name = "nudScreenWidth";
            nudScreenWidth.Size = new Size(120, 26);
            nudScreenWidth.TabIndex = 17;
            nudScreenWidth.Value = new decimal(new int[] { 400, 0, 0, 0 });
            // 
            // nudCursorHeight
            // 
            nudCursorHeight.Location = new Point(329, 284);
            nudCursorHeight.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudCursorHeight.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCursorHeight.Name = "nudCursorHeight";
            nudCursorHeight.Size = new Size(120, 26);
            nudCursorHeight.TabIndex = 18;
            nudCursorHeight.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // nudCursorWidth
            // 
            nudCursorWidth.Location = new Point(329, 232);
            nudCursorWidth.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudCursorWidth.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCursorWidth.Name = "nudCursorWidth";
            nudCursorWidth.Size = new Size(120, 26);
            nudCursorWidth.TabIndex = 19;
            nudCursorWidth.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // nudTargetHeight
            // 
            nudTargetHeight.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            nudTargetHeight.Location = new Point(193, 284);
            nudTargetHeight.Minimum = new decimal(new int[] { 50, 0, 0, 0 });
            nudTargetHeight.Name = "nudTargetHeight";
            nudTargetHeight.Size = new Size(120, 26);
            nudTargetHeight.TabIndex = 20;
            nudTargetHeight.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // nudTargetWidth
            // 
            nudTargetWidth.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            nudTargetWidth.Location = new Point(193, 232);
            nudTargetWidth.Minimum = new decimal(new int[] { 50, 0, 0, 0 });
            nudTargetWidth.Name = "nudTargetWidth";
            nudTargetWidth.Size = new Size(120, 26);
            nudTargetWidth.TabIndex = 21;
            nudTargetWidth.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // lblScreenWidth
            // 
            lblScreenWidth.AutoSize = true;
            lblScreenWidth.Location = new Point(469, 212);
            lblScreenWidth.Name = "lblScreenWidth";
            lblScreenWidth.Size = new Size(87, 19);
            lblScreenWidth.TabIndex = 22;
            lblScreenWidth.Text = "Screen width";
            // 
            // lblCursorHeight
            // 
            lblCursorHeight.AutoSize = true;
            lblCursorHeight.Location = new Point(329, 262);
            lblCursorHeight.Name = "lblCursorHeight";
            lblCursorHeight.Size = new Size(93, 19);
            lblCursorHeight.TabIndex = 23;
            lblCursorHeight.Text = "Cursor height";
            // 
            // lblCursorWidth
            // 
            lblCursorWidth.AutoSize = true;
            lblCursorWidth.Location = new Point(329, 212);
            lblCursorWidth.Name = "lblCursorWidth";
            lblCursorWidth.Size = new Size(88, 19);
            lblCursorWidth.TabIndex = 24;
            lblCursorWidth.Text = "Cursor width";
            // 
            // lblTargetHeight
            // 
            lblTargetHeight.AutoSize = true;
            lblTargetHeight.Location = new Point(193, 262);
            lblTargetHeight.Name = "lblTargetHeight";
            lblTargetHeight.Size = new Size(89, 19);
            lblTargetHeight.TabIndex = 25;
            lblTargetHeight.Text = "Target height";
            // 
            // lblTargetWidth
            // 
            lblTargetWidth.AutoSize = true;
            lblTargetWidth.Location = new Point(193, 212);
            lblTargetWidth.Name = "lblTargetWidth";
            lblTargetWidth.Size = new Size(84, 19);
            lblTargetWidth.TabIndex = 26;
            lblTargetWidth.Text = "Target width";
            // 
            // lblScreenHeight
            // 
            lblScreenHeight.AutoSize = true;
            lblScreenHeight.Location = new Point(469, 262);
            lblScreenHeight.Name = "lblScreenHeight";
            lblScreenHeight.Size = new Size(92, 19);
            lblScreenHeight.TabIndex = 27;
            lblScreenHeight.Text = "Screen height";
            // 
            // rbFromNetwork
            // 
            rbFromNetwork.AutoSize = true;
            rbFromNetwork.Location = new Point(25, 47);
            rbFromNetwork.Name = "rbFromNetwork";
            rbFromNetwork.Size = new Size(113, 23);
            rbFromNetwork.TabIndex = 2;
            rbFromNetwork.TabStop = true;
            rbFromNetwork.Text = "From network";
            rbFromNetwork.UseVisualStyleBackColor = true;
            // 
            // rbFromFile
            // 
            rbFromFile.AutoSize = true;
            rbFromFile.Location = new Point(25, 21);
            rbFromFile.Name = "rbFromFile";
            rbFromFile.Size = new Size(80, 23);
            rbFromFile.TabIndex = 0;
            rbFromFile.TabStop = true;
            rbFromFile.Text = "From file";
            rbFromFile.UseVisualStyleBackColor = true;
            // 
            // gbSourceData
            // 
            gbSourceData.Controls.Add(rbFromNetwork);
            gbSourceData.Controls.Add(rbFromFile);
            gbSourceData.Location = new Point(57, 16);
            gbSourceData.Name = "gbSourceData";
            gbSourceData.Size = new Size(212, 83);
            gbSourceData.TabIndex = 3;
            gbSourceData.TabStop = false;
            gbSourceData.Text = "Source";
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "src.txt";
            openFileDialog.Title = "Choose text file";
            // 
            // btnChooseSourceFile
            // 
            btnChooseSourceFile.Location = new Point(439, 322);
            btnChooseSourceFile.Name = "btnChooseSourceFile";
            btnChooseSourceFile.Size = new Size(150, 50);
            btnChooseSourceFile.TabIndex = 28;
            btnChooseSourceFile.Text = "Choose source file...";
            btnChooseSourceFile.UseVisualStyleBackColor = true;
            btnChooseSourceFile.Click += ChooseSourceFile_Click;
            // 
            // btnChooseLogFile
            // 
            btnChooseLogFile.Location = new Point(439, 381);
            btnChooseLogFile.Name = "btnChooseLogFile";
            btnChooseLogFile.Size = new Size(150, 50);
            btnChooseLogFile.TabIndex = 29;
            btnChooseLogFile.Text = "Choose log file...";
            btnChooseLogFile.UseVisualStyleBackColor = true;
            btnChooseLogFile.Click += ChooseLogFile_Click;
            // 
            // btnChooseColor
            // 
            btnChooseColor.Location = new Point(253, 506);
            btnChooseColor.Name = "btnChooseColor";
            btnChooseColor.Size = new Size(150, 50);
            btnChooseColor.TabIndex = 30;
            btnChooseColor.Text = "Choose color...";
            btnChooseColor.UseVisualStyleBackColor = true;
            btnChooseColor.Click += ChooseColor_Click;
            // 
            // btnApply
            // 
            btnApply.Location = new Point(106, 574);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(150, 50);
            btnApply.TabIndex = 31;
            btnApply.Text = "Apply";
            btnApply.UseVisualStyleBackColor = true;
            btnApply.Click += Apply_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(403, 574);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(150, 50);
            btnCancel.TabIndex = 32;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += Cancel_Click;
            // 
            // rbUDP
            // 
            rbUDP.AutoSize = true;
            rbUDP.Location = new Point(25, 54);
            rbUDP.Name = "rbUDP";
            rbUDP.Size = new Size(55, 23);
            rbUDP.TabIndex = 2;
            rbUDP.Text = "UDP";
            rbUDP.UseVisualStyleBackColor = true;
            // 
            // rbTCP
            // 
            rbTCP.AutoSize = true;
            rbTCP.Location = new Point(25, 25);
            rbTCP.Name = "rbTCP";
            rbTCP.Size = new Size(50, 23);
            rbTCP.TabIndex = 0;
            rbTCP.Text = "TCP";
            rbTCP.UseVisualStyleBackColor = true;
            // 
            // gbConnectionType
            // 
            gbConnectionType.Controls.Add(rbUDP);
            gbConnectionType.Controls.Add(rbTCP);
            gbConnectionType.Location = new Point(57, 117);
            gbConnectionType.Name = "gbConnectionType";
            gbConnectionType.Size = new Size(212, 83);
            gbConnectionType.TabIndex = 3;
            gbConnectionType.TabStop = false;
            gbConnectionType.Text = "Connction type";
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(660, 636);
            Controls.Add(gbConnectionType);
            Controls.Add(btnCancel);
            Controls.Add(btnApply);
            Controls.Add(btnChooseColor);
            Controls.Add(btnChooseLogFile);
            Controls.Add(btnChooseSourceFile);
            Controls.Add(gbSourceData);
            Controls.Add(lblScreenHeight);
            Controls.Add(gbCursor);
            Controls.Add(lblTargetWidth);
            Controls.Add(lblTargetHeight);
            Controls.Add(lblCursorWidth);
            Controls.Add(lblCursorHeight);
            Controls.Add(lblScreenWidth);
            Controls.Add(nudTargetWidth);
            Controls.Add(nudTargetHeight);
            Controls.Add(nudCursorWidth);
            Controls.Add(nudCursorHeight);
            Controls.Add(nudScreenWidth);
            Controls.Add(nudScreenHeight);
            Controls.Add(cbWriteUnique);
            Controls.Add(lblLogFrequency);
            Controls.Add(lblShotFrequency);
            Controls.Add(nudLogFrequency);
            Controls.Add(nudShotFrequency);
            Controls.Add(lblSpeed);
            Controls.Add(nudSpeed);
            Controls.Add(lblLogFile);
            Controls.Add(lblSourceFile);
            Controls.Add(tbLogFile);
            Controls.Add(tbSourceFile);
            Controls.Add(gbTarget);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "SettingsForm";
            Text = "Settings";
            gbTarget.ResumeLayout(false);
            gbTarget.PerformLayout();
            gbCursor.ResumeLayout(false);
            gbCursor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudSpeed).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudShotFrequency).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudLogFrequency).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudScreenHeight).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudScreenWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCursorHeight).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCursorWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudTargetHeight).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudTargetWidth).EndInit();
            gbSourceData.ResumeLayout(false);
            gbSourceData.PerformLayout();
            gbConnectionType.ResumeLayout(false);
            gbConnectionType.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton rbTargetEllipse;
        private GroupBox gbTarget;
        private RadioButton rbTargetRectangle;
        private RadioButton rbCursorEllipse;
        private RadioButton rbCursorRectangle;
        private TextBox tbSourceFile;
        private GroupBox gbCursor;
        private TextBox tbLogFile;
        private Label lblSourceFile;
        private Label lblLogFile;
        private NumericUpDown nudSpeed;
        private Label lblSpeed;
        private NumericUpDown nudShotFrequency;
        private NumericUpDown nudLogFrequency;
        private Label lblShotFrequency;
        private Label lblLogFrequency;
        private CheckBox cbWriteUnique;
        private NumericUpDown nudScreenHeight;
        private NumericUpDown nudScreenWidth;
        private NumericUpDown nudCursorHeight;
        private NumericUpDown nudCursorWidth;
        private NumericUpDown nudTargetHeight;
        private NumericUpDown nudTargetWidth;
        private Label lblScreenWidth;
        private Label lblCursorHeight;
        private Label lblCursorWidth;
        private Label lblTargetHeight;
        private Label lblTargetWidth;
        private Label lblScreenHeight;
        private RadioButton rbFromNetwork;
        private RadioButton rbFromFile;
        private GroupBox gbSourceData;
        private ColorDialog colorDialog;
        private OpenFileDialog openFileDialog;
        private Button btnChooseSourceFile;
        private Button btnChooseLogFile;
        private Button btnChooseColor;
        private Button btnApply;
        private Button btnCancel;
        private RadioButton rbUDP;
        private RadioButton rbTCP;
        private GroupBox gbConnectionType;
    }
}