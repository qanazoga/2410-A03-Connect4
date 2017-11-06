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
            Console.Title = "Connect4";
            Grid = new Stone[6, 7];
            for (int i = 0; i < Grid.GetLength(0); i++)
            {
                for (int j = 0; j < Grid.GetLength(1); j++)
                {
                    Grid[i, j] = new Stone();
                }
            }
        }

        /// <summary>
        /// Returns the single instance of the UI.
        /// </summary>
        /// <returns>UI</returns>
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
        /// <param name="column"></param>
        public void Place(int column)
        {
            // Create a stone of the current player's color at the base of the given column.
            //TODO: change 0 in next line to the last available slot in the column 
            Grid[0, column] = new Stone(gsm.TurnCycle == HeroTurn.Hero1 ? Color.Red : Color.Blue);
            gsm.NextTurn();
            Refresh();
        }

    }
}
