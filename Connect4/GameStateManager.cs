using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4
{
    /// <summary>
    /// The GameStateManager keeps track of various things, such as:
    ///     whose turn it is
    ///     how many pieces have been placed (in case the board fills up)
    ///     the highest a column is stacked (to save evaluation time)
    ///     and if the game is over.
    ///     
    /// It implements the singleton design pattern.
    /// </summary>
    class GameStateManager
    {
        public PlayerTurn TurnCycle { get; set; }
        public int PlacedPieces { get; set; }
        public int MaxColumnHeight { get; set; }
        public Boolean GameOver { get; set; }
        public Stone[,] Grid { get; set; }
        public bool AcceptingInput { get; set; }

        private static GameStateManager instance = null;

        /// <summary>
        /// Returns the single instance of the GameStateManager.
        /// </summary>
        private GameStateManager()
        {
            Random rand = new Random();
            TurnCycle = (PlayerTurn)rand.Next(0, 2); // Select a random player to go first, wouldn't pick 0 unless I included it ¯\_(ツ)_/¯
            PlacedPieces = 0;
            GameOver = false;
            Grid = new Stone[6, 7];
            AcceptingInput = false;
            for (int i = 0; i < Grid.GetLength(0); i++)
            {
                for (int j = 0; j < Grid.GetLength(1); j++)
                {
                    Grid[i, j] = new Stone();
                }
            }
        }

        public static GameStateManager GetInstance()
        {
            if (instance == null)
            {
                instance = new GameStateManager();
            }
            return instance;
        }

        public void NextTurn()
        {
            TurnCycle = (PlayerTurn)(1 - (int)TurnCycle);
        }
    }

    public enum PlayerTurn { Player1, Player2 }
}
