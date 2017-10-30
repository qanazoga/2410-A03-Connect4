using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4
{   
    /// <summary>
    /// A representation of the Stones dropped into the Connect4 board.
    /// </summary>
    class Stone
    {
        public Color Color { get; set; }

        public Stone()
        {
            Color = Color.None;
        }

        public Stone(Color color)
        {
            Color = color;
        }
    }

    // Setting the values this way allows us to cast to ConsoleColor and have the colors we want.
    public enum Color { None, Blue = 9, Red = 12 }; 
}
