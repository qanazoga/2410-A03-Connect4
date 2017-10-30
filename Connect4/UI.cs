using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4
{
    /// <summary>
    /// The UI's job is to:
    ///     Map the playing field (grid)
    ///     show the Hero's where they're placing their stones
    ///     inform the Hero's whose turn it is
    ///     
    /// UI implements the singleton design pattern.
    /// </summary>
    class UI
    {
        public Stone[,] Grid { get; set; }
        private GameStateManager gsm = GameStateManager.GetInstance();
        
        private static UI instance;

        private UI()
        {
            Grid = new Stone[6, 7];
            for (int i = 0; i < Grid.GetLength(0); i++)
            {
                for (int j = 0; j < Grid.GetLength(1); j++)
                {
                    Grid[i, j] = new Stone();
                }
            }
        }

        public static UI GetInstance()
        {
            if (instance == null)
            {
                instance = new UI();
            }
            return instance;
        }

        /// <summary>
        /// Redraws the UI, indicates whose turn it is, and where the player is about to place a thier stone.
        /// </summary>
        public void Refresh()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Use the LEFT and RIGHT ARROW KEYS to move\nPress ENTER to drop your piece");
            Console.WriteLine($"It is currently {gsm.TurnCycle}'s turn");
            
            for (int i = 0; i < Grid.GetLength(0); i++)
            {
                for (int j = 0; j < Grid.GetLength(1); j++)
                {
                    Console.BackgroundColor = (ConsoleColor)Grid[i, j].Color;
                    Console.Write("( )");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Places a stone in the given column for whoever's turn it currently is.
        /// </summary>
        /// <remarks>
        /// Okay, the second line on this one (<code>gsm.TurnCycle = (HeroTurn) (1 - (int)gsm.TurnCycle);</code>) can be a bit hard to read.
        /// Let's break it down.
        /// 
        /// <code>gsm.TurnCycle</code> is an Enum, whose underlying value is always 0 or 1.
        /// Casting an Enum as Int will return the underlying value.
        /// 
        /// Next, if we have a number n where n is either 1 or 0
        /// 1 - n will always change n to the other number (ie, if n = 1, 1 - n = 0; if n = 0, 1 - n = 1).
        /// 
        /// So <code>(1 - (int)gsm.TurnCycle)</code> will always evaluate as the opposite value of <code>gsm.TurnCycle</code>.
        /// Next we cast that back to a <code>HeroTurn</code> so we can set <code>gsm.TurnCycle</code>
        /// 
        /// </remarks>
        /// <param name="col"></param>
        public void Place(int col)
        {
            // Create a stone of the current player's color at the base of the given column.
            //TODO: change 0 in next line to the last available slot in the column 
            Grid[0, col] = new Stone(gsm.TurnCycle == HeroTurn.Hero1 ? Color.Red : Color.Blue); // oh no, I hope it doesn't get more complex.
            // Switch the GameStateManager's TurnCycle to the next player's turn.
            gsm.TurnCycle = (HeroTurn) (1 - (int)gsm.TurnCycle);   // WHAT
            Refresh();
        }

    }
}
