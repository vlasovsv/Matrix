using System;

namespace NMatrix.Storages
{
    public abstract class MatrixStorageBase : IEquatable<MatrixStorageBase>
    {
        #region Properties

        /// <summary>
        /// Gets a number of rows.
        /// </summary>
        public int Rows { get; }

        /// <summary>
        /// Gets a number of columns.
        /// </summary>
        public int Columns { get; }

        /// <summary>
        /// Gets a flag if this matrix is square or not.
        /// </summary>
        public bool IsSquare => Rows == Columns;

        /// <summary>
        /// Gets a flag if this matrix is symmetric or not.
        /// </summary>
        public bool IsSymmetric => GetIsSymmetric();

        /// <summary>
        /// Gets or sets a value corresponding to a row and a column of the matrix.
        /// </summary>
        /// <param name="row">Value row index.</param>
        /// <param name="column">Value column index.</param>
        /// <returns>
        /// Returns matrix value.
        /// </returns>
        public double this[int row, int column]
        {
            get
            {
                return At(row, column);
            }
            set
            {
                At(row, column, value);
            }
        }

        /// <summary>
        /// Gets a flag if this storage is dense or not.
        /// </summary>
        public abstract bool IsDense { get; }

        /// <summary>
        /// Gets a flag if this storage has only zero elements.
        /// </summary>
        public abstract bool IsZero { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Gets a value corresponding to a row and a column of the matrix.
        /// </summary>
        /// <param name="row">A row.</param>
        /// <param name="column">A column.</param>
        /// <returns>
        /// Returns a value.
        /// </returns>
        public abstract double At(int row, int column);

        /// <summary>
        /// Sets a value corresponding to a row and a column of the matrix.
        /// </summary>
        // <param name="row">A row.</param>
        /// <param name="column">A column.</param>
        /// <param name="value">A value.</param>
        public abstract void At(int row, int column, double value);

        /// <summary>
        /// Checks if this matrix storage is symmetric or not.
        /// </summary>
        /// <returns>
        /// Returns true if this matrix storage is symmetric, othewise - false.
        /// </returns>
        private bool GetIsSymmetric()
        {
            if (!IsSquare)
            {
                return false;
            }

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (At(i, j) != At(j, i))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Checks if this two matrix storages are equal or not.
        /// </summary>
        /// <param name="other">Other matrix storage.</param>
        /// <returns>
        /// Returns True if two storages are equal, otherwise - False.
        /// </returns>
        public bool Equals(MatrixStorageBase other)
        {
            if (other == null)
            {
                return false;
            }
            else
            {
                if (Rows != other.Rows || Columns != other.Columns)
                {
                    return false;
                }
                else
                {
                    for (int i = 0; i < Rows; i++)
                    {
                        for (int j = 0; j < Columns; j++)
                        {
                            if (At(i, j) != other.At(i, j))
                            {
                                return false;
                            }
                        }
                    }
                }
                return true;
            }
        }

        #endregion
    }
}
