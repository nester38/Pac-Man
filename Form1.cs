namespace Pac_Man
{
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
        }

        private void Loading_Load(object sender, EventArgs e)
        {
            StartLoading(); // This method will handle the loading operations and update the progress bar.
        }

        private async void StartLoading()
        {
            progressBar1.Maximum = 100;
            progressBar1.Minimum = 0;
            progressBar1.Step = 1;
            progressBar1.Style = ProgressBarStyle.Continuous;

            for (int i = 0; i <= 100; i ++)  // 1k increments 
            {
                progressBar1.Value = i;
                await Task.Delay(40); // delay by 1 milli second 
                lblStatus.Text = $"Loading...{i}%";

            }

            if (progressBar1.Value >= 100)
            {
                MainMenu mainMenu = new MainMenu();
                mainMenu.Show();

                this.Hide();

            }

        }
    }
}