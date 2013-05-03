using System;

namespace RotatingWalkInMatrix
{
    public class MatrixConsoleTest
    {
        static void Main(string[] args)
        {
            Matrix matrix = new Matrix(6);
            matrix.WalkInMatrix();
            Console.WriteLine(matrix.ToString());
        }
    }
}
