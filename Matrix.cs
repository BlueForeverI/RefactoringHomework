using System;

namespace RotatingWalkInMatrix
{
    public class Matrix
    {
        static void Change(ref int dx, ref int dy)
        {
            int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            int cellCount = 0;

            for (int count = 0; count < 8; count++)
            {
                if (dirX[count] == dx && dirY[count] == dy) 
                { 
                    cellCount = count; 
                    break; 
                }
            }

            if (cellCount == 7) 
            { 
                dx = dirX[0]; 
                dy = dirY[0]; 
                return; 
            }

            dx = dirX[cellCount + 1];
            dy = dirY[cellCount + 1];
        }

        static bool AreThereFreeCells(int[,] arr, int x, int y)
        {
            int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };

            for (int i = 0; i < 8; i++)
            {
                if (x + dirX[i] >= arr.GetLength(0) || x + dirX[i] < 0)
                {
                    dirX[i] = 0;
                }

                if (y + dirY[i] >= arr.GetLength(0) || y + dirY[i] < 0)
                {
                    dirY[i] = 0;
                }
            }

            for (int i = 0; i < 8; i++)
            {
                if (arr[x + dirX[i], y + dirY[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        static void FindNextFreeCell(int[,] arr, out int x, out int y)
        {
            x = 0;
            y = 0;

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    if (arr[i, j] == 0) 
                    { 
                        x = i; 
                        y = j; 
                        return; 
                    }
                }
            }

        }

        static void Main(string[] args)
        {
            int n = 6;
            int[,] matrix = new int[n, n];
            int step = n, k = 1, i = 0, j = 0, dx = 1, dy = 1;

            while (true)
            { //malko e kofti tova uslovie, no break-a raboti 100% : )
                matrix[i, j] = k;

                if (!AreThereFreeCells(matrix, i, j)) 
                { 
                    break; 
                } // prekusvame ako sme se zadunili

                if (i + dx >= n || i + dx < 0 || j + dy >= n || j + dy < 0
                    || matrix[i + dx, j + dy] != 0)
                {
                    while ((i + dx >= n || i + dx < 0 || j + dy >= n || j + dy < 0 || matrix[i + dx, j + dy] != 0))
                    {
                        Change(ref dx, ref dy);
                    }
                }

                i += dx; j += dy; k++;
            }

            FindNextFreeCell(matrix, out i, out j);
            if (i != 0 && j != 0)
            { // taka go napravih, zashtoto funkciqta ne mi davashe da ne si definiram out parametrite
                k++;
                dx = 1; dy = 1;


                while (true)
                { //malko e kofti tova uslovie, no break-a raboti 100% : )
                    matrix[i, j] = k;

                    if (!AreThereFreeCells(matrix, i, j)) 
                    {
                        break; 
                    }// prekusvame ako sme se zadunili

                    if (i + dx >= n || i + dx < 0 || j + dy >= n || j + dy < 0 || matrix[i + dx, j + dy] != 0)
                    {
                        while ((i + dx >= n || i + dx < 0 || j + dy >= n || j + dy < 0 || matrix[i + dx, j + dy] != 0))
                        {
                            Change(ref dx, ref dy);
                        }
                    }

                    i += dx; j += dy; k++;
                }
            }

            for (int p = 0; p < n; p++)
            {
                for (int q = 0; q < n; q++)
                {
                    Console.Write("{0,3}", matrix[p, q]);
                }

                Console.WriteLine();
            }
        }
    }
}
