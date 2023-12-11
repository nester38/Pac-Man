using Microsoft.VisualBasic.ApplicationServices;
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
using static Pac_Man.Character;
using static Pac_Man.Character.Ghost;

namespace Pac_Man
{
    public partial class GameBoard : Form
    {

        // Initialize characters

        int score = 0;
        public int pacManX = 323; // Initial X position of Pac-Man
        public int pacManY = 432; // Initial Y position of Pac-Man
        private int pacManSpeed = 6; // Pac-Man movement speed




        Image left = Image.FromFile(@"C:\Users\c3080901\OneDrive - Sheffield Hallam University\Pictures\PacMan_left.png");
        Image right = Image.FromFile(@"C:\Users\c3080901\OneDrive - Sheffield Hallam University\Pictures\PacMan_right.png");
        Image up = Image.FromFile(@"C:\Users\c3080901\OneDrive - Sheffield Hallam University\Pictures\PacMan_up.png");
        Image down = Image.FromFile(@"C:\Users\c3080901\OneDrive - Sheffield Hallam University\Pictures\PacMan_down.png");


        public Player PacMan = new Player();
        public Ghost.Blinky Blinky = new Ghost.Blinky();




        public GameBoard()
        {
            InitializeComponent();
            Character.Player PacMan = new Character.Player();
            Character.Ghost Blinky = new Character.Ghost();
            Character.Ghost Inky = new Character.Ghost();
            Character.Ghost Pinky = new Character.Ghost();
            Character.Ghost Clyde = new Character.Ghost();

            PacMan.PictureBox = PbPacMan;
            Blinky.PictureBox = PbBlinky;
            Inky.PictureBox = PbInky;
            Pinky.PictureBox = PbPinky;
            Clyde.PictureBox = PbClyde;

            Controls.Add(PbPacMan);
            Controls.Add(PbBlinky);
        }




        private void GameBoard_Load(object sender, EventArgs e)
        {
            timer1.Start();

            // play pacman start music 
            SoundPlayer soundPlayer = new SoundPlayer(@"C:\Users\c3080901\OneDrive - Sheffield Hallam University\pacman_beginning.wav");
            soundPlayer.Play();



        }



        private void BtnBack(object sender, EventArgs e)
        {
            timer1.Stop();

            this.Close();
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();

            SoundPlayer soundPlayer = new SoundPlayer();
            soundPlayer.Stop();

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
            CheckCollisions();


        }



        private void pictureBox132_Click(object sender, EventArgs e)
        {

        }

        private void CheckCollisions()
        {
            foreach (Control control in Controls)
            {
                if (control is PictureBox pictureBox &&
                    PbPacMan.Bounds.IntersectsWith(pictureBox.Bounds) &&
                    pictureBox.Tag != null &&
                    pictureBox.Tag.ToString() == "point" &&
                    pictureBox.Visible)
                {
                    // Handle collision with the point logic here
                    // Hide the PictureBox with the "point" tag
                    pictureBox.Visible = false;
                    SoundPlayer soundPlayer = new SoundPlayer(@"C:\Users\c3080901\OneDrive - Sheffield Hallam University\pacman_chomp.wav");
                    soundPlayer.Play();

                    score += 100;
                    lblScore.Text = $"Score {score}";

                }
            }

            foreach (Control control in Controls)
            {
                if (control is PictureBox pictureBox &&
                    PbPacMan.Bounds.IntersectsWith(pictureBox.Bounds) &&
                    pictureBox.Tag != null &&
                    pictureBox.Tag.ToString() == "special_point" &&
                    pictureBox.Visible)
                {
                    // Handle collision with the point logic here
                    // Hide the PictureBox with the "point" tag
                    pictureBox.Visible = false;
                    SoundPlayer soundPlayer = new SoundPlayer(@"C:\Users\c3080901\OneDrive - Sheffield Hallam University\pacman_chomp.wav");
                    soundPlayer.Play();

                    score += 200;

                }

            }

            foreach (Control control in Controls)
            {
                if (control is PictureBox pictureBox &&
                    PbPacMan.Bounds.IntersectsWith(pictureBox.Bounds) &&
                    pictureBox.Tag != null &&
                    pictureBox.Tag.ToString() == "Maze")
                {
                 
                    // Handle collision with the point logic here



                }

            }


            void LoseLife()
            {
                // Checking conditions for losing a life
                if (PacMan.encounteredGhost && PacMan.numOfLives > 0)
                {
                    PacMan.numOfLives -= 1; // Decrementing the number of lives

                    // Looping through controls to find and dispose of a PictureBox
                    foreach (Control control in Controls)
                    {
                        if (control is PictureBox && control.Tag != null && control.Tag.ToString() == "Lives" && control.Visible)
                        {
                            control.Dispose(); // Disposing the PictureBox control
                            break;
                        }
                    }
                }
            }




        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Blinky.CatchPacMan(pacManX, pacManY);
        }

    }
}