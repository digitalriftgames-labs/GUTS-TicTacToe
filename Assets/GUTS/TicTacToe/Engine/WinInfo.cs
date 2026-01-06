namespace GUTS.TicTacToe.Engine
{
    public struct WinInfo
    {
        public GameResult result;
        public Position[] winningPositions;

        public WinInfo(GameResult result, Position[] positions)
        {
            this.result = result;
            this.winningPositions = positions;
        }
    }
}
