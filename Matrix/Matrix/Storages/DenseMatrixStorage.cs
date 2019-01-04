using System;

namespace NMatrix.Storages
{
    /// <summary>
    /// Represents a dense matrix storage.
    /// </summary>
    /// <remarks>
    /// The majority of elements of this storage are not zero.
    /// Zero elements are stored in the memory.
    /// </remarks>
    public sealed class DenseMatrixStorage : MatrixStorageBase
    {
        #region Private fields

        private readonly double[,] _buffer;

        #endregion

        #region Properties

        /// <summary>
        /// Gets a flag if this storage is dense or not.
        /// </summary>
        public override bool IsDense => true;

        /// <summary>
        /// Gets a flag if this storage has only zero elements.
        /// </summary>
        public override bool IsZero => GetIsZero();

        #endregion

        /// <summary>
        /// Creates a new instance of a dense matrix storage.
        /// </summary>
        /// <param name="rows">Number of rows.</param>
        /// <param name="columns">Number of columns.</param>
        public DenseMatrixStorage(int rows, int columns)
        {
            _buffer = new double[rows, columns];
        }

        /// <summary>
        /// Creates a new instance of a dense matrix storage with buffer.
        /// </summary>
        /// <param name="rows">Number of rows.</param>
        /// <param name="columns">Number of columns.</param>
        /// <param name="buffer">A buffer.</param>
        public DenseMatrixStorage(int rows, int columns, double[,] buffer)
        {
            CheckBufferSize(rows, columns, buffer);
            _buffer = buffer;
        }

        #region Methods

        /// <summary>
        /// Gets a value corresponding to a row and a column of the matrix.
        /// </summary>
        /// <param name="row">A row.</param>
        /// <param name="column">A column.</param>
        /// <returns>
        /// Returns a value.
        /// </returns>
        public override double At(int row, int column)
        {
            return _buffer[row, column];
        }

        /// <summary>
        /// Sets a value corresponding to a row and a column of the matrix.
        /// </summary>
        /// <param name="row">A row.</param>
        /// <param name="column">A column.</param>
        /// <param name="value">A value.</param>
        public override void At(int row, int column, double value)
        {
            _buffer[row, column] = value;
        }

        /// <summary>
        /// Checks if all elements are zero.
        /// </summary>
        /// <returns>
        /// Returns True if all elements are zero, otherwise - False.
        /// </returns>
        private bool GetIsZero()
        {
            foreach (var elem in _buffer)
            {
                if (elem != 0)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Checks buffer's size.
        /// </summary>
        /// <param name="rows">Number of rows.</param>
        /// <param name="columns">Number of columns.</param>
        /// <param name="buffer">A buffer.</param>
        private void CheckBufferSize(int rows, int columns, double[,] buffer)
        {
            int bufferRows = buffer.GetLength(0);
            int bufferColumns = buffer.GetLength(1);

            if (bufferRows != rows || bufferColumns != columns)
            {
                throw new ArgumentException(
                    $"Buffer has size {bufferRows}x{bufferColumns} instead of {rows}x{columns}", nameof(buffer));
            }
        }

        #endregion
    }
}
