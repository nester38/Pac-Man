using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Formats.Asn1.AsnWriter;

namespace Pac_Man
{
    internal class Character
    {
        // constructor 


        // Member variables 
        
        private int Speed = 5;
        private int X = 0;
        private int Y = 0;


        public void StartMovingLeft()
        {
           X = -Speed;
           Y = 0;
        }

        public void StartMovingRight()
        {
            X = Speed;
            Y = 0;
        }
        public void StartMovingUp()
        {
            X = 0;
            Y = -Speed;
        }

        public void StartMovingDown()
        {
            X = 0;
            Y = Speed;
        }

        public void StopMoving()
        {
            X = 0;
            Y = 0;
        }

      


    }
    
}
