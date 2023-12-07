using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pac_Man
{
    public partial class GameBoard : Form
    {
        private int pacManX = 50; // Initial X position of Pac-Man
        private int pacManY = 50; // Initial Y position of Pac-Man
        private int pacManSpeed = 5; // Pac-Man movement speed

        Image left = Image.FromFile(@"C:\Users\c3080901\OneDrive - Sheffield Hallam University\Pictures\PacMan_left.png");
        Image right = Image.FromFile(@"C:\Users\c3080901\OneDrive - Sheffield Hallam University\Pictures\PacMan_right.png");
        Image up = Image.FromFile(@"C:\Users\c3080901\OneDrive - Sheffield Hallam University\Pictures\PacMan_up.png");
        Image down = Image.FromFile(@"C:\Users\c3080901\OneDrive - Sheffield Hallam University\Pictures\PacMan_down.png");


        public GameBoard()
        {
            InitializeComponent();
        }

        private void GameBoard_Load(object sender, EventArgs e)
        {
            // play pacman start music 
            SoundPlayer soundPlayer = new SoundPlayer(@"C:\Users\c3080901\OneDrive - Sheffield Hallam University\pacman_beginning.wav");
            soundPlayer.Play();
        }

        private void BtnBack(object sender, EventArgs e)
        {
            this.Close();
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();

            SoundPlayer soundPlayer = new SoundPlayer();
            soundPlayer.Stop();

        }

        private void GameBoard_Load_1(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();

            SoundPlayer soundPlayer = new SoundPlayer();
            soundPlayer.Stop();

        }



        // Initially tried to hook up key down event to Game board but
        // it did not work so I reaserached and used a text box. 
        private void txtPacManMove_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Left:
                    PbPacMan.Image = left;
                    pacManX -= pacManSpeed; // Move Pac-Man left

                    break;

                case Keys.Right:
                    PbPacMan.Image = right;
                    pacManX += pacManSpeed; // Move Pac-Man right
                    break;

                case Keys.Up:
                    PbPacMan.Image = up;
                    pacManY -= pacManSpeed; // Move Pac-Man up
                    break;

                case Keys.Down:
                    PbPacMan.Image = down;
                    pacManY += pacManSpeed; // Move Pac-Man down
                    break;
            }
           
            // Update the position of Pac-Man on the form
            PbPacMan.Location = new Point(pacManX, pacManY);
        }
    }
}