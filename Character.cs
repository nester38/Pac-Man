using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using static Pac_Man.Character.Ghost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Pac_Man
{
    public class Character
    {
        public PacManSounds Sounds = new PacManSounds();
        public int speed { get; set; }
        public int xPosition { get; set; }
        public int yPosition { get; set; }
        public bool noLeft, noRight, noUp, noDown;



        public class Player : Character
        {
            public PictureBox PictureBox { get; set; }
            public bool isPoweredUp { get; set; }
            public int numOfLives { get; set; }
            public bool canEatGhost { get; set; }

            public int highScore = 0;

            public Player()
            {
                isPoweredUp = false;
                numOfLives = 3;
                canEatGhost = false;
            }

            public void ActivatePowerUp()
            {
                isPoweredUp = true;
                Sounds.PowerUp();
            }

            public void DeactivatePowerUp()
            {
                isPoweredUp = false;
            }


            public void Respawn()
            {
                // Logic for respawning
                xPosition = 330;
                yPosition = 434;
            }




        }


        public class Ghost : Character
        {
            // Composition 

            //private Player PacMan;
            Player PacMan = new Player();

            public enum GhostState
            {
                Up,
                Down,
                Left,
                Right
            }

            public int speed = 3;

            private List<Point> junctionPoints = new List<Point>
            {
                new Point (288, 275),
                new Point (300, 233),
                new Point(288, 326),

            };

            public PictureBox PictureBox { get; set; } = new PictureBox();

            private GhostState currentState;

            public bool isFrightened { get; set; }

            public Ghost()
            {
                currentState = GhostState.Left;
                isFrightened = false;
            }



            public virtual void CatchPacMan()
            {


            }

            public virtual void Respawn()
            {

            }

            // https://stackoverflow.com/questions/23232868/call-function-after-a-period-of-time-in-c-sharp
            public async Task RunAway()
            {
                isFrightened = true;
                PacMan.canEatGhost = true;

                await Task.Delay(10000);
                PacMan.DeactivatePowerUp();

                isFrightened = false;
                PacMan.canEatGhost = false;

            }

            public async Task CheckPacManState(bool isPoweredUp)
            {
                while (!isPoweredUp)
                {
                    CatchPacMan();

                    if (isPoweredUp == true)
                    {


                        await RunAway();
                    }

                    else if (isPoweredUp == false)
                    {
                        CatchPacMan();
                    }
                }

            }


            public class Blinky : Ghost
            {
                private bool movingRight = true;

                public override async void CatchPacMan()
                {
                    await StayInGhostHouse();

                    if (!isFrightened)
                    {
                        // Calculate the next position based on the current state
                        Point nextPosition = CalculateNextPosition();

                        // Update the position
                        xPosition = nextPosition.X;
                        yPosition = nextPosition.Y;

                        // Update the PictureBox location
                        PictureBox.Location = new Point(xPosition, yPosition);
                    }
                }

                private async Task StayInGhostHouse()
                {
                    // Code to stay in the ghost house 
                    await Task.Delay(18000); // 15000 milliseconds 
                    xPosition = 193;
                }

                private Point CalculateNextPosition()
                {
                    // Calculate and return the next position based on the current state and speed
                    if (movingRight)
                    {
                        xPosition += speed;
                        if (xPosition >= 550)
                        {
                            movingRight = false;
                        }
                    }
                    else
                    {
                        xPosition -= speed;
                        if (xPosition <= 115)
                        {
                            movingRight = true;
                        }
                    }

                    return new Point(xPosition, yPosition);
                }
            }




            public class Inky : Ghost
            {
                private bool movingRight = false;

                public override void CatchPacMan()
                {
                    if (!isFrightened)
                    {
                        // Calculate the next position based on the current state
                        Point nextPosition = CalculateNextPosition();

                        // Update the position
                        xPosition = nextPosition.X;
                        yPosition = nextPosition.Y;

                        // Update the PictureBox location
                        PictureBox.Location = new Point(xPosition, yPosition);
                    }
                }

                private Point CalculateNextPosition()
                {
                    // Calculate and return the next position based on the current state and speed
                    if (movingRight)
                    {
                        xPosition += speed;
                        if (xPosition >= 550)
                        {
                            movingRight = false;
                        }
                    }
                    else
                    {
                        xPosition -= speed;
                        if (xPosition <= 115)
                        {
                            movingRight = true;
                        }
                    }

                    return new Point(xPosition, yPosition);
                }
            }


            public class Pinky : Ghost
            {
                private bool movingUp = true;

                public override async void CatchPacMan()
                {
                    await StayInGhostHouse();

                    if (!isFrightened)
                    {
                        // Calculate the next position based on the current state
                        Point nextPosition = CalculateNextPosition();

                        // Update the position
                        xPosition = nextPosition.X;
                        yPosition = nextPosition.Y;

                        // Update the PictureBox location
                        PictureBox.Location = new Point(xPosition, yPosition);
                    }
                }
                private async Task StayInGhostHouse()
                {
                    // Code to stay in the ghost house 
                    await Task.Delay(14000); // 15000 milliseconds 
                    xPosition = 193;
                }

                private Point CalculateNextPosition()
                {
                    // Calculate and return the next position based on the current state and speed
                    if (movingUp)
                    {
                        yPosition += speed;
                        if (yPosition >= 550)
                        {
                            movingUp = true;
                        }
                    }
                    else
                    {
                        yPosition -= speed;
                        if (yPosition <= 115)
                        {
                            movingUp = false;
                        }
                    }

                    return new Point(xPosition, yPosition);
                }
            }





            public class Clyde : Ghost
            {
                private bool movingUp = true;

                public override async void CatchPacMan()
                {

                    await StayInGhostHouse();

                    if (!isFrightened)
                    {
                        // Calculate the next position based on the current state
                        Point nextPosition = CalculateNextPosition();

                        // Update the position
                        xPosition = nextPosition.X;
                        yPosition = nextPosition.Y;

                        // Update the PictureBox location
                        PictureBox.Location = new Point(xPosition, yPosition);
                    }
                }

                private async Task StayInGhostHouse()
                {
                    // Code to stay in the ghost house 
                    await Task.Delay(7000); // 7000 milliseconds 
                    xPosition = 459;                
                }

                private Point CalculateNextPosition()
                {
                    // Calculate and return the next position based on the current state and speed
                    if (movingUp)
                    {
                        yPosition -= speed;
                        if (yPosition <= 55)
                        {
                            movingUp = false;
                        }
                    }
                    else
                    {
                        yPosition += speed;
                        if (yPosition >= 485)
                        {
                            movingUp = true;
                        }
                    }

                    // Return the updated position
                    return new Point(xPosition, yPosition);
                }





            }
        }
    }
}
