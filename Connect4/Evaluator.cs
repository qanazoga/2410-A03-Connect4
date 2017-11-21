using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4
{
    /// <summary>
    /// The Evaluator's job is to check for wins, and determine the next available slot in a column for a stone to drop to.
    /// </summary>
    class Evaluator
    {

        GameStateManager gsm = GameStateManager.GetInstance();

        private static Evaluator instance = null;

        private Evaluator()
        {

        }

        public static Evaluator GetInstance()
        {
            if (instance == null)
            {
                instance = new Evaluator();
            }

            return instance;
        }

        public void CheckForWins()
        {
            // It's impossible to win before this point, don't waste time checking for wins.
            if (gsm.PlacedPieces < 7)
                return;

            CheckForHorizontalWins();

            // Again, there's no point in checking for wins vertically before a win that way can be acieved.
            if (gsm.MaxColumnHeight < 4)
                return;

            CheckForVerticalWins();
            CheckForDiagDownWins();
            CheckForDiagUpWins();

        }
        
        public void CheckForHorizontalWins()
        {
            var stonesInRow = 0;
            var last = Color.None;

            for (int i = 0; i < gsm.Grid.GetLength(0); i++)
            {
                for (int j = 0; j < gsm.Grid.GetLength(1); j++)
                {
                    var current = gsm.Grid[i, j].Color;
                    if (current == last && current != Color.None)
                    {
                        stonesInRow++;
                        if (stonesInRow == 3)
                            gsm.GameOver = true;
                    }
                        
                    else
                        stonesInRow = 0;

                    last = gsm.Grid[i, j].Color;
                }
                if (stonesInRow >= 4)
                    gsm.GameOver = true;

            }
        }


        public void CheckForVerticalWins()
        {
            var stonesInCol = 0;
            var last = Color.None;

            for (int i = 0; i < gsm.Grid.GetLength(1); i++)
            {
                for (int j = gsm.Grid.GetLength(0); i >= 0; i--)
                {
                    var current = gsm.Grid[i, j].Color;


                }
            }
        }

        public void CheckForDiagDownWins()
        {
            // TODO
        }

        public void CheckForDiagUpWins()
        {
            // TODO
        }


        public int FindNextAvailableSlot(int col)
        {
            for (int i = 5; i >= 0; i--)
            {
                if (gsm.Grid[i, col].Color == Color.None)
                {
                    return i;
                }
            };
            throw new Exception("That Column is Full!"); // I have no idea how to make my own Exception in this language lol.
        }

    }
}
