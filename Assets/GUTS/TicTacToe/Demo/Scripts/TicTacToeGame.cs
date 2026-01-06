using GUTS.TicTacToe.Engine;
using UnityEngine;

namespace GUTS.TicTacToe.Unity
{
    public class TicTacToeGame : MonoBehaviour
    {
        private readonly TicTacToeEngine _ticTacToeEngine = new();

        public Player CurrentPlayer => _ticTacToeEngine.CurrentPlayer;

        public void StartNewGame() => _ticTacToeEngine.StartNewGame();

        public bool MakeMove(int index) => _ticTacToeEngine.TryMakeMove(index);

        public GameResult GetGameResult() => _ticTacToeEngine.GetGameResult();
        public Position[] GetWinningPositions() => _ticTacToeEngine.GetWinningPositions();

        public Player[] GetPlayerGrid() => _ticTacToeEngine.GetPlayerGrid();
    }
}
