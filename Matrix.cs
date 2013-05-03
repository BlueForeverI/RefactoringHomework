using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RotatingWalkInMatrix
{
    public class Matrix
    {
        private int size;
        int[,] matrix;
        int step;
        int currentNumber;
        Cell previousCell;
        Cell nextCell;

        public Matrix(int size)
        {
            this.size = size;
            this.matrix = new int[size, size];
            this.step = size;
            this.currentNumber = 1;
            this.previousCell = new Cell(0, 0);
            this.nextCell = new Cell(1, 1);
        }

        static void Change(ref Cell cell)
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

            for (int i = 0; i < 8; i++)
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

            for (int i = 0; i < 8; i++)
            {
                directions[i] = MoveCellInDirection(cell, directions[i]);
            }

            for (int i = 0; i < 8; i++)
            {
                bool isCellFree = this.matrix[cell.X + directions[i].X, 
                    cell.Y + directions[i].Y] == 0;
                if (isCellFree)
                {
                    return true;
                }
            }

            return false;
        }

        private Cell MoveCellInDirection(Cell cell, Cell direction)
        {
            bool isXOutOfRange = cell.X + direction.X >= this.matrix.GetLength(0) ||
                cell.X + direction.X < 0;
            if (isXOutOfRange)
            {
                direction.X = 0;
            }

            bool isYOutOfRange = cell.Y + direction.Y >= this.matrix.GetLength(0) ||
                cell.Y + direction.Y < 0;
            if (isYOutOfRange)
            {
                direction.Y = 0;
            }

            return direction;
        }

        Cell FindNextFreeCell()
        {
            Cell cell = new Cell(0, 0);

            for (int i = 0; i < this.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < this.matrix.GetLength(0); j++)
                {
                    if (this.matrix[i, j] == 0)
                    {
                        return new Cell(i, j);
                    }
                }
            }

            return cell;
        }

        public void WalkInMatrix()
        {
            PerformLongestWalk();
            this.previousCell = FindNextFreeCell();

            if (previousCell.X != 0 && previousCell.Y != 0)
            {
                currentNumber++;
                nextCell.X = 1;
                nextCell.Y = 1;
                PerformLongestWalk();
            }
        }

        private void PerformLongestWalk()
        {
            while (true)
            {
                matrix[previousCell.X, previousCell.Y] = currentNumber;

                if (!AreThereFreeNeighbours(previousCell))
                {
                    break;
                }

                if (previousCell.X + nextCell.X >= size || previousCell.X + nextCell.X < 0 ||
                    previousCell.Y + nextCell.Y >= size || previousCell.Y + nextCell.Y < 0 ||
                    matrix[previousCell.X + nextCell.X, previousCell.Y + nextCell.Y] != 0)
                {
                    while ((previousCell.X + nextCell.X >= size || previousCell.X + nextCell.X < 0 ||
                        previousCell.Y + nextCell.Y >= size || previousCell.Y + nextCell.Y < 0 ||
                        matrix[previousCell.X + nextCell.X, previousCell.Y + nextCell.Y] != 0))
                    {
                        Change(ref nextCell);
                    }
                }

                previousCell.X += nextCell.X;
                previousCell.Y += nextCell.Y;
                currentNumber++;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    result.Append(string.Format("{0,3}", matrix[i, j]));
                }

                result.Append("\n");
            }

            return result.ToString();
        }
    }
}
