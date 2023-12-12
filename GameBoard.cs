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
       //public int pacManX = 323;  Initial X position of Pac-Man
       //public int pacManY = 432;  Initial Y position of Pac-Man
        private int pacManSpeed = 6; // Pac-Man movement speed




        Image left = Image.FromFile(@"C:\Users\c3080901\OneDrive - Sheffield Hallam University\Pictures\PacMan_left.png");
        Image right = Image.FromFile(@"C:\Users\c3080901\OneDrive - Sheffield Hallam University\Pictures\PacMan_right.png");
        Image up = Image.FromFile(@"C:\Users\c3080901\OneDrive - Sheffield Hallam University\Pictures\PacMan_up.png");
        Image down = Image.FromFile(@"C:\Users\c3080901\OneDrive - Sheffield Hallam University\Pictures\PacMan_down.png");


        public Player PacMan = new Player();
        public Ghost.Blinky Blinky = new Ghost.Blinky();
        private Point currentLocation;


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

            currentLocation = PbPacMan.Location;
            PacMan.numOfLives = 3;

            PacMan.xPosition = 323;
            PacMan.yPosition = 432;

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





        /* Initially tried to hook up key down event to Game board but
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
            currentLocation = PbPacMan.Location;
            CheckCollisions();


        }
        */


        private void pictureBox132_Click(object sender, EventArgs e)
        {

        }

        private void CheckCollisions()
        {
            Blinky.CatchPacMan(PacMan.xPosition, PacMan.yPosition);

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


                if (control is PictureBox pictureBox2 &&
                    PbPacMan.Bounds.IntersectsWith(pictureBox2.Bounds) &&
                    pictureBox2.Tag != null &&
                    pictureBox2.Tag.ToString() == "special_point" &&
                    pictureBox2.Visible)
                {
                    // Handle collision with the point logic here
                    // Hide the PictureBox with the "point" tag
                    pictureBox2.Visible = false;
                    SoundPlayer soundPlayer = new SoundPlayer(@"C:\Users\c3080901\OneDrive - Sheffield Hallam University\pacman_chomp.wav");
                    soundPlayer.Play();

                    score += 200;


                }


                if (control is PictureBox pictureBox3 &&
                    PbPacMan.Bounds.IntersectsWith(pictureBox3.Bounds) &&
                    pictureBox3.Tag != null &&
                    pictureBox3.Tag.ToString() == "wall")

                {   // Handle collision with the point logic here
                    PacMan.xPosition = currentLocation.X;
                    PacMan.yPosition = currentLocation.Y;
                    PbPacMan.Location = new Point(PacMan.xPosition, PacMan.yPosition);




                }

                if (control is PictureBox ghost &&
                   PbPacMan.Bounds.IntersectsWith(ghost.Bounds) &&
                   ghost.Tag != null &&
                   ghost.Tag.ToString() == "ghost")
                {
                    if (PacMan.isPoweredUp == false)
                    {
                        PacMan.encounteredGhost = true;
                        PacMan.numOfLives -= 1;
                        LoseLife();
                    }
                }


            }
        }

            void LoseLife()
            {
                // Checking conditions for losing a life
                if (PacMan.encounteredGhost == true)
                {


                    // Looping through controls to find and dispose of a PictureBox
                    foreach (Control control in Controls)
                    {


                        if (control is PictureBox && control.Tag != null && control.Tag.ToString() == "Life1" && control.Visible && PacMan.numOfLives > 0)
                        {
                            control.Dispose(); // Disposing the PictureBox control
                            lblLives.Text = $"Lives left {PacMan.numOfLives}";
                            break;
                        }
                        else if (control is PictureBox && control.Tag != null && control.Tag.ToString() == "Life2" && control.Visible && PacMan.numOfLives > 0)
                        {
                            control.Dispose(); // Disposing the PictureBox control
                            lblLives.Text = $"Lives left {PacMan.numOfLives}";
                            break;
                        }
                        else if (control is PictureBox && control.Tag != null && control.Tag.ToString() == "Life3" && control.Visible && PacMan.numOfLives >= 0)
                        {
                            control.Dispose(); // Disposing the PictureBox control
                            lblLives.Text = $"Lives left {PacMan.numOfLives}";


                        }
                    }
                }
            }




        
        private void timer1_Tick(object sender, EventArgs e)
        {
         // Blinky.CatchPacMan(PacMan.yPosition, PacMan.yPosition);
        }

        private void GameBoard_Load_1(object sender, EventArgs e)
        {

        }

        private void GameBoard_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Left:
                    PbPacMan.Image = left;
                    PacMan.xPosition -= pacManSpeed; // Move Pac-Man left

                    break;

                case Keys.Right:
                    PbPacMan.Image = right;
                    PacMan.xPosition += pacManSpeed; // Move Pac-Man right
                    break;

                case Keys.Up:
                    PbPacMan.Image = up;
                    PacMan.yPosition -= pacManSpeed; // Move Pac-Man up
                    break;

                case Keys.Down:
                    PbPacMan.Image = down;
                    PacMan.yPosition += pacManSpeed; // Move Pac-Man down
                    break;
            }

            // Update the position of Pac-Man on the form


            PbPacMan.Location = new Point(PacMan.xPosition, PacMan.yPosition);
            currentLocation = PbPacMan.Location;
            CheckCollisions();
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            this.Close();
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();

            SoundPlayer soundPlayer = new SoundPlayer();
            soundPlayer.Stop();
        }
    }
}