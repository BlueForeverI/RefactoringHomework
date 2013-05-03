using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RotatingWalkInMatrix.Tests
{
    [TestClass]
    public class MatrixTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestMatrixConstructor_InvalidSize()
        {
            Matrix matrix = new Matrix(-7);
            return;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMatrixConstructor_InvalidMatrix()
        {
            Matrix matrix = new Matrix(5, new int[,]{ });
            return;
        }

        [TestMethod]
        public void TestToString()
        {
            int[,] data = new int[6, 6]
            {
                {1, 1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1, 1}
            };
            Matrix matrix = new Matrix(6, data);
            string expected = "  1  1  1  1  1  1\n" +
                            "  1  1  1  1  1  1\n" +
                            "  1  1  1  1  1  1\n" +
                            "  1  1  1  1  1  1\n" +
                            "  1  1  1  1  1  1\n" +
                            "  1  1  1  1  1  1\n";

            Assert.AreEqual(expected, matrix.ToString());
        }

        private bool AreMatricesEqual(int[,] a, int[,] b)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if (a[i, j] != b[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        [TestMethod]
        public void TestWalkInMatrix()
        {
            Matrix matrix = new Matrix(6);
            matrix.WalkInMatrix();
            int[,] expected = new int[6, 6]
            {
                {1, 16, 17, 18, 19, 20},
                {15, 2, 27, 28, 29, 21},
                {14, 31, 3, 26, 30, 22},
                {13, 36, 32, 4, 25, 23},
                {12, 35, 34, 33, 5, 24},
                {11, 10, 9, 8, 7, 6}
            };

            Assert.IsTrue(AreMatricesEqual(expected, matrix.Data));
        }
    }
}
