using GUTS.TicTacToe.Engine;
using System;

namespace GUTS.TicTacToe.Unity
{
    public static class TicTacToeEvents
    {
        public static Action OnNewGame;
        public static Action<Position, Player> OnMoveMade;
        public static Action<Position, Player> OnMoveRejected;
        public static Action OnGameEnding;
        public static Action<GameResult> OnGameOver;
    }
}
