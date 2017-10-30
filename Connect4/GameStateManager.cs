using System;

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
        public HeroTurn TurnCycle { get; set; }     
        public int PlacedPieces { get; set; }
        public Boolean GameOver { get; private set; }

        private static GameStateManager instance = null;

        private GameStateManager()
        {
            Random rand = new Random();
            TurnCycle = (HeroTurn)rand.Next(2); // Select a random player to go first.
            PlacedPieces = 0;
            GameOver = false;
        }

        public static GameStateManager GetInstance()
        {
            if (instance == null)
            {
                instance = new GameStateManager();
            }
            return instance;   
        }
    }

    public enum HeroTurn { Hero1, Hero2 }
}
