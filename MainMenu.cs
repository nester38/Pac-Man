using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pac_Man
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }


        private void btnPlay_Click(object sender, EventArgs e)
        {
            //load the game form  
            GameBoard gameBoard = new GameBoard();
            gameBoard.Show();


            // play pacman start music 
            SoundPlayer soundPlayer = new SoundPlayer(@"C:\Users\c3080901\OneDrive - Sheffield Hallam University\pacman_beginning.wav");
            soundPlayer.Play();

            this.Hide();

        }

        private void btnLeaderBoard_Click(object sender, EventArgs e)
        {
            LeaderBoard leaderBoard = new LeaderBoard();
            leaderBoard.Show();

            this.Hide();
        }

        private void btnGameInstructions_Click(object sender, EventArgs e)
        {
            GameInstructions gameInstructions = new GameInstructions();
            gameInstructions.Show();

            this.Hide();

        }

        private void lblHighScore_Click(object sender, EventArgs e)
        {
            //this will not be here the code should run if the user has a new high score 
            NewHighScore newHighScore = new NewHighScore();
            newHighScore.Show();

            SoundPlayer soundPlayer = new SoundPlayer(@"C:\Users\c3080901\OneDrive - Sheffield Hallam University\newhighscore.wav");
            soundPlayer.Play();
        }
    }
}


