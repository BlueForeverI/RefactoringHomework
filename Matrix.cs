using System;
using System.Text;

namespace RotatingWalkInMatrix
{
    public class Matrix
    {
        private const int DIRECTION_COUNT = 8;
        private int size;
        int[,] data;
        int step;
        int currentNumber;
        Cell previousCell;
        Cell nextCell;

        public Matrix(int size, int[,] matrix = null)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    "size", "Size should be a positive number");
            }

            this.size = size;
            if (matrix == null)
            {
                this.data = new int[size, size];
            }
            else
            {
                bool isMatrixEmpty = matrix.GetLength(0) == 0 ||
                    matrix.GetLength(1) == 0;
                if (isMatrixEmpty)
                {
                    throw new ArgumentException("Matrix is empty", "data");
                }

                this.data = matrix;
            }

            this.step = size;
            this.currentNumber = 1;
            this.previousCell = new Cell(0, 0);
            this.nextCell = new Cell(1, 1);
        }

        public int[,] Data
        {
            get
            {
                return this.data;
            }
        }

        public void WalkInMatrix()
        {
            PerformLongestWalk();
            this.previousCell = FindNextFreeCell();

            if (this.previousCell != new Cell(0, 0))
            {
                this.currentNumber++;
                this.nextCell = new Cell(1, 1);
                PerformLongestWalk();
            }
        }

        private void PerformLongestWalk()
        {
            while (true)
            {
                data[previousCell.X, previousCell.Y] = currentNumber;

                if (!AreThereFreeNeighbours(previousCell))
                {
                    break;
                }

                if (AreAddedCellsInRange(previousCell, nextCell))
                {
                    while (AreAddedCellsInRange(previousCell, nextCell))
                    {
                        MoveCellInDirection(ref nextCell);
                    }
                }

                previousCell += nextCell;
                currentNumber++;
            }
        }

        private bool AreAddedCellsInRange(Cell previousCell, Cell nextCell)
        {
            Cell result = previousCell + nextCell;
            bool isCellOutOfRange = result.X >= size || result.X < 0 ||
                result.Y >= size || result.Y < 0;

            return isCellOutOfRange || data[result.X, result.Y] != 0;
        }

        Cell FindNextFreeCell()
        {
            Cell cell = new Cell(0, 0);

            for (int i = 0; i < this.data.GetLength(0); i++)
            {
                for (int j = 0; j < this.data.GetLength(0); j++)
                {
                    if (this.data[i, j] == 0)
                    {
                        return new Cell(i, j);
                    }
                }
            }

            return cell;
        }

        bool AreThereFreeNeighbours(Cell cell)
        {
            Cell[] directions = new Cell[] 
            {
                new Cell(1, 1),
                new Cell(1, 0),
                new Cell(1, -1), 
                new Cell(0, -1),
                new Cell(-1, -1),
                new Cell(-1, 0),
                new Cell(-1, 1),
                new Cell(0, 1)
            };

            for (int i = 0; i < DIRECTION_COUNT; i++)
            {
                directions[i] = CalculateCellCoordinates(cell, directions[i]);
                bool isCellFree = this.data[cell.X + directions[i].X,
                    cell.Y + directions[i].Y] == 0;

                if (isCellFree)
                {
                    return true;
                }
            }

            return false;
        }

        static void MoveCellInDirection(ref Cell cell)
        {
            Cell[] directions = new Cell[] 
            {
                new Cell(1, 1),
                new Cell(1, 0),
                new Cell(1, -1), 
                new Cell(0, -1),
                new Cell(-1, -1),
                new Cell(-1, 0),
                new Cell(-1, 1),
                new Cell(0, 1)
            };

            int cellCount = 0;

            for (int i = 0; i < DIRECTION_COUNT; i++)
            {
                if (directions[i].X == cell.X && directions[i].Y == cell.Y)
                {
                    cellCount = i;
                    break;
                }
            }

            if (cellCount == 7)
            {
                cell = directions[0];
                return;
            }

            cell = directions[cellCount + 1];
        }

        private Cell CalculateCellCoordinates(Cell cell, Cell direction)
        {
            Cell result = cell + direction;
            bool isXOutOfRange = result.X >= this.data.GetLength(0) ||
                result.X < 0;
            if (isXOutOfRange)
            {
                direction.X = 0;
            }

            bool isYOutOfRange = result.Y >= this.data.GetLength(0) ||
                result.Y < 0;
            if (isYOutOfRange)
            {
                direction.Y = 0;
            }

            return direction;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    result.Append(string.Format("{0,3}", data[i, j]));
                }

                result.Append("\n");
            }

            return result.ToString();
        }
    }
}
