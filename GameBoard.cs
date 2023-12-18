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
using Timer = System.Windows.Forms.Timer;

namespace Pac_Man
{
    public partial class GameBoard : Form
    {

        // Initialize characters

        public int score = 0;
        public bool gameOver = true;
        //public int pacManX = 323;  Initial X position of Pac-Man
        //public int pacManY = 432;  Initial Y position of Pac-Man
        private int pacManSpeed = 8; // Pac-Man movement speed
        public bool noLeft, noRight, noUp, noDown;
        public bool goLeft, goRight, goUp, goDown;



        Image left = Image.FromFile(@"C:\Users\student\OneDrive - Sheffield Hallam University\Pictures\pacmanleft.gif");
        Image right = Image.FromFile(@"C:\Users\student\OneDrive - Sheffield Hallam University\Pictures\pacmanright.gif");
        Image up = Image.FromFile(@"C:\Users\student\OneDrive - Sheffield Hallam University\Pictures\pacmanup.gif");
        Image down = Image.FromFile(@"C:\Users\student\OneDrive - Sheffield Hallam University\Pictures\pacmandown.gif");


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

            PacMan.xPosition = 330;
            PacMan.yPosition = 434;

            Blinky.xPosition = 288; 
            Blinky.yPosition = 265;

            Pinky.xPosition = 323;
            Pinky.yPosition = 275;

            Clyde.xPosition = 358;
            Clyde.yPosition = 275;

            Inky.xPosition = 347;
            Inky.yPosition = 116;

            PacMan.highScore = 0;

        }




        private void GameBoard_Load(object sender, EventArgs e)
        {
            Sounds.PlayIntro();
            tmrGhosts.Start();
            Highscore();

        }


   
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();

            SoundPlayer soundPlayer = new SoundPlayer();
            soundPlayer.Stop();

        }

        public async void GameOver()
        {
            await Task.Delay(100);
            

            string message ="Would you like to play again?";
            string title = "Game Over";
            PictureBox gameOverPicture = new PictureBox();
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    this.Close();
                    GameBoard gameBoard = new GameBoard();
                    gameBoard.Show();
                }
                else
                {
                    Highscore();
                    this.Close();
                    MainMenu menu = new MainMenu(); 
                    menu.Show();
                }
            
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

                    score += 50;
                    lblScore.Text = Convert.ToString(score);
                    Highscore();



                }


                if (control is PictureBox pictureBox2 &&
                    PbPacMan.Bounds.IntersectsWith(pictureBox2.Bounds) &&
                    pictureBox2.Tag != null && pictureBox2.Tag.ToString() == "special_point" && pictureBox2.Visible)
                {
                    // Handle collision with the point logic here
                    // Hide the PictureBox with the "point" tag
                    pictureBox2.Visible = false;

                    score += 100;
                    Highscore();


                    PacMan.ActivatePowerUp();

                    if (PacMan.isPoweredUp)
                    {
                        // Load frightened ghost images
                        PbBlinky.LoadAsync(@"C:\Users\student\OneDrive - Sheffield Hallam University\Pictures\enemy_eat.gif");
                        PbPinky.LoadAsync(@"C:\Users\student\OneDrive - Sheffield Hallam University\Pictures\enemy_eat.gif");
                        PbInky.LoadAsync(@"C:\Users\student\OneDrive - Sheffield Hallam University\Pictures\enemy_eat.gif");
                        PbClyde.LoadAsync(@"C:\Users\student\OneDrive - Sheffield Hallam University\Pictures\enemy_eat.gif");

                        // Run away logic
                        Blinky.RunAway();
                        Clyde.RunAway();
                        Pinky.RunAway();
                        Inky.RunAway();

                        await Task.Delay(10000);

                        PacMan.DeactivatePowerUp();

                        // Load normal ghost images after 4 second delay 
                        PbBlinky.LoadAsync(@"C:\Users\student\OneDrive - Sheffield Hallam University\Pictures\enemy_3.gif");
                        PbPinky.LoadAsync(@"C:\Users\student\OneDrive - Sheffield Hallam University\Pictures\enemy_1.gif");
                        PbInky.LoadAsync(@"C:\Users\student\OneDrive - Sheffield Hallam University\Pictures\enemy_4.gif");
                        PbClyde.LoadAsync(@"C:\Users\student\OneDrive - Sheffield Hallam University\Pictures\enemy_2.gif");


                    }

                }


                if (control is PictureBox pictureBox3 &&
                    PbPacMan.Bounds.IntersectsWith(pictureBox3.Bounds) &&
                    pictureBox3.Tag != null &&
                    pictureBox3.Tag.ToString() == "wall")

                {   
                  if (goLeft == true)
                    {
                        noLeft = true;
                        goLeft = false;
                    }


                  if (goRight == true)
                    {
                        noRight = true;
                        goLeft = true;
                    }


                  if (goUp == true)
                    {
                        noUp = true;
                        goUp = true;
                    }


                  if (goDown == true)
                    {
                        noDown = true;
                        goDown = true;
                    }


                }

                if (control is PictureBox ghost &&
                   PbPacMan.Bounds.IntersectsWith(ghost.Bounds) &&
                   ghost.Tag != null &&
                   ghost.Tag.ToString() == "ghost")
                {
                    if (PacMan.isPoweredUp == false)
                    {
                        PacMan.canEatGhost = false;
                        PacMan.numOfLives --;
                        LoseLife();
                        Sounds.LoseLife();

                        PacMan.noDown = noLeft= noRight = noUp = true;
                        PacMan.Respawn();


                        if (PacMan.numOfLives == 0)
                        {
                            if (score >= PacMan.highScore)
                            {
                                newHighScore();
                            }
                            else
                            {
                                GameOver();
                            }
                           
                        }
                    }
                    else if (PacMan.isPoweredUp == true)
                    {
                        PacMan.canEatGhost = true;
                        Sounds.EatGhost();

                        score += 200;
                        lblScore.Text = Convert.ToString(score);  // Update the label with the new score
                        Highscore();


                        if (ghost == PbBlinky)
                        {
                            Blinky.xPosition = 288;
                            Blinky.yPosition = 276;
                            PbBlinky.Location = new Point(Blinky.xPosition, Blinky.yPosition);
                        }
                        else if (ghost == PbClyde)
                        {
                            Clyde.xPosition = 358;
                            Clyde.yPosition = 275;
                        }
                        else if (ghost == PbInky)
                        {
                            Inky.xPosition = 354;
                            Inky.yPosition = 275;
                            PbInky.Location = new Point(Inky.xPosition, Inky.yPosition);
                        }
                        else if(ghost == PbPinky)
                        {

                        }
                        
                    }
                }
            }
        }


        public async void LoseLife()
        {
            // Checking conditions for losing a life
            if (PacMan.canEatGhost == false)
            {
                //await Task.Delay(10000);

                // Looping through controls to find and dispose of a PictureBox
                foreach (Control control in Controls)
                {


                    if (control is PictureBox && control.Tag != null && control.Tag.ToString() == "Life1" && control.Visible && PacMan.numOfLives == 2)
                    {
                        control.Visible = false; // Disposing the PictureBox control
                        lblLives.Text = $"Lives left {PacMan.numOfLives}";
                        break;
                    }
                    else if (control is PictureBox && control.Tag != null && control.Tag.ToString() == "Life2" && control.Visible && PacMan.numOfLives == 1)
                    {
                        control.Visible = false; // Disposing the PictureBox control
                        lblLives.Text = $"Lives left {PacMan.numOfLives}";
                        break;
                    }
                    else if (control is PictureBox && control.Tag != null && control.Tag.ToString() == "Life3" && control.Visible && PacMan.numOfLives == 0)
                    {
                        control.Visible = false; // Disposing the PictureBox control
                        lblLives.Text = $"Lives left {PacMan.numOfLives}";


                    }
                }
            }

        }

            

      

        private void txtPacManMove_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left && noLeft == false)
            {
                PbPacMan.Image = left;
                PacMan.xPosition -= pacManSpeed; // Move Pac-Man left
                goRight = goUp = goDown = false;
                noRight = noUp = noDown = false;

                goLeft = true;

            }

            else if (e.KeyData == Keys.Right && noRight == false)
            {
                PbPacMan.Image = right;
                PacMan.xPosition += pacManSpeed; // Move Pac-Man right
                goLeft = goUp = goDown = false;
                noLeft = noUp = noDown = false;

                goRight = true;
            }

            else if (e.KeyData == Keys.Up && noUp == false)
            {
                PbPacMan.Image = up;
                PacMan.yPosition -= pacManSpeed; // Move Pac-Man up
                goRight = goUp = goLeft = false;
                noRight = noUp = noLeft = false;

                goUp = true;
            }

            else if (e.KeyData == Keys.Down && noDown == false)
            {
                PbPacMan.Image = down;
                PacMan.yPosition += pacManSpeed; // Move Pac-Man down
                goUp = goLeft = goRight = false;
                noUp = noLeft = noRight = false;

                goDown = true;
            }

            PbPacMan.Location = new Point(PacMan.xPosition, PacMan.yPosition);
            currentLocation = PbPacMan.Location;
            CheckCollisions();
        }

        private void pictureBox97_Click(object sender, EventArgs e)
        {

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

            

            // input details to stop going past game 



            // Update the position of Pac-Man on the form


           
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
            Blinky.CatchPacMan();
              
        }

      
        public void newHighScore()
        {
          
             NewHighScore newHighScore = new NewHighScore(PacMan,this);
             newHighScore.Show();
             Sounds.NewHighScore();

             this.Close();
        }
      

        private void Highscore()
        {
            //score = int.Parse(lblScore.Text); // Parse the current score from a label
            string FilePath = (@"C:\Users\student\OneDrive - Sheffield Hallam University\highscore.txt");

            if (File.Exists(FilePath))
            {
                StreamReader Sr = new StreamReader(FilePath); // Open a StreamReader to read the content of the file
                lblHighScore.Text = Sr.ReadToEnd(); // Read the entire content of the file and set it to a label
                Sr.Close(); // Close the StreamReader

                PacMan.highScore = int.Parse(lblHighScore.Text); // Parse the high score from the label
                int currentScore = Convert.ToInt32(lblScore.Text);  // Parse the current score again (duplicate variable)

                if (currentScore > PacMan.highScore)
                {
                    lblHighScore.Text = currentScore.ToString();
                    StreamWriter Sw = new StreamWriter(FilePath);  // Open a StreamWriter to write to the file
                    Sw.Write(lblHighScore.Text); // Write the current score to the file
                    Sw.Close(); // Close the StreamWriter
                }
            }
            else
            {
                StreamWriter Sw = File.AppendText(FilePath); // Open a StreamWriter to write to the file
                Sw.Write("0");
                Sw.Close(); // Close the StreamWriter
            }
        }




    }
} 
    

