using NUnit.Framework;

using System.Numerics.Algorithms;

namespace System.Numerics
{
    [TestFixture()]
    public class LUDecompositionTests
    {
        [Test]
        public void LUDecomposition_GetLUMatrix_ReturnsAsExpected()
        {
            var luFactorization = new LUDecomposition();
            var matrix = new Matrix(2, 2, new double[,] { { 4, 3 }, { 6, 3 } });

            var expectedL = new Matrix(2, 2, new double[,] { { 1, 0 }, { 1.5, 1 } });
            var expectedU = new Matrix(2, 2, new double[,] { { 4, 3 }, { 0, -1.5 } });


            Matrix l;
            Matrix u;
            luFactorization.CalculateLUMatrices(matrix, out l, out u);

            Assert.AreEqual(expectedL, l);
            Assert.AreEqual(expectedU, u);
        }
    }
}
