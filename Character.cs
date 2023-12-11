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
            }
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

                    Console.WriteLine($"Ghost Position: ({xPosition}, {yPosition})");
                    Console.WriteLine($"PictureBox Location: {PictureBox.Location}");
            }   }



                public void CheckPacManState(bool isPoweredUp)
                {
                    while (!isPoweredUp)
                    {
                        CatchPacMan(0, 0);
                    }
                } 

            public class Blinky: Ghost
            {

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
