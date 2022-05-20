using NUnit.Framework;
using OPD;

namespace NUnitTest
{
    public class ArraySorterTest
    {
        int[,] matrix = { { 7, -3, 7 }, { 2, 3, 4 }, { 9, 4, 0 } };
        bool TestMatrix(int[,] matrix1, int[,] matrix2)
        {
            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix1.GetLength(1); j++)
                {
                    if (matrix1[i, j] != matrix2[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        [Test]
        public void MatrixSummaryAsc()
        {
            int[,] assertMatrix = { { 2, 3, 4 }, { 7, -3, 7 }, { 9, 4, 0 } };
            var arr = matrix.SortRows((x, y) => x > y, (x, y) => x + y > x + y ? x + y : x + y);
            Assert.IsTrue(TestMatrix(assertMatrix, arr));
        }

        [Test]
        public void MatrixSummaryDesc()
        {
            int[,] assertMatrix = { { 9, 4, 0 }, { 7, -3, 7 }, { 2, 3, 4 } };
            var arr = matrix.SortRows((x, y) => x < y, (x, y) => x + y > x + y ? x + y : x + y);
            Assert.IsTrue(TestMatrix(assertMatrix, arr));
        }

        [Test]
        public void MatrixMaximumAsc()
        {
            int[,] assertMatrix = { { 2, 3, 4 }, { 7, -3, 7 }, { 9, 4, 0 } };
            var arr = matrix.SortRows((x, y) => x > y, (x, y) => x > y ? x : y);
            Assert.IsTrue(TestMatrix(assertMatrix, arr));
        }

        [Test]
        public void MatrixMaximumDesc()
        {
            int[,] assertMatrix = { { 9, 4, 0 }, { 7, -3, 7 }, { 2, 3, 4 } };
            var arr = matrix.SortRows((x, y) => x < y, (x, y) => x > y ? x : y);
            Assert.IsTrue(TestMatrix(assertMatrix, arr));
        }

        [Test]
        public void MatrixMinimumAsc()
        {
            int[,] assertMatrix = { { 7, -3, 7 }, { 9, 4, 0 }, { 2, 3, 4 } };
            var arr = matrix.SortRows((x, y) => x > y, (x, y) => x < y ? x : y);
            Assert.IsTrue(TestMatrix(assertMatrix, arr));
        }
        [Test]
        public void MatrixMinimumDesc()
        {
            int[,] assertMatrix = { { 2, 3, 4 }, { 9, 4, 0 }, { 7, -3, 7 } };
            var arr = matrix.SortRows((x, y) => x < y, (x, y) => x < y ? x : y);
            Assert.IsTrue(TestMatrix(assertMatrix, arr));
        }
    }
}