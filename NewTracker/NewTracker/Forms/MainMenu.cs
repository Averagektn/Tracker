namespace NewTracker
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();

            Text = $"Best score: {App.Default.BestScore}";
        }

        private void Start_Click(object sender, EventArgs e)
        {
            var paintForm = new PaintForm();
            paintForm.Show();
            Hide();
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            var settingsForm = new SettingsForm();
            settingsForm.Show();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MainMenu_VisibleChanged(object sender, EventArgs e)
        {
            Text = $"Best score: {App.Default.BestScore}";
        }

        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            App.Default.Save();
        }
    }
}
