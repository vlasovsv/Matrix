using NUnit.Framework;

using NMatrix.Solvers;

namespace NMatrix.Tests
{
    [TestFixture()]
    public class LupSolverTests
    {
        [Test]
        public void LupSolver_Solve_ReturnsResultAsExpected()
        {
            var matrix = new Matrix(3, 3, new double[,] { {1, 1, 1 }, { 4, 3, -1 }, { 3, 5, 3 } });
            var right = new Vector(3, new double[] { 1, 6, 4 });

            var expected = Vector.From(new double[] { 1, 0.5, -0.5 });

            var solver = new LupSolver();

            var x = solver.Solve(matrix, right);

            Assert.AreEqual(expected, x);
        }
    }
}
