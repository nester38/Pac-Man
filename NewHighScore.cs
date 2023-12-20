using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Pac_Man.Character;
using static System.Formats.Asn1.AsnWriter;

namespace Pac_Man
{
    public partial class NewHighScore : Form
    {
        // Reference to the Player & Ghost to access highScore variable and label
        private Player PacMan;
        private GameBoard Board;

        // Constructor that takes Player and GameBoard instances as parameters
        public NewHighScore(Player pacMan, GameBoard board)
        {
            InitializeComponent();
            PacMan = pacMan;
            Board = board;
        }

        private void NewHighScore_Load(object sender, EventArgs e)
        {
            lblNewHighScore.Text = Convert.ToString(PacMan.highScore);
        }

        private void btncontinue_Click(object sender, EventArgs e)
        {
            Board.GameOver();
            this.Close();

            // Call the GameOver method in the GameBoard instance
            // This allows the user to continue or quit the game after seeing the high score
  
        }
    }

}
