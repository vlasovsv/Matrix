using NUnit.Framework;

using NMatrix.Decompositions;

namespace NMatrix.Tests
{
    [TestFixture()]
    public class LUDecompositionTests
    {
        [Test]
        public void LUDecomposition_CalculateLUMatrices_ReturnsAsExpected()
        {
            var luDecomposition = new LUDecomposition();
            var matrix = new Matrix(2, 2, new double[,] { { 4, 3 }, { 6, 3 } });

            var expectedL = new Matrix(2, 2, new double[,] { { 1, 0 }, { 1.5, 1 } });
            var expectedU = new Matrix(2, 2, new double[,] { { 4, 3 }, { 0, -1.5 } });


            Matrix l;
            Matrix u;
            luDecomposition.CalculateLUMatrices(matrix, out l, out u);

            Assert.AreEqual(expectedL, l);
            Assert.AreEqual(expectedU, u);
        }
    }
}
