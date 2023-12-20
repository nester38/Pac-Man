using static Pac_Man.Character;

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
            StartLoading(); // Handling the loading operations and updating the progress bar.
        }

        private async void StartLoading()
        {
            progressBar1.Maximum = 100;
            progressBar1.Minimum = 0;
            progressBar1.Step = 1;
            progressBar1.Style = ProgressBarStyle.Continuous;

            for (int i = 0; i <= 100; i ++)  // 100 increments 
            {
                progressBar1.Value = i;
                await Task.Delay(40);  // delay to simulate loading time

                // Update the status label to reflect the current loading progress
                lblStatus.Text = $"Loading...{i}%";

            }

            // Open main menu after loading completes 
            if (progressBar1.Value >= 100)
            {
                MainMenu mainMenu = new MainMenu();
                mainMenu.Show();

                this.Hide();

            }

        }
    }
}