using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Formats.Asn1.AsnWriter;

namespace Pac_Man
{
    public class Character
    {

        public int speed { get; set; }
        public int xPosition { get; set; }

        public int yPosition { get; set; }
        public Player PacMan = new Player();

        public Ghost ghost = new Ghost();

        public Character()
        {

        }

        // Child class of character 
        public class Player : Character
        {
            public PictureBox PictureBox { get; set; } 

            public bool isPoweredUp { get; set; }
            public int numOfLives { get; set; }
            public bool encounteredGhost { get; set; }
            


            //Constructor
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

            }



        }
        public class Ghost : Character
        {
            public PictureBox PictureBox { get; set; } 
            public bool isFrightened { get; set; }

                public Ghost()
                {
                    isFrightened = false;
                }

                public virtual void CatchPacMan(int pacManX, int pacManY)
                {
                    if (!isFrightened)
                    {
                        Random random = new Random();
                        xPosition = random.Next();
                        yPosition = random.Next();
                    }
                }

                public void CheckPacManState(bool isPoweredUp)
                {
                    while (!isPoweredUp)
                    {
                        CatchPacMan(0, 0);
                    }
                }



                class Blinky : Ghost
                {
                    public Blinky()
                    {

                    }

                }

                class Inky : Ghost
                {
                    public Inky()
                    {

                    }

                }


                class Pinky : Ghost
                {
                    public Pinky()
                    {

                    }
                }

                class Clyde : Ghost
                {
                    public Clyde()
                    {

                    }
                }




            
        }
    }
}
