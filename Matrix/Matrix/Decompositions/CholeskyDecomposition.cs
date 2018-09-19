using System;

namespace NMatrix.Decompositions
{
    /// <summary>
    /// Represents Cholesky-decomposition.
    /// </summary>
    public class CholeskyDecomposition
    {
        #region Methods

        /// <summary>
        /// Calculates L (lower) and Lt (lower transposed) matrices for current matrix.
        /// </summary>
        /// <param name="matrix">Current matrix.</param>
        /// <param name="lower">Out L (lower) matrix.</param>
        /// <param name="lowerTransposed">Out Lt (lower transposed) matrix.</param>
        public void CalculateLLtMatrices(Matrix matrix, out Matrix lower, out Matrix lowerTransposed)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException("Original matrix could not be null.");
            }

            if (!matrix.IsSymmetric)
            {
                throw new NonSymmetricMatrixException(
                    "Cholesky decomposition cannot apply to non-symmetric matrices.");
            }

            lower = new Matrix(matrix.Rows, matrix.Columns);

            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    var sum = 0d;

                    if (j < i)
                    {
                        for (int k = 0; k < i; k++)
                        {
                            sum += lower[i, k] * lower[j, k];
                        }
                        lower[i, j] = (1 / lower[j, j]) * (matrix[i, j] - sum);
                    }

                    sum = 0d;

                    for (int k = 0; k < i; k++)
                    {
                        sum += lower[i, k] * lower[i, k];
                    }

                    lower[i, i] = Math.Sqrt(matrix[i, i] - sum);
                }
            }

            lowerTransposed = lower.Transpose();
        }

        #endregion
    }
}
