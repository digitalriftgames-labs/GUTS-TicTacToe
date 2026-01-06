namespace GUTS.TicTacToe.Engine
{
    public class BoardState
    {
        internal const int Width = 3;
        internal const int Height = 3;

        internal int Length => Width * Height;

        private Player[] _cells = new Player[Width * Height];

        internal void NewGame()
        {
            Clear();
        }

        internal void Clear()
        {
            for (int i = 0; i < _cells.Length; i++)
                _cells[i] = Player.None;
        }

        internal Player this[int index]
        {
            get => _cells[index];
            set => _cells[index] = value;
        }

        internal Player this[Position position]
        {
            get => _cells[PositionToIndex(position)];
            set => _cells[PositionToIndex(position)] = value;
        }

        public static Position IndexToPosition(int index)
        {
            int x = index % Width;
            int y = index / Width;
            return new Position(x, y);
        }

        public static int PositionToIndex(Position position)
        {
            return (position.y * Width) + position.x;
        }

        internal Player[] GetPlayerGrid()
        {
            return (Player[])_cells.Clone();
        }
    }
}
