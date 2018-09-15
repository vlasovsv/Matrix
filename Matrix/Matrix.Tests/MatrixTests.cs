using NUnit.Framework;
using System;

namespace NMatrix
{
    [TestFixture()]
    public class MatrixTests
    {
        [Test]
        public void Matrix_CreateNew_DoesNotThrowException()
        {
            Assert.DoesNotThrow(() => new Matrix(2, 3));
        }

        [Test]
        public void Matrix_CreateNewWithBuffer_DoesNotThrowException()
        {
            Assert.DoesNotThrow(() => new Matrix(2, 3, new double[,] { { 1, 2, 3 }, { 4, 5, 6 } }));
        }

        [TestCase(-1, 2)]
        [TestCase(2, -1)]
        [TestCase(-1, -1)]
        [TestCase(0, 0)]
        [TestCase(1, 0)]
        [TestCase(0, 1)]
        public void Matrix_CreateNewWithRowOrColumnLessThanOne_ThrowArgumentException(int rows, int columns)
        {
            Assert.Throws<ArgumentException>(() => new Matrix(rows, columns));
        }

        [Test]
        public void Matrix_Add_ReturnsResultAsExpected()
        {
            var matrix1 = new Matrix(2, 2, new double[,] { { 1, 2 }, { 3, 4 } });
            var matrix2 = new Matrix(2, 2, new double[,] { { 5, 6 }, { 7, 8 } });

            var result = matrix1 + matrix2;
            var expected = new Matrix(2, 2, new double[,] { { 6, 8 }, { 10, 12 } });

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Matrix_AddWhenMatricesHaveDiferentSizes_ThowsMatrixIncosistencyException()
        {
            var matrix1 = new Matrix(2, 2);
            var matrix2 = new Matrix(3, 2);

            Assert.Throws<MatrixInconsistencyException>(() => matrix1.Add(matrix2));
        }

        [Test]
        public void Matrix_AddWhenAddedMatrixIsNull_ThowsArgumentNullException()
        {
            var matrix1 = new Matrix(2, 2);

            Assert.Throws<ArgumentNullException>(() => matrix1.Add(null));
        }

        [Test]
        public void Matrix_Subtract_ReturnsResultAsExpected()
        {
            var matrix1 = new Matrix(2, 3, new double[,] { { 1, 2, 3 }, { 4, 5, 6 } });
            var matrix2 = new Matrix(2, 3, new double[,] { { 1, 2, 3 }, { 4, 5, 6 } });

            var result = matrix1 - matrix2;
            var expected = new Matrix(2, 3);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Matrix_SubtractWhenMatricesHaveDifferentSizes_ThowsMatrixIncosistencyException()
        {
            var matrix1 = new Matrix(2, 2);
            var matrix2 = new Matrix(3, 2);

            Assert.Throws<MatrixInconsistencyException>(() => matrix1.Subtract(matrix2));
        }

        [Test]
        public void Matrix_SubtractWhenMatrixIsNull_ThowsArgumentNullException()
        {
            var matrix1 = new Matrix(2, 2);

            Assert.Throws<ArgumentNullException>(() => matrix1.Subtract(null));
        }

        [Test]
        public void Matrix_Multiply_ReturnsResultAsExpected()
        {
            var matrix1 = new Matrix(2, 3, new double[,] { { 1, 2, 3 }, { 4, 5, 6 } });
            var matrix2 = new Matrix(3, 2, new double[,] { { 5, 6 }, { 7, 8 }, { 9, 10 } });

            var result = matrix1 * matrix2;
            var expected = new Matrix(2, 2, new double[,] { { 46, 52 }, { 109, 124 } });

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Matrix_MultiplyWhenMatrixIsNull_ThowsArgumentNullException()
        {
            var matrix1 = new Matrix(2, 3);

            Assert.Throws<ArgumentNullException>(() => matrix1.Multiply(null));
        }

        [Test]
        public void Matrix_MultiplyWhenMatrix1ColumnsDontEqualToMatrix2Rows_ThowsMatrixInconsistencyException()
        {
            var matrix1 = new Matrix(2, 3);
            var matrix2 = new Matrix(1, 3);

            Assert.Throws<MatrixInconsistencyException>(() => matrix1.Multiply(matrix2));
        }

        [Test]
        public void Matrix_MultiplyOnScalar_ReturnsAsExpected()
        {
            var m = new Matrix(2, 2, new double[2, 2] { { 2, 2 }, { 2, 2 } });
            var expected = new Matrix(2, 2, new double[2, 2] { { 4, 4 }, { 4, 4 } });

            var result = m * 2;

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Matrix_DivideOnScalar_ReturnsAsExpected()
        {
            var m = new Matrix(2, 2, new double[2, 2] { { 2, 2 }, { 2, 2 } });
            var expected = new Matrix(2, 2, new double[2, 2] { { 1, 1 }, { 1, 1 } });

            var result = m / 2;

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void MatrixOperatorChains_ReturnsResultAsExpected()
        {
            var m1 = new Matrix(2, 2, new double[2, 2] { { 2, 2 }, { 2, 2 } });

            var m2 = new Matrix(2, 3, new double[2, 3] { { 1, 1, 1 }, { 1, 1, 1 } });
            var m3 = new Matrix(3, 2, new double[3, 2] { { 1, 1 }, { 1, 1 }, { 0, 0 } });

            var result = m1 - m2 * m3;
            var expected = new Matrix(2, 2);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Matrix_Distributivity_ReturnsResultAsExpected()
        {
            var m1 = new Matrix(2, 2, new double[2, 2] { { 2, 2 }, { 2, 2 } });

            var m2 = new Matrix(2, 3, new double[2, 3] { { 1, 1, 1 }, { 1, 1, 1 } });
            var m3 = new Matrix(2, 3, new double[2, 3] { { 1, 1, 1 }, { 1, 1, 1 } });

            var result1 = m1 * (m2 + m3);
            var result2 = m1 * m2 + m1 * m3;

            Assert.AreEqual(result1, result2);
        }

        [Test]
        public void Matrix_Minor_ReturnsAsExpected()
        {
            var m = new Matrix(3, 3, new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } });
            var expected = new Matrix(2, 2, new double[,] { { 5, 6 }, { 8, 9 } });

            var result = m.Minor(0, 0);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Matrix_Minor_For2x2_ThrowsMatrixInconsistencyException()
        {
            var m = new Matrix(2, 2, new double[,] { { 5, 6 }, { 8, 9 } });

            Assert.Throws<MatrixInconsistencyException>(() => m.Minor(0, 0));
        }

        [Test]
        public void Matrix_Determinant_For3x3_ReturnsAsExpected()
        {
            var m = new Matrix(3, 3, new double[,] { { 1, 2, 3 }, { 7, 2, 5 }, { 8, 1, 3 } });
            var result = m.Determinant();

            var expected = 12;

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Matrix_Determinant_ForNonSquareMatrix_ThrowsMatrixInconsistencyException()
        {
            var m = new Matrix(3, 2);

            Assert.Throws<MatrixInconsistencyException>(() => m.Determinant());
        }

        [Test]
        public void Matrix_Determinant_For4x4_ReturnsAsExpected()
        {
            var m = new Matrix(4, 4, new double[,] { { 3, 4, 1, 3 }, { 6, 3, 9, 0.5 }, { 6, 8, 2, 10 }, { 1, 17, 8, 22 } });
            var result = m.Determinant();

            var expected = 1776;

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Matrix_Transpose_ReturnsAsExpected()
        {
            var m = new Matrix(2, 3, new double[,] { { 1, 2, 3 }, { 4, 5, 6 } });
            var expected = new Matrix(3, 2, new double[,] { { 1, 4 }, { 2, 5 }, { 3, 6 } });

            var result = m.Transpose();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Matrix_Identity_ReturnsAsExpected()
        {
            var identity = Matrix.Identity(3);
            var expected = new Matrix(3, 3, new double[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } });

            Assert.AreEqual(expected, identity);
        }

        [Test]
        public void Matrix_MultiplyOnInversed_ReturnsIdentity()
        {
            var m1 = new Matrix(3, 3, new double[,] { { 1, 2, 3 }, { 7, 2, 5 }, { 8, 1, 3 } });
            var expected = Matrix.Identity(3);

            var result = m1 * !m1;

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Matrix_Adjoint_ReturnsAsExpected()
        {
            var m = new Matrix(3, 3, new double[,] { { 1, 2, 3 }, { 7, 2, 5 }, { 8, 1, 3 } });
            var expected = new Matrix(3, 3, new double[,] { { 1, -3, 4 }, { 19, -21, 16 }, { -9, 15, -12 } });

            var result = m.Adjoint();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Matrix_From_ReturnsAsExpected()
        {
            var expected = new Matrix(3, 3, new double[,] { { 1, 2, 3 }, { 7, 2, 5 }, { 8, 1, 3 } });
            var result = Matrix.From(new double[,] { { 1, 2, 3 }, { 7, 2, 5 }, { 8, 1, 3 } });

            Assert.AreEqual(expected, result);
        }
    }
}
