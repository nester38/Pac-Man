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

            this.Hide();

        }


        private void btnExit(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


