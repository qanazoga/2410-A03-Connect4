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
            if (gsm.PlacedPieces < 7) return;
            
            CheckForHorizontalWins();

            // Again, there's no point in checking for wins vertically before a win that way can be acieved.
            if (gsm.MaxColumnHeight < 4) return;
            CheckForVerticalWins();
            CheckForDiagDownWins();
            CheckForDiagUpWins();

        }

        public void CheckForHorizontalWins()
        {
            // TODO
        }

        public void CheckForVerticalWins()
        {
            // TODO
        }

        public void CheckForDiagDownWins()
        {
            // TODO
        }

        public void CheckForDiagUpWins()
        {
            // TODO
        }


    }
}
