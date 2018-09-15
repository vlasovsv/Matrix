namespace NMatrix.Algorithms
{
    /// <summary>
    /// LU-decomposition solver.
    /// </summary>
    public class LUDecomposition
    {
        #region Methods

        /// <summary>
        /// Calculates l (lower) and u (upper) matrices for current matrix.
        /// </summary>
        /// <param name="matrix">Current matrix.</param>
        /// <param name="lower">Out l (lower) matrix.</param>
        /// <param name="upper">Out u (upper) matrix.</param>
        public void CalculateLUMatrices(Matrix matrix, out Matrix lower, out Matrix upper)
        {
            lower = new Matrix(matrix.Rows, matrix.Columns);
            upper = new Matrix(matrix.Rows, matrix.Columns);

            for (int j = 0; j < matrix.Columns; j++)
            {
                upper[0, j] = matrix[0, j];
                lower[j, 0] = matrix[j, 0] / upper[0, 0];
            }

            for (int i = 1; i < matrix.Rows; i++)
            {
                for (int j = i; j < matrix.Columns; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < i; k++)
                    {
                        sum += lower[i, k] * upper[k, j];
                    }
                    upper[i, j] = matrix[i, j] - sum;

                    sum = 0;

                    for (int k = 0; k < i; k++)
                    {
                        sum += lower[j, k] * upper[k, i];
                    }

                    lower[j, i] = (1 / upper[i, i]) * (matrix[j, i] - sum);
                }
            }
        }

        #endregion
    }
}
