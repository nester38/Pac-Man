using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Pac_Man
{
    internal class Ghost
    {

        public int xPosition { get; set; }

        public int yPosition { get; set; }


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
