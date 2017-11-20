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
    ///     show the Player's where they're placing their stones
    ///     inform the Player's whose turn it is
    ///     
    /// UI implements the singleton design pattern.
    /// </summary>
    class UI
    {
        private GameStateManager gsm = GameStateManager.GetInstance();
        private Evaluator evaluator = Evaluator.GetInstance();
        
        private static UI instance;

        private UI()
        {
            Console.Title = "Connect4";
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
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Use the LEFT and RIGHT ARROW KEYS to move\nPress ENTER to drop your piece");
            Console.WriteLine($"It is currently {gsm.TurnCycle}'s turn");
            
            for (int i = 0; i < gsm.Grid.GetLength(0); i++)
            {
                for (int j = 0; j < gsm.Grid.GetLength(1); j++)
                {
                    Console.BackgroundColor = (ConsoleColor) gsm.Grid[i, j].Color;
                    Console.Write("( )");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            if (!gsm.GameOver)
                gsm.AcceptingInput = true;
        }

        /// <summary>
        /// Places a stone in the given column for whoever's turn it currently is.
        /// </summary>
        /// <param name="column"></param>
        public void Place(int column)
        {
            // Create a stone of the current player's color at the base of the given column.
            // If a stone can't be placed in the slot, an alert beep will be played.
            try 
            {
                gsm.Grid[evaluator.FindNextAvailableSlot(column), column] = new Stone(gsm.TurnCycle == PlayerTurn.Player1 ? Color.Red : Color.Blue);
            } catch (Exception) 
            {
                Console.Beep();
            }
            gsm.NextTurn();
            Refresh();
        }

    }
}
