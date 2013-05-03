using System;

namespace RotatingWalkInMatrix
{
    public class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Cell()
        {
            this.X = 0;
            this.Y = 0;
        }

        public Cell(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public override bool Equals(object obj)
        {
            Cell cell = (Cell)obj;
            return this.X == cell.X && this.Y == cell.Y;
        }

        public static bool operator == (Cell a, Cell b)
        {
            return a.Equals(b);
        }

        public static bool operator != (Cell a, Cell b)
        {
            return !a.Equals(b);
        }

        public static Cell operator +(Cell a, Cell b)
        {
            return new Cell(a.X + b.X, a.Y + b.Y);
        }
    }
}
