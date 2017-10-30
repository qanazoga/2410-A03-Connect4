using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4
{
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

    public enum Color { None, Blue = 9, Red = 12 }; // Black magic in the works.
}
