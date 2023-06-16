namespace NewTracker
{
    partial class MainMenu
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
            btnStart = new Button();
            btnSettings = new Button();
            btnExit = new Button();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Location = new Point(111, 30);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(150, 50);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += Start_Click;
            // 
            // btnSettings
            // 
            btnSettings.Location = new Point(111, 108);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(150, 50);
            btnSettings.TabIndex = 1;
            btnSettings.Text = "Settings";
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += Settings_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(111, 233);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(150, 50);
            btnExit.TabIndex = 3;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += Exit_Click;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(375, 311);
            Controls.Add(btnExit);
            Controls.Add(btnSettings);
            Controls.Add(btnStart);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainMenu";
            Text = "MainMenu";
            FormClosing += MainMenu_FormClosing;
            VisibleChanged += MainMenu_VisibleChanged;
            ResumeLayout(false);
        }

        #endregion

        private Button btnStart;
        private Button btnSettings;
        private Button btnExit;
    }
}