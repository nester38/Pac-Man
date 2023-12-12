using System.Security.Cryptography.X509Certificates;

namespace Pac_Man
{
    public class Character
    {

        public int speed { get; set; }
        public int xPosition { get; set; }
        public int yPosition { get; set; }




        public class Player: Character
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
                PacManSounds powerup = new PacManSounds();
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

        public void RunAway()
        {

        }


        public class Ghost : Character
        {
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



                public void CheckPacManState(bool isPoweredUp)
                {
                    while (!isPoweredUp)
                    {
                        CatchPacMan(xPosition, yPosition);

                        if (isPoweredUp == true)
                        {
                            RunAway();
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
