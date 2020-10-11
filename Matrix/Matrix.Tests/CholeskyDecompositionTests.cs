using NUnit.Framework;

using NMatrix.Decompositions;

namespace NMatrix.Tests
{
    [TestFixture()]
    class CholeskyDecompositionTests
    {
        [Test]
        public void CholeskyDecomposition_CalculateLLtMatrices_ReturnsAsExpected()
        {
            var choleskyDecomposition = new CholeskyDecomposition();
            var matrix = new Matrix(3, 3, new double[,] { { 81, -45, 45 }, { -45, 50, -15 }, { 45, -15, 38 } });

            var expectedL = new Matrix(3, 3, new double[,] { { 9, 0, 0 }, { -5, 5, 0 }, { 5, 2, 3 } });
            var expectedLt = new Matrix(3, 3, new double[,] { { 9, -5, 5 }, { 0, 5, 2 }, { 0, 0, 3 } });

            var (l, lt) = choleskyDecomposition.Decompose(matrix);

            Assert.AreEqual(expectedL, l);
            Assert.AreEqual(expectedLt, lt);
        }
    }
}
