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
        private Player PacMan;
        private GameBoard Board;

        public NewHighScore(Player pacMan, GameBoard board)
        {
            InitializeComponent();
            PacMan = pacMan;
            Board = board;
        }

        private void NewHighScore_Load(object sender, EventArgs e)
        {
            lblNewHighScore.Text = Convert.ToString(PacMan.highScore);
            Convert.ToInt32(lblNewHighScore.Text);
        }

        private void btncontinue_Click(object sender, EventArgs e)
        {
            Board.GameOver();
        }
    }

}
