using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameFifteen
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
    }
}
