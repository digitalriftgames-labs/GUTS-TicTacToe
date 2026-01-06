using System.Collections.Generic;
using System.Linq;

namespace GUTS.TicTacToe.Engine
{
    internal class GameRules
    {
        // All 8 winning lines (3 rows, 3 columns, 2 diagonals)
        private static readonly (Position a, Position b, Position c)[] WinningLines =
        {
            // Rows
            (new Position(0,0), new Position(1,0), new Position(2,0)),
            (new Position(0,1), new Position(1,1), new Position(2,1)),
            (new Position(0,2), new Position(1,2), new Position(2,2)),

            // Columns
            (new Position(0,0), new Position(0,1), new Position(0,2)),
            (new Position(1,0), new Position(1,1), new Position(1,2)),
            (new Position(2,0), new Position(2,1), new Position(2,2)),

            // Diagonals
            (new Position(0,0), new Position(1,1), new Position(2,2)),
            (new Position(2,0), new Position(1,1), new Position(0,2))
        };

        internal WinInfo Evaluate(BoardState boardState)
        {
            List<Position> winningPositions = new();
            Player winner = Player.None;

            // Check for all winning lines
            foreach (var (a, b, c) in WinningLines)
            {
                Player p = boardState[a];
                if (p != Player.None && p == boardState[b] && p == boardState[c])
                {
                    // Record the winner (X or O)
                    winner = p;

                    // Add all 3 positions (duplicates allowed for now)
                    winningPositions.Add(a);
                    winningPositions.Add(b);
                    winningPositions.Add(c);
                }
            }

            // Found a winner
            if (winner != Player.None)
            {
                Position[] uniquePositions = winningPositions.Distinct().ToArray(); // Deduplicate positions (important when lines overlap)
                GameResult result = (winner == Player.X) ? GameResult.XWins : GameResult.OWins;
                return new WinInfo(result, uniquePositions);
            }

            // If no winner & no empty positions remain, it's a draw
            bool anyEmptyPositions = boardState.GetPlayerGrid().Any(p => p == Player.None);
            if (!anyEmptyPositions)
                return new WinInfo(GameResult.Draw, null);

            // Otherwise, game is ongoing
            return new WinInfo(GameResult.Ongoing, null);
        }
    }
}
