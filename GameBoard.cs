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
using System.Numerics;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Pac_Man.Character;
using static Pac_Man.Character.Ghost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Pac_Man
{
    public partial class GameBoard : Form
    {

        // Initialize characters

        int score = 0;
        //public int pacManX = 323;  Initial X position of Pac-Man
        //public int pacManY = 432;  Initial Y position of Pac-Man
        private int pacManSpeed = 6; // Pac-Man movement speed
        int MaxDist = 1;
        int MinDist = 1;




        Image left = Image.FromFile(@"C:\Users\c3080901\OneDrive - Sheffield Hallam University\Pictures\PacMan_left.png");
        Image right = Image.FromFile(@"C:\Users\c3080901\OneDrive - Sheffield Hallam University\Pictures\PacMan_right.png");
        Image up = Image.FromFile(@"C:\Users\c3080901\OneDrive - Sheffield Hallam University\Pictures\PacMan_up.png");
        Image down = Image.FromFile(@"C:\Users\c3080901\OneDrive - Sheffield Hallam University\Pictures\PacMan_down.png");


        public Player PacMan = new Player();
        public Ghost.Blinky Blinky = new Ghost.Blinky();
        public Ghost.Pinky Pinky = new Ghost.Pinky();
        public Ghost.Inky Inky = new Ghost.Inky();
        public Ghost.Clyde Clyde = new Ghost.Clyde();




        private Point currentLocation;
        public PacManSounds Sounds = new PacManSounds();


        public GameBoard()
        {
            InitializeComponent();

            PacMan.PictureBox = PbPacMan;
            Blinky.PictureBox = PbBlinky;
            Inky.PictureBox = PbInky;
            Pinky.PictureBox = PbPinky;
            Clyde.PictureBox = PbClyde;

            Controls.Add(PbPacMan);
            Controls.Add(PbBlinky);
            Controls.Add(PbInky);
            Controls.Add(PbPinky);
            Controls.Add(PbClyde);

            currentLocation = PbPacMan.Location;
            PacMan.numOfLives = 3;

            PacMan.xPosition = 323;
            PacMan.yPosition = 432;
        }




        private void GameBoard_Load(object sender, EventArgs e)
        {
            tmrGhosts.Start();

            // play pacman start music 
            SoundPlayer soundPlayer = new SoundPlayer(@"C:\Users\c3080901\OneDrive - Sheffield Hallam University\pacman_beginning.wav");
            soundPlayer.Play();



        }



        private void BtnBack(object sender, EventArgs e)
        {
            tmrGhosts.Stop();

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



        private void pictureBox132_Click(object sender, EventArgs e)
        {

        }

        private async void CheckCollisions()
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
                    Sounds.EatPoint();

                    score += 100;
                    lblScore.Text = $"Score {score}";


                }


                if (control is PictureBox pictureBox2 &&
                    PbPacMan.Bounds.IntersectsWith(pictureBox2.Bounds) &&
                    pictureBox2.Tag != null && pictureBox2.Tag.ToString() == "special_point" && pictureBox2.Visible)
                {
                    // Handle collision with the point logic here
                    // Hide the PictureBox with the "point" tag
                    pictureBox2.Visible = false;

                    score += 200;

                    PacMan.ActivatePowerUp();

                    if (PacMan.isPoweredUp)
                    {
                        // Load frightened ghost images
                        PbBlinky.LoadAsync(@"C:\Users\c3080901\OneDrive - Sheffield Hallam University\Pictures\enemy_eat.gif");
                        PbPinky.LoadAsync(@"C:\Users\c3080901\OneDrive - Sheffield Hallam University\Pictures\enemy_eat.gif");
                        PbInky.LoadAsync(@"C:\Users\c3080901\OneDrive - Sheffield Hallam University\Pictures\enemy_eat.gif");
                        PbClyde.LoadAsync(@"C:\Users\c3080901\OneDrive - Sheffield Hallam University\Pictures\enemy_eat.gif");

                        // Run away logic
                        Blinky.RunAway();
                        Clyde.RunAway();
                        Pinky.RunAway();
                        Inky.RunAway();

                        await Task.Delay(5000);

                        PacMan.DeactivatePowerUp();

                        // Load normal ghost images after 4 second delay 
                        PbBlinky.LoadAsync(@"C:\Users\c3080901\OneDrive - Sheffield Hallam University\Pictures\enemy_3.gif");
                        PbPinky.LoadAsync(@"C:\Users\c3080901\OneDrive - Sheffield Hallam University\Pictures\enemy_1.gif");
                        PbInky.LoadAsync(@"C:\Users\c3080901\OneDrive - Sheffield Hallam University\Pictures\enemy_4.gif");
                        PbClyde.LoadAsync(@"C:\Users\c3080901\OneDrive - Sheffield Hallam University\Pictures\enemy_2.gif");


                    }

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

        private void pictureBox133_Click(object sender, EventArgs e)
        {

        }

        private void tmrGhosts_Tick(object sender, EventArgs e)
        {
            // Blinky 
            if (PbPacMan.Left < PbBlinky.Left)
            {
                PbBlinky.Left -= 5;
            }
            else
            {
                PbBlinky.Left += 5;
            }

            // Inky
            if (PbPacMan.Right < PbInky.Right)
            {
                PbInky.Left += 5;

                foreach (Control control in Controls)
                {
                    if (control is PictureBox pictureBox &&
                        PbInky.Bounds.IntersectsWith(pictureBox.Bounds) &&
                        pictureBox.Tag != null &&
                        pictureBox.Tag.ToString() == "wall")
                    {
                        PbInky.Left -= 5;
                        break;

                    }
                    
                }


                /* Pinky
                if (PbPacMan.Top < PbPinky.Top)
                {
                    PbPinky.Top += 5;
          
                }
       

                /* Clyde
                if (PbPacMan.Right < PbClyde.Right)
                {
                    PbClyde.Left += 5;
                }
                else
                {
                    PbClyde.Left -= 5;
                }
                */




            }
        }
    }
}
