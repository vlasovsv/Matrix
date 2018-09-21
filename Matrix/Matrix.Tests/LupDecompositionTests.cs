using System.Collections;
using System.Linq;
using NUnit.Framework;

using NMatrix.Decompositions;

namespace NMatrix.Tests
{
    [TestFixture()]
    public class LupDecompositionTests
    {
        [Test]
        public void LupDecomposition_CalculateLUMatrices_ReturnsAsExpected()
        {
            var lupDecomposition = new LupDecomposition();
            var matrix = new Matrix(4, 4,
                new double[,] { { 2, 1, 1, 0 }, { 4, 3, 3, 1 }, { 8, 7, 9, 5 }, { 6, 7, 9, 8 } });

            var expectedC = new Matrix(4, 4,
                new double[,] { { 8, 7, 9, 5 }, { 0.75, 1.75, 2.25, 4.25 }, { 0.5, -0.28571, -0.85714, -0.28571 }, { 0.25, -0.42857, 0.33333, 0.66667 } });
            var expectedP = new Matrix(4, 4,
                new double[,] { { 0, 0, 1, 0 }, { 0, 0, 0, 1 }, { 0, 1, 0, 0 }, { 1, 0, 0, 0 } });

            lupDecomposition.CalculateLUPMatrices(matrix, out Matrix c, out Matrix p);

            Assert.That(c.Cast<double>(), Is.EqualTo(expectedC.Cast<double>()).Within(0.00001));
            Assert.AreEqual(expectedP, p);
        }
    }
}
