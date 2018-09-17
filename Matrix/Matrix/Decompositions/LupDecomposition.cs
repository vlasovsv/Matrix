using System;

namespace NMatrix.Decompositions
{
    /// <summary>
    /// Represents LUP decomposition.
    /// </summary>
    public sealed class LupDecomposition
    {
        #region Methods

        /// <summary>
        /// Calculates C and P matrices for current matrix.
        /// </summary>
        /// <param name="matrix">Current matrix.</param>
        /// <param name="c">Out C matrix (C = L + U - E).</param>
        /// <param name="p">Out P matrix (permuation matrix).</param>
        public void CalculateLUPMatrices(Matrix matrix, out Matrix c, out Matrix p)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException("Original matrix cannot be null");
            }

            if (!matrix.IsSquare)
            {
                throw new NonSquareMatrixException("LUP decomposition cannot apply to non-square matrices.");
            }

            c = matrix.Clone();

            p = Matrix.Identity(c.Rows);

            var n = c.Rows;

            for (int i = 0; i < n; i++)
            {
                var pivotIndex = -1;
                var pivotValue = 0d;

                // Searching a pivot element.
                for (int k = i; k < n; k++)
                {
                    if (Math.Abs(c[k, i]) > pivotValue)
                    {
                        pivotValue = Math.Abs(c[k, i]);
                        pivotIndex = k;
                    }
                }

                if (pivotValue != 0)
                {
                    // Swapping row with pivot element row
                    for (int j = 0; j < c.Columns; j++)
                    {
                        var tmp = c[i, j];
                        c[i, j] = c[pivotIndex, j];
                        c[pivotIndex, j] = tmp;

                        tmp = p[i, j];
                        p[i, j] = p[pivotIndex, j];
                        p[pivotIndex, j] = tmp;
                    }

                    for (int j = i + 1; j < n; j++)
                    {
                        c[j, i] /= c[i, i];
                        
                        for (int k = i + 1; k < n; k++)
                            c[j, k] -= c[j, i] * c[i, k];
                    }
                }
            }
        }

        #endregion
    }
}
