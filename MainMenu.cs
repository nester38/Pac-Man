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
using static Pac_Man.Character;

namespace Pac_Man
{
    public partial class MainMenu : Form
    {
        private Player PacMan;

        public MainMenu()
        {
            InitializeComponent();
            PacMan = new Player();
           

        }

        
        private void MainMenu_Load(object sender, EventArgs e)
        {
 
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            // Load the game form  
            GameBoard gameBoard = new GameBoard();
            gameBoard.Show();

            this.Hide();
        }

        private void btnExit(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
