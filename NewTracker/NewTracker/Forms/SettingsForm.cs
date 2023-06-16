namespace NewTracker
{
    public partial class SettingsForm : Form
    {
        private Color color;
        public SettingsForm()
        {
            InitializeComponent();

            openFileDialog.Filter = "Text files (*.txt)|*.txt";

            rbCursorRectangle.Checked = App.Default.IsCursorRect;
            rbCursorEllipse.Checked = App.Default.IsCursorEllipse;
            rbTargetRectangle.Checked = App.Default.IsTargetRect;
            rbTargetEllipse.Checked = App.Default.IsTargetEllipse;
            rbFromNetwork.Checked = App.Default.IsGetFromServer;
            rbFromFile.Checked = App.Default.IsGetFromFile;
            rbTCP.Checked = App.Default.IsTCPConnection;
            rbUDP.Checked = App.Default.IsUDPConnection;

            cbWriteUnique.Checked = App.Default.WriteUnique;

            tbSourceFile.Text = App.Default.SrcFile;
            tbLogFile.Text = App.Default.DstFile;

            nudSpeed.Value = App.Default.Speed;
            nudLogFrequency.Value = App.Default.SaveFrequency;
            nudShotFrequency.Value = App.Default.ShotFrequency;
            nudCursorHeight.Value = App.Default.CursorHeight;
            nudCursorWidth.Value = App.Default.CursorWidth;
            nudScreenHeight.Value = App.Default.ScreenHeight;
            nudScreenWidth.Value = App.Default.ScreenWidth;
            nudTargetHeight.Value = App.Default.TargetHeight;
            nudTargetWidth.Value = App.Default.TargetWidth;

            color = App.Default.CursorColor;
        }

        private void ChooseSourceFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (!openFileDialog.FileName.Equals(tbLogFile.Text))
                {
                    tbSourceFile.Text = openFileDialog.FileName;
                }
            }
        }

        private void ChooseLogFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (!openFileDialog.FileName.Equals(tbSourceFile.Text))
                {
                    tbLogFile.Text = openFileDialog.FileName;
                }
            }
        }

        private void ChooseColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                color = colorDialog.Color;
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Apply_Click(object sender, EventArgs e)
        {
            App.Default.IsTCPConnection = rbTCP.Checked;
            App.Default.IsUDPConnection = rbUDP.Checked;

            App.Default.IsCursorRect = rbCursorRectangle.Checked;
            App.Default.IsCursorEllipse = rbCursorEllipse.Checked;

            App.Default.IsTargetRect = rbTargetRectangle.Checked;
            App.Default.IsTargetEllipse = rbTargetEllipse.Checked;

            App.Default.IsGetFromServer = rbFromNetwork.Checked;
            App.Default.IsGetFromFile = rbFromFile.Checked;

            App.Default.WriteUnique = cbWriteUnique.Checked;

            App.Default.SrcFile = tbSourceFile.Text;
            App.Default.DstFile = tbLogFile.Text;

            App.Default.Speed = (int)nudSpeed.Value;
            App.Default.SaveFrequency = (int)nudLogFrequency.Value;
            App.Default.ShotFrequency = (int)nudShotFrequency.Value;
            App.Default.CursorHeight = (int)nudCursorHeight.Value;
            App.Default.CursorWidth = (int)nudCursorWidth.Value;
            App.Default.ScreenHeight = (int)nudScreenHeight.Value;
            App.Default.ScreenWidth = (int)nudScreenWidth.Value;
            App.Default.TargetHeight = (int)nudTargetHeight.Value;
            App.Default.TargetWidth = (int)nudTargetWidth.Value;

            App.Default.CursorColor = color;

            Close();
        }
    }
}
