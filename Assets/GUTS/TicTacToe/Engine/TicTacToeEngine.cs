using System;
using System.Collections.Generic;

namespace GUTS.TicTacToe.Engine
{
    public class TicTacToeEngine
    {
        private BoardState _boardState = new();
        private GameRules _gameRules = new();

        private Player _currentPlayer;

        public GameResult GetGameResult() => _winInfo.result;
        public Position[] GetWinningPositions() => _winInfo.winningPositions;

        private WinInfo _winInfo;

        private readonly Random _random = new();

        public void StartNewGame()
        {
            _boardState.NewGame();
            _currentPlayer = (Player)_random.Next(0, 2);
            _winInfo.result = GameResult.Ongoing;
            _winInfo.winningPositions = Array.Empty<Position>();
        }

        public Player CurrentPlayer => _currentPlayer;

        public Position[] GetValidMoves(Player player)
        {
            List<Position> moves = new();

            for (int i = 0; i < _boardState.Length; i++)
            {
                if (_boardState[i] == Player.None)
                {
                    Position position = BoardState.IndexToPosition(i);
                    moves.Add(position);
                }
            }

            return moves.ToArray();
        }

        public Player[] GetPlayerGrid() => _boardState.GetPlayerGrid();

        public bool TryMakeMove(int index) => TryMakeMove(BoardState.IndexToPosition(index));

        public bool TryMakeMove(Position position)
        {
            if (!CanMakeMove(position))
                return false;

            _boardState[position] = _currentPlayer;

            _winInfo = _gameRules.Evaluate(_boardState);

            if (_winInfo.result == GameResult.Ongoing)
                ActivateNextPlayer();

            return true;
        }

        private void ActivateNextPlayer()
        {
            _currentPlayer = (_currentPlayer == Player.O) ? Player.X : Player.O;
        }

        public bool CanMakeMove(int index) => CanMakeMove(BoardState.IndexToPosition(index));

        public bool CanMakeMove(Position position)
        {
            if (_winInfo.result != GameResult.Ongoing)
                return false;

            Player player = _boardState[position];
            return (player == Player.None);
        }
    }
}
