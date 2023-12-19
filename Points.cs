using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pac_Man
{
    internal class Points
    {

        public enum FruitType
        {
            Cherry,
            Strawberry,
            Orange,
            Apple,
            Banana
        }

        public Points()
        {
            Score = 0; 
        }
        public int Score { get; set; } 

        public void AddPoints(int points)
        {
            Score += points;
        }


        // small points 
        public int AddSmallPelletPoint()
        {
            return 10;
        }

        // large (special points)
        public int AddLargePelletPoint()
        {
            return 20;
        }



        // Learned about enums in C# from w3schools website:
        // https://www.w3schools.com/cs/cs_enums.php
        public int AddFruitPoint(FruitType fruitType)
        {
            switch (fruitType)
            {
                case FruitType.Cherry:
                    return 100;

                case FruitType.Strawberry:
                    return 200;
                // Add more cases for other fruit types...

                case FruitType.Orange:
                    return 500;

                case FruitType.Apple:
                    return 700;

                case FruitType.Banana:
                    return 1000;


                default:
                    return 0; // Default case, in case of an unknown fruit type
            }
        }
    }
}
