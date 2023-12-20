using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using static Pac_Man.Character.Ghost;
using static System.Formats.Asn1.AsnWriter;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Pac_Man
{
    public class Character
    {
        public PacManSounds Sounds = new PacManSounds();
        public int speed { get; set; }
        public int xPosition { get; set; }
        public int yPosition { get; set; }


        // Flags for blocking movement in specific directions
        public bool noLeft { get; set; }
        public bool noRight { get; set; }
        public bool noUp { get; set; }
        public bool noDown { get; set; }

        public bool goLeft { get; set; }
        public bool goRight { get; set; }
        public bool goUp { get; set; }
        public bool goDown { get; set; }



        public class Player : Character
        {
            public PictureBox PictureBox { get; set; }
            public bool isPoweredUp { get; set; }
            public int numOfLives { get; set; }
            public bool canEatGhost { get; set; }

            public int highScore { get; set; }
            public int score { get; set; }


        // constructor 
        public Player()
            {
                isPoweredUp = false;
                numOfLives = 3;
                canEatGhost = false;
                highScore = 0;
                score = 0;
                noLeft = noRight = noUp = noDown = false;
                goLeft = goRight = goUp = goDown = false;
            }

            // Mmeber functions 
            public void ActivatePowerUp()
            {
                isPoweredUp = true;
                Sounds.PowerUp();
            }

            public void DeactivatePowerUp()
            {
                isPoweredUp = false;
            }


            public async Task Respawn()
            {
                // Logic for respawning
                xPosition = 330;
                yPosition = 434;

                await Task.Delay(1000);

                noDown = noLeft = noRight = noUp = false;

            }




        }


        public class Ghost : Character
        {
            // Composition 
            Player PacMan = new Player();

            public enum GhostState
            {
                Up,
                Down,
                Left,
                Right
            }

            public PictureBox PictureBox { get; set; } = new PictureBox();

            public bool isFrightened { get; set; }
            private bool movingRight { get; set; }
            private bool movingUp { get; set; }
            public bool cantMove { get; set; }
            public bool isInGhostHouse { get; set; }


            // Constructor 
            public Ghost()
            {
               // currentState = GhostState.Left;
                isFrightened = false;
                speed = 3;
                cantMove = false;
                isInGhostHouse = false;
            }

            
               public  async Task StayInGhostHouse(int stayDuration)
               {
                   // Ghost stays in the ghost house for the specified duration
                   await Task.Delay(stayDuration);

               }



            public virtual void Move()
            {
                // this method is overriden in the subclasses below. 
            }


            public void SendToGhostHouse(int destinationX, int destinationY)
            {
                xPosition = destinationX; // new X position for the ghost house
                yPosition = destinationY; // new Y position for the ghost house
                PictureBox.Location = new Point(xPosition, yPosition); // Update the PictureBox location
                isInGhostHouse = true; // isInGhostHouse is then set to true
            }


            // https://stackoverflow.com/questions/23232868/call-function-after-a-period-of-time-in-c-sharp
            public async Task RunAway()
            {
                isFrightened = true;
                PacMan.canEatGhost = true;

                await Task.Delay(1500);
                PacMan.DeactivatePowerUp();

                isFrightened = false;
                PacMan.canEatGhost = false;

            }

            // Method stops ghosts moving when in the ghost house 
            public void CantMove()
            {
                if (isInGhostHouse)
                {
                    cantMove = true;
                }
                else
                {
                    cantMove = false;
                }
            }

            // While loop is used to continuously check if PacMan is in powered up state or not.
            // If he is ghosts will become frightened & call runaway if not they will try to chase. 
            public async Task CheckPacManState(bool isPoweredUp)
            {
                while (!isPoweredUp || isPoweredUp )
                {
                    Move();

                    if (isPoweredUp == true)
                    {


                        await RunAway();
                    }

                    else if (isPoweredUp == false)
                    {
                        Move();
                    }
                }

            }

            // Blinky derived class 
            public class Blinky : Ghost
            {

                public Blinky()
                {
                    movingRight = true;
                    cantMove = false;
                    
                }
                
                //Blinky Implementation of Move()
                public override async void Move()
                {
                    if (cantMove == true)
                    {
                        // If cantMove is true, stop the movement logic
                        return;
                    }

                    if (isInGhostHouse)
                    {
                        // Ghost is in the ghost house, so stop moving for 9 seconds
                        await Task.Delay(15000);
                        isInGhostHouse = false;// ghost then leaves after 9 seconds 
                    }

                   
                        // Calculate the next position based on the current state
                        Point nextPosition = CalculateNextPosition();

                        // Update the position
                        xPosition = nextPosition.X;
                        yPosition = nextPosition.Y;

                        // Update the PictureBox location
                        PictureBox.Location = new Point(xPosition, yPosition);
                    
                }

                /*
                public  async Task StayInGhostHouse()
                {
                    // Blinky leaves ghost house after 14 seconds
                    await Task.Delay(14000); // 15000 milliseconds 
                    yPosition = 539;
                }
                */

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



            // Blinky derived class 
            public class Inky : Ghost
            {

                public Inky()
                {
                    movingRight = false;
                    cantMove = false;
                }

                public override async void Move()
                {
                    if (cantMove == true)
                    {
                        // If cantMove is true, stop the movement logic
                        return;
                    }

                    if (isInGhostHouse)
                    {
                        // Ghost is in the ghost house, so stop moving for 8 seconds
                        await Task.Delay(15000);
                        isInGhostHouse = false; // ghost then leaves after 9 seconds 
                        yPosition = 116;
                    }

                    // Calculate the next position based on the current state
                    Point nextPosition = CalculateNextPosition();

                        // Update the position
                        xPosition = nextPosition.X;
                        yPosition = nextPosition.Y;

                        // Update the PictureBox location
                        PictureBox.Location = new Point(xPosition, yPosition);
                   
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


            // Pinky derived class 
            public class Pinky : Ghost
            {
                public Pinky()
                {
                    movingUp = false;
                    cantMove = false;
                    
                } 

                public override async void Move()
                {
                    if (cantMove == true)
                    {
                        // If cantMove is true, stop the movement logic
                        return;
                    }

                    if (isInGhostHouse)
                    {
                        // Ghost is in the ghost house, so stop moving for 8 seconds
                        await Task.Delay(15000);
                        isInGhostHouse = false; // ghost then leaves after 9 seconds 
                        xPosition = 193;
                    }

                   // await StayInGhostHouse();

                        // Calculate the next position based on the current state
                        Point nextPosition = CalculateNextPosition();

                        // Update the position
                        xPosition = nextPosition.X;
                        yPosition = nextPosition.Y;

                        // Update the PictureBox location
                        PictureBox.Location = new Point(xPosition, yPosition);
                    
                }

                /*
                private async Task StayInGhostHouse()
                {
                    // Code to stay in the ghost house 
                    await Task.Delay(18000); // 15000 milliseconds 
                    xPosition = 193;
                }

                */ 

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

                    return new Point(xPosition, yPosition);
                }


            }




            // Clyde derived class 
            public class Clyde : Ghost
            {
                public Clyde()
                {
                    movingUp = false;
                    cantMove = false;
                    
                }

                public override async void Move()
                {
                    if (cantMove == true)
                    {
                        // If cantMove is true, stop the movement logic
                        return;
                    }

                    if (isInGhostHouse)
                    {
                        // Ghost is in the ghost house, so stop moving for 9 seconds
                        await Task.Delay(15000);
                        isInGhostHouse = false; // ghost then leaves after 9 seconds 
                        xPosition = 461;
                    }

                   // await StayInGhostHouse();

                        // Calculate the next position based on the current state
                        Point nextPosition = CalculateNextPosition();

                        // Update the position
                        xPosition = nextPosition.X;
                        yPosition = nextPosition.Y;

                        // Update the PictureBox location
                        PictureBox.Location = new Point(xPosition, yPosition);
                    
                }

                /*
                private async Task StayInGhostHouse()
                {
                    // Clyde leaves ghost house after 7 seconds 
                    await Task.Delay(7000); // 7000 milliseconds 
                    xPosition = 459;                
                }
                */

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
