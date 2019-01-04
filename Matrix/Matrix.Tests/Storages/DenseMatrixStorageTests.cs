using NMatrix.Storages;
using NUnit.Framework;

namespace NMatrix.Tests.Storages
{
    [TestFixture()]
    class DenseMatrixStorageTests
    {
        [Test]
        public void DenseMatrixStorage_New_ReturnResultsAsExpected()
        {
            var storage = new DenseMatrixStorage(3, 3);

            Assert.True(storage.IsZero);
        }

        [Test]
        public void DenseMatrixStorage_NewWithBuffer_ReturnResultsAsExpected()
        {
            var buffer = new double[,] { { 81, -45, 45 }, { -45, 50, 5 }, { 45, -15, 38 } };
            var storage = new DenseMatrixStorage(3, 3, buffer);

            Assert.False(storage.IsZero);
        }

        [Test]
        public void DenseMatrixStorage_Equals_ReturnResultsAsExpected()
        {
            var buffer1 = new double[,] { { 81, -45, 45 }, { -45, 50, 5 }, { 45, -15, 38 } };
            var storage1 = new DenseMatrixStorage(3, 3, buffer1);

            var buffer2 = new double[,] { { 81, -45, 45 }, { -45, 50, 5 }, { 45, -15, 38 } };
            var storage2 = new DenseMatrixStorage(3, 3, buffer1);

            Assert.AreEqual(storage1, storage2);
        }

        [Test]
        public void DenseMatrixStorage_IsSquare_ReturnResultsAsExpected()
        {
            var storage = new DenseMatrixStorage(3, 3);

            Assert.AreEqual(true, storage.IsSquare);
        }

        [Test]
        public void DenseMatrixStorage_IsSymmetric_ReturnResultsAsExpected()
        {
            var storage = new DenseMatrixStorage(3, 3, new double[,] { { 81, -45, 45 }, { -45, 50, 5 }, { 45, -15, 38 } });

            Assert.AreEqual(true, storage.IsSymmetric);
        }
    }
}
