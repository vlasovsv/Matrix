using System;

using NMatrix.Decompositions;

namespace NMatrix.Solvers
{
    /// <summary>
    /// Represents Cholesky solver.
    /// </summary>
    public sealed class CholeskySolver : ISolver
    {
        #region Methods

        /// <summary>
        /// Solves a system of linear equations, <b>Ax = b</b>.
        /// </summary>
        /// <param name="factor">A coefficient matrix A.</param>
        /// <param name="right">A right-hand vector b.</param>
        /// <returns>
        /// Returns a vector x that is a solution of the system of linear equations, <b>Ax = b</b>.
        /// </returns>
        public Vector Solve(Matrix factor, Vector right)
        {
            if (factor == null)
            {
                throw new ArgumentNullException("Factor matrix cannot be null.");
            }

            if (right == null)
            {
                throw new ArgumentNullException("Right vector cannot be null.");
            }

            if (factor.Rows != right.Size)
            {
                throw new ArgumentException("Factor matrix and right vector have inconsistence size.");
            }

            var decomposition = new CholeskyDecomposition();
            decomposition.CalculateLLtMatrices(factor, out Matrix lower, out Matrix lowerTransposed);

            var y = SolveLower(lower, right);
            var x = SolveUpper(lowerTransposed, y);

            return x;
        }

        private Vector SolveLower(Matrix lower, Vector right)
        {
            var y = new Vector(right.Size);

            for (int i = 0; i < lower.Rows; i++)
            {
                var x = right[i];
                for (int j = 0; j <= i; j++)
                {
                    if (i == j)
                    {
                        y[i] = x / lower[i, j];
                    }
                    else
                    {
                        x -= y[j] * lower[i, j];
                    }
                }
            }

            return y;
        }

        private Vector SolveUpper(Matrix upper, Vector y)
        {
            var x = new Vector(y.Size);

            for (int i = upper.Rows - 1; i >= 0; i--)
            {
                var yi = y[i];
                for (int j = upper.Columns - 1; j >= i; j--)
                {
                    if (i == j)
                    {
                        x[i] = yi / upper[i, j];
                    }
                    else
                    {
                        yi -= x[j] * upper[i, j];
                    }
                }
            }

            return x;
        }

        #endregion
    }
}
