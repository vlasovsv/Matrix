using System;

using NUnit.Framework;

using NMatrix.Solvers;

namespace NMatrix.Tests
{
    [TestFixture()]
    public class CholeskySolverTests
    {
        [Test]
        public void CholeskySolver_Solve_ReturnsResultAsExpected()
        {
            var matrix = new Matrix(3, 3, new double[,] { { 81, -45, 45 }, { -45, 50, -15 }, { 45, -15, 38 } });
            var right = new Vector(3, new double[] { 531, -460, 193 });

            var expected = Vector.From(new double[] { 6, -5, -4 });

            var solver = new CholeskySolver();

            var x = solver.Solve(matrix, right);

            Assert.AreEqual(expected, x);
        }

        [Test]
        public void CholeskySolver_SolveWhenFactorIsNotSquare_ThrowsNonSymmetricMatrixException()
        {
            var matrix = new Matrix(3, 3, new double[,] { { 81, -45, 45 }, { -45, 50, 5 }, { 45, -15, 38 } });
            var right = new Vector(3, new double[] { 531, -460, 193 });

            var solver = new CholeskySolver();

            Assert.Throws<NonSymmetricMatrixException>(() => solver.Solve(matrix, right));
        }

        [Test]
        public void CholeskySolver_SolveWhenFactorIsNull_ThrowsArgumentNullException()
        {
            var right = new Vector(3);

            var solver = new CholeskySolver();

            Assert.Throws<ArgumentNullException>(() => solver.Solve(null, right));
        }

        [Test]
        public void CholeskySolver_SolveWhenRightIsNull_ThrowsArgumentNullException()
        {
            var matrix = new Matrix(3, 3, new double[,] { { 81, -45, 45 }, { -45, 50, 5 }, { 45, -15, 38 } });

            var solver = new CholeskySolver();

            Assert.Throws<ArgumentNullException>(() => solver.Solve(matrix, null));
        }

        [Test]
        public void CholeskySolver_SolveWhenFactorAndRightHaveDifferentSize_ThrowsArgumentNullException()
        {
            var matrix = new Matrix(3, 3, new double[,] { { 81, -45, 45 }, { -45, 50, 5 }, { 45, -15, 38 } });
            var right = new Vector(2);

            var solver = new CholeskySolver();

            Assert.Throws<ArgumentException>(() => solver.Solve(matrix, right));
        }
    }
}
