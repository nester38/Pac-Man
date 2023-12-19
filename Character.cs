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

            public PictureBox PictureBox { get; set; } = new PictureBox();

           // private GhostState currentState;

            public bool isFrightened { get; set; }
            private bool movingRight { get; set; }
            private bool movingUp { get; set; }
            public bool cantMove { get; set; }
            public bool isInGhostHouse { get; set; }

            public Ghost()
            {
               // currentState = GhostState.Left;
                isFrightened = false;
                speed = 3;
                cantMove = false;
                isInGhostHouse = false;
            }



            public virtual void Move()
            {
                // this method is overriden in the subclasses below. 
            }

            public virtual void Respawn()
            {
                // htis method is overriden in the subclasses below.
            }

            public void SendToGhostHouse(int destinationX, int destinationY)
            {
                xPosition = destinationX; // Set the X position for the ghost house
                yPosition = destinationY; // Set the Y position for the ghost house
                PictureBox.Location = new Point(xPosition, yPosition); // Update the PictureBox location
                isInGhostHouse = true; // Set isInGhostHouse to true
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
                        await Task.Delay(9000);
                        isInGhostHouse = false; // Set isInGhostHouse to false after the delay
                    }


                    await StayInGhostHouse();

                   
                        // Calculate the next position based on the current state
                        Point nextPosition = CalculateNextPosition();

                        // Update the position
                        xPosition = nextPosition.X;
                        yPosition = nextPosition.Y;

                        // Update the PictureBox location
                        PictureBox.Location = new Point(xPosition, yPosition);
                    
                }

                private async Task StayInGhostHouse()
                {
                    // Code to stay in the ghost house 
                    await Task.Delay(14000); // 15000 milliseconds 
                    yPosition = 539;
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
                        await Task.Delay(10000);
                        isInGhostHouse = false; // Set isInGhostHouse to false after the delay
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

                public override void Respawn()
                {

                }


            }


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
                        await Task.Delay(9000);
                        isInGhostHouse = false; // Set isInGhostHouse to false after the delay
                    }

                    await StayInGhostHouse();

                        // Calculate the next position based on the current state
                        Point nextPosition = CalculateNextPosition();

                        // Update the position
                        xPosition = nextPosition.X;
                        yPosition = nextPosition.Y;

                        // Update the PictureBox location
                        PictureBox.Location = new Point(xPosition, yPosition);
                    
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

                public override void Respawn()
                {

                }


            }





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
                        // Ghost is in the ghost house, so stop moving for 8 seconds
                        await Task.Delay(9000);
                        isInGhostHouse = false; // Set isInGhostHouse to false after the delay
                    }

                    await StayInGhostHouse();

                        // Calculate the next position based on the current state
                        Point nextPosition = CalculateNextPosition();

                        // Update the position
                        xPosition = nextPosition.X;
                        yPosition = nextPosition.Y;

                        // Update the PictureBox location
                        PictureBox.Location = new Point(xPosition, yPosition);
                    
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


                public override void Respawn()
                {

                }


            }
        }
    }
}
