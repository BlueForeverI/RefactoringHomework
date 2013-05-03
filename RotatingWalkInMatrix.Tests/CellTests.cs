using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RotatingWalkInMatrix;

namespace RotatingWalkInMatrix.Tests
{
    [TestClass]
    public class CellTests
    {
        [TestMethod]
        public void TestEmptyCellConstructor()
        {
            Cell cell = new Cell();
            Assert.AreEqual(0, cell.X);
            Assert.AreEqual(0, cell.Y);
        }

        [TestMethod]
        public void TestCellConstructor()
        {
            int x = 2;
            int y = 3;
            Cell cell = new Cell(x, y);

            Assert.AreEqual(x, cell.X);
            Assert.AreEqual(y, cell.Y);
        }

        [TestMethod]
        public void TestEqualOperator()
        {
            Cell a = new Cell(4, 5);
            Cell b = new Cell(4, 5);

            Assert.IsTrue(a == b);
        }

        [TestMethod]
        public void TestNotEqualOperator()
        {
            Cell a = new Cell(4, 5);
            Cell b = new Cell(4, 6);

            Assert.IsTrue(a != b);
        }

        [TestMethod]
        public void TestAdditionOperator()
        {
            Cell a = new Cell(4, 5);
            Cell b = new Cell(4, 6);
            Cell result = a + b;

            Assert.AreEqual(new Cell(8, 11), result);
        }
    }
}
