using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Pac_Man
{
    internal class Enemies
    {

        // using c# properties instead of directly exposing fields for better encapsulation
        public Vector2 Position { get; set; }  // vector 2 is a type for representing two-dimensional coordinates.
        public int Speed { get; set; } // get; set; syntax allows getting and setting the property's value.






        public string Behavior { get; set; } = "chase"; // Default behavior is chase
        public Vector2 ScatterTarget { get; set; } = Vector2.Zero; // Default scatter target
        public bool IsFrightened { get; set; } = false;
        public int FrightenedTimer { get; set; } = 0;
        public Vector2 Direction { get; set; } = Vector2.Zero;






        // Methods for enemy behavior
        public void Move(Vector2 targetPosition)
        {
            // Logic for enemy movement based on behavior
        }
    }
}
