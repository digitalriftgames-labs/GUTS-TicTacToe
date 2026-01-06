using System;

namespace GUTS.TicTacToe.Engine
{
    public struct Position : IEquatable<Position>
    {
        public int x;
        public int y;

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        override public string ToString()
        {
            return $"({x}, {y})";
        }

        public bool Equals(Position other)
        {
            return (x == other.x) && (y == other.y);
        }

        public override bool Equals(object obj)
        {
            return (obj is Position other) && Equals(other);
        }

        public override int GetHashCode()
        {
            return (x * 397) ^ y;
        }
    }
}
