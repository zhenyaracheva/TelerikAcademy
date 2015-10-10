using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using MatrixTask;

namespace MatrixTaskTest
{
    [TestClass]
    public class MatrixTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateZeroSizeMatrix()
        {
            var matrix = new Matrix(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateBiggerThanPossibleSizeMatrix()
        {
            var matrix = new Matrix(101);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateNegativeSizeMatrix()
        {
            var matrix = new Matrix(-30);
        }

        [TestMethod]
        public void CreateOneSizeMatrix()
        {
            var matrix = new Matrix(1);
            var expected = "1";
            Assert.AreEqual(expected, matrix.ToString().Trim());
        }

        [TestMethod]
        public void CreateSixSizeMatrix()
        {
            var matrix = new Matrix(6);
            var expected = string.Format("{0}\r\n{1}\r\n{2}\r\n{3}\r\n{4}\r\n{5}\r\n",
                "  1 16 17 18 19 20",
                " 15  2 27 28 29 21",
                " 14 31  3 26 30 22",
                " 13 36 32  4 25 23",
                " 12 35 34 33  5 24",
                " 11 10  9  8  7  6");
            Assert.AreEqual(expected, matrix.ToString());
        }
    }
}
