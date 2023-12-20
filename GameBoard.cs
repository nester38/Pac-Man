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
using System.Security.Cryptography.X509Certificates;
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
        //https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/properties
        // getters and setters used to encapsulate 
        public bool gameOver = true;
      
        private Point currentLocation { get; set; }


        // Loading ghost images 
        Image left = Image.FromFile(@"C:\Users\student\OneDrive - Sheffield Hallam University\Pictures\pacmanleft.gif");
        Image right = Image.FromFile(@"C:\Users\student\OneDrive - Sheffield Hallam University\Pictures\pacmanright.gif");
        Image up = Image.FromFile(@"C:\Users\student\OneDrive - Sheffield Hallam University\Pictures\pacmanup.gif");
        Image down = Image.FromFile(@"C:\Users\student\OneDrive - Sheffield Hallam University\Pictures\pacmandown.gif");


        // Creating Player and ghost and sound objects
        public Player PacMan = new Player();
        public Ghost.Blinky Blinky = new Ghost.Blinky();
        public Ghost.Pinky Pinky = new Ghost.Pinky();
        public Ghost.Inky Inky = new Ghost.Inky();
        public Ghost.Clyde Clyde = new Ghost.Clyde();
        public PacManSounds Sounds = new PacManSounds();

        // exception handler object 
        ExceptionHandler exceptionHandler = new ExceptionHandler();

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
            Blinky.yPosition = 539; 

            Pinky.xPosition = 193;
            Pinky.yPosition = 275;

            Clyde.xPosition = 461;
            Clyde.yPosition = 275;

            Inky.xPosition = 347;
            Inky.yPosition = 116;

            PacMan.highScore = 0;
            PacMan.score = 0;
            PacMan.speed = 8;

        }





        private void GameBoard_Load(object sender, EventArgs e)
        {
            Sounds.PlayIntro();
            tmrGhosts.Start();
            Highscore();
        }


   
        // used to enhance user experience, able to go back to main menu without restarting the game. 
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();

            SoundPlayer soundPlayer = new SoundPlayer();
            soundPlayer.Stop();

        }


        // used to handle pacman movement, sometimes the gameboard keydowdown event would stop working so used a textbox
        private void txtPacManMove_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left && PacMan.noLeft == false)
            {
                PbPacMan.Image = left;
                PacMan.xPosition -= PacMan.speed; // Move Pac-Man left
                PacMan.goRight = PacMan.goUp = PacMan.goDown = false;
                PacMan.noRight = PacMan.noUp = PacMan.noDown = false;

                PacMan.goLeft = true;

            }

            else if (e.KeyData == Keys.Right && PacMan.noRight == false)
            {
                PbPacMan.Image = right;
                PacMan.xPosition += PacMan.speed; // Move Pac-Man right
                PacMan.goLeft = PacMan.goUp = PacMan.goDown = false;
                PacMan.noLeft = PacMan.noUp = PacMan.noDown = false;

                PacMan.goRight = true;
            }

            else if (e.KeyData == Keys.Up && PacMan.noUp == false)
            {
                PbPacMan.Image = up;
                PacMan.yPosition -= PacMan.speed; // Move Pac-Man up
                PacMan.goRight = PacMan.goUp = PacMan.goLeft = false;
                PacMan.noRight = PacMan.noUp = PacMan.noLeft = false;

                PacMan.goUp = true;
            }

            else if (e.KeyData == Keys.Down && PacMan.noDown == false)
            {
                PbPacMan.Image = down;
                PacMan.yPosition += PacMan.speed; // Move Pac-Man down
               PacMan.goUp = PacMan.goLeft = PacMan.goRight = false;
               PacMan.noUp = PacMan.noLeft = PacMan.noRight = false;

                PacMan.goDown = true;
            }

            PbPacMan.Location = new Point(PacMan.xPosition, PacMan.yPosition);
            currentLocation = PbPacMan.Location;
            CheckCollisions();
        }



        // https://stackoverflow.com/questions/52615078/c-sharp-collision-check-for-picturebox-intersect code used to check collisions.
        // looped through each control to find all those with the tag specified in each if statement then handled collision logic.
        private async Task CheckCollisions()
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

                    PacMan.score += 50;
                    lblScore.Text = Convert.ToString(PacMan.score);
                    Highscore();



                }


                if (control is PictureBox pictureBox2 &&
                    PbPacMan.Bounds.IntersectsWith(pictureBox2.Bounds) &&
                    pictureBox2.Tag != null && pictureBox2.Tag.ToString() == "special_point" && pictureBox2.Visible)
                {
                    // Handle collision with the point logic here
                    // Hide the PictureBox with the "point" tag
                    pictureBox2.Visible = false;

                    PacMan.score += 100;
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
                        await Blinky.RunAway();
                        await Clyde.RunAway();
                        await Pinky.RunAway();
                        await Inky.RunAway();

                        await Task.Delay(10000);

                        PacMan.DeactivatePowerUp();

                        // Load normal ghost images after 4 second delay 
                        PbBlinky.LoadAsync(@"C:\Users\student\OneDrive - Sheffield Hallam University\Pictures\enemy_3.gif");
                        PbPinky.LoadAsync(@"C:\Users\student\OneDrive - Sheffield Hallam University\Pictures\enemy_1.gif");
                        PbInky.LoadAsync(@"C:\Users\student\OneDrive - Sheffield Hallam University\Pictures\enemy_4.gif");
                        PbClyde.LoadAsync(@"C:\Users\student\OneDrive - Sheffield Hallam University\Pictures\enemy_2.gif");


                    }

                }

                // struggled with implementing collision with wall 
                // used this tutorial and adapted noGoUp/goUp etc boolean variables to stop movement when bounds meet. 
                //https://www.youtube.com/watch?v=fdw-HGIMZFY  @19 seconds 

                if (control is PictureBox pictureBox3 &&
                    PbPacMan.Bounds.IntersectsWith(pictureBox3.Bounds) &&
                    pictureBox3.Tag != null &&
                    pictureBox3.Tag.ToString() == "wall")

                {   
                  if (PacMan.goLeft == true)
                    {
                        PacMan.noLeft = true;
                        PacMan.goLeft = false;
                    }


                  if (PacMan.goRight == true)
                    {
                        PacMan.noRight = true;
                        PacMan.goLeft = true;
                    }


                  if (PacMan.goUp == true)
                    {
                        PacMan.noUp = true;
                        PacMan.goUp = true;
                    }


                  if (PacMan.goDown == true)
                    {
                        PacMan.noDown = true;
                        PacMan.goDown = true;
                    }


                }

                // Handling collision with ghosts. Looping over control collection to find picturebox with tag ghost. 
                // PacMan respawns if he still has lives, if not game over function if called. 
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

                        PacMan.noDown = PacMan.noLeft = PacMan.noRight = PacMan.noUp = true;
                        PacMan.Respawn();


                        if (PacMan.numOfLives == 0)
                        {
                            // highscore mechanism 
                            if (PacMan.score >= PacMan.highScore)
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

                        // add 200 to score when ghost is eaten.
                        PacMan.score += 200;
                        lblScore.Text = Convert.ToString(PacMan.score);  // Update the label with the new score
                        Highscore();

                        
                        // Send ghost to ghost house when eaten by pacman,
                        // function takes parameters which is the position in the ghost house for each ghost. 
                        if (ghost == PbBlinky)
                        {
                            Blinky.SendToGhostHouse(285, 261);
                        }
                        else if (ghost == PbClyde)
                        {
                            Clyde.SendToGhostHouse(339, 257);
                        }
                        else if (ghost == PbInky)
                        {
                            Inky.SendToGhostHouse(362, 276);
                        }
                        else if(ghost == PbPinky)
                        {
                            Pinky.SendToGhostHouse(309, 278);
                        }
                        
                    }
                }
            }
        }



        // creates dynamic message box when game ends 
        public async void GameOver()
        {
            await Task.Delay(100);
       
            string message ="Would you like to play again?";
            string title = "Game Over";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
             
            // if user clicks yes a new game is loaded, if no the game closes. 
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




        public void LoseLife()
        {
            // Checking conditions for losing a life
            if (PacMan.canEatGhost == false)
            {

                foreach (Control control in Controls)
                {


                    if (control is PictureBox && control.Tag != null && control.Tag.ToString() == "Life1" && control.Visible && PacMan.numOfLives == 2)
                    {
                        control.Visible = false; // hide picturebox
                        lblLives.Text = $"Lives left {PacMan.numOfLives}";
                        break;
                    }
                    else if (control is PictureBox && control.Tag != null && control.Tag.ToString() == "Life2" && control.Visible && PacMan.numOfLives == 1)
                    {
                        control.Visible = false; // hide picturebox
                        lblLives.Text = $"Lives left {PacMan.numOfLives}";
                        break;
                    }
                    else if (control is PictureBox && control.Tag != null && control.Tag.ToString() == "Life3" && control.Visible && PacMan.numOfLives == 0)
                    {
                        control.Visible = false; // hide picturebox
                        lblLives.Text = $"Lives left {PacMan.numOfLives}";


                    }
                }
            }

        }






        // Ghost timer used to move ghosts around. Each object calls the move method defined in its respctive class. 
        private void tmrGhosts_Tick(object sender, EventArgs e)
        {
            Blinky.Move();
            Clyde.Move();
            Inky.Move();
            Pinky.Move();
        }

      // show highscore form 
        public void newHighScore()
        {
          
             NewHighScore newHighScore = new NewHighScore(PacMan,this);
             newHighScore.Show();
             Sounds.NewHighScore();

             this.Close();
        }


        // File IO - used to save players highscore
        // https://learn.microsoft.com/en-us/dotnet/standard/io/how-to-write-text-to-a-file
        private void Highscore()
        {
           
            string filePathHighScore = (@"C:\Users\student\OneDrive - Sheffield Hallam University\highscore.txt");

            if (File.Exists(filePathHighScore))
            {
                // Read the highscore from the file
                using StreamReader Sr = new StreamReader(filePathHighScore); 
                lblHighScore.Text = Sr.ReadToEnd(); // Read the content of the file and set it to highscore label
                Sr.Close(); 

                PacMan.highScore = int.Parse(lblHighScore.Text); // Parse the high score from the label
                int currentScore = Convert.ToInt32(lblScore.Text);  // Parse the current score again 


                // Update highscore if the current score is higher
                if (currentScore > PacMan.highScore)
                {
                    lblHighScore.Text = currentScore.ToString();
                    using StreamWriter Sw = new StreamWriter(filePathHighScore); // add exception handling here (stream writer being used by other)
                    Sw.Write(lblHighScore.Text); // Write the highscore to the file
                    Sw.Close(); 
                }
            }
            else
            {
                // Create the file if it doesn't exist & write value of "0" to it 
                try
                {
                    File.WriteAllText(filePathHighScore, "0");
                }
                catch
                {
                    // if exceptioon occurs it is logged in the exception handler file 
                    exceptionHandler.WriteErrorToFile(exceptionHandler.filePath);
                }
            }
        }


        /* // Evidence of tesing
         * 
        public void RunTests()
        {
            DeactivatePowerUp();
            TestLoseLife();
        }

        private void DeactivatePowerUp()
        {
            var gameBoard = new GameBoard();
            gameBoard.PacMan.isPoweredUp = true;


            gameBoard.PacMan.DeactivatePowerUp();
            // Log the test result 
            LogTestResult("DeactivatePowerUp", gameBoard.PacMan.isPoweredUp == false);
        }

        private void TestLoseLife()
        {
            var gameBoard = new GameBoard();
            gameBoard.PacMan.numOfLives = 3;

            gameBoard.LoseLife();
            LogTestResult("TestLoseLife", gameBoard.PacMan.numOfLives == 2);
        }


        // function sends results to exception handler file 
        private void LogTestResult(string testName, bool isWorking)
        {
            string result = $"{testName}: {(isWorking ? "Yes" : "No")}";

            // write to exception handler file
            exceptionHandler.WriteTestResultToFile(result);
        }
        */

    }
} 
    

