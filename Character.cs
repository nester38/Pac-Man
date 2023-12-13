using System.Security.Cryptography.X509Certificates;
using static Pac_Man.Character.Ghost;

namespace Pac_Man
{
    public class Character
    {
        public PacManSounds Sounds = new PacManSounds();
        public int speed { get; set; }
        public int xPosition { get; set; }
        public int yPosition { get; set; }




        public class Player : Character
        {
            public PictureBox PictureBox { get; set; }
            public bool isPoweredUp { get; set; }
            public int numOfLives { get; set; }
            public bool encounteredGhost { get; set; }

            public Player()
            {
                isPoweredUp = false;
                numOfLives = 3;
                encounteredGhost = false;
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
                xPosition = 323;
                yPosition = 432;
            }


        

        }


        public class Ghost : Character
        {
            // Composition 

            Player PacMan = new Player();


            public PictureBox PictureBox { get; set; } = new PictureBox();
            public bool isFrightened { get; set; }

            public Ghost()
            {
                isFrightened = false;
            }



            public virtual void CatchPacMan(int pacManX, int pacManY)
            {
                if (!isFrightened)
                {
                    // Calculate the direction towards Pac-Man
                    int directionX = pacManX - xPosition;
                    int directionY = pacManY - yPosition;

                    // Adjust the ghost's position towards Pac-Man
                    xPosition += directionX > 0 ? 1 : -1; // Move towards Pac-Man in the X direction
                    yPosition += directionY > 0 ? 1 : -1; // Move towards Pac-Man in the Y direction

                    // Move the PictureBox to the new position on the form
                    PictureBox.Location = new Point(xPosition, yPosition);

                    // Refresh the PictureBox to ensure it's updated on the form
                    PictureBox.Refresh();


            }   }


            // https://stackoverflow.com/questions/23232868/call-function-after-a-period-of-time-in-c-sharp
            public async Task RunAway()
            {
               await Task.Delay(5000);
               PacMan.DeactivatePowerUp();

            }


            public async Task CheckPacManState(bool isPoweredUp)
                {
                    while (!isPoweredUp)
                    {
                        CatchPacMan(xPosition, yPosition);

                        if (isPoweredUp == true)
                    {
                       

                           await RunAway();
                        }

                        else if (isPoweredUp == false)
                        {
                            CatchPacMan(xPosition, yPosition);
                        }
                    }
                    
                } 

            public class Blinky: Ghost
            {
                public override void CatchPacMan(int pacManX, int pacManY)
                {
                    if (!isFrightened)
                    {
                        // Calculate the direction towards Pac-Man
                        int directionX = pacManX - xPosition;
                        int directionY = pacManY - yPosition;

                        // Adjust the ghost's position towards Pac-Man
                        xPosition += directionX > 0 ? 1 : -1; // Move towards Pac-Man in the X direction
                        yPosition += directionY > 0 ? 1 : -1; // Move towards Pac-Man in the Y direction
                    }
                }

             
            }

            public class Inky : Ghost
            {

            }

            public class Pinky : Ghost
            {

            }

            public class Clyde : Ghost
            {

            }

          
        }

    }
}
