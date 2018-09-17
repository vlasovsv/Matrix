using NUnit.Framework;

namespace NMatrix.Tests
{
    [TestFixture()]
    class VectorTests
    {
        [Test]
        public void Vector_IndexTest_ReturnsResultAsExpected()
        {
            var vector1 = Vector.From(new double[] { 1, 2, 3 });
            var index = 1;

            var result = vector1[index];

            var expected = 2;

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Vector_NegativeIndexTest_ReturnsResultAsExpected()
        {
            var vector1 = Vector.From(new double[] { 1, 2, 3 });
            var index = -1;

            var result = vector1[index];

            var expected = 3;

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Vector_Add_ReturnsResultAsExpected()
        {
            var vector1 = Vector.From(new double[] { 1, 1, 1 });
            var vector2 = Vector.From(new double[] { 2, 2, 2 });

            var result = vector1.Add(vector2);

            var expected = Vector.From(new double[] { 3, 3, 3 });

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Vector_AddScalar_ReturnsResultAsExpected()
        {
            var vector1 = Vector.From(new double[] { 1, 1, 1 });

            var result = vector1.Add(2);

            var expected = Vector.From(new double[] { 3, 3, 3 });

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Vector_DorProduct_ReturnsResultAsExpected()
        {
            var vector1 = Vector.From(new double[] { 1, 1, 1 });
            var vector2 = Vector.From(new double[] { 2, 2, 2 });

            var result = vector1.DotProduct(vector2);

            var expected = 6;

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Vector_MultiplyScalar_ReturnsResultAsExpected()
        {
            var vector1 = Vector.From(new double[] { 1, 2, 3 });

            var result = vector1 * 2;

            var expected = Vector.From(new double[] { 2, 4, 6 });

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Vector_Subtract_ReturnsResultAsExpected()
        {
            var vector1 = Vector.From(new double[] { 1, 2, 3 });
            var vector2 = Vector.From(new double[] { 1, 2, 3 });

            var result = vector1 - vector2;

            var expected = new Vector(3);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Vector_SubtractScalar_ReturnsResultAsExpected()
        {
            var vector1 = Vector.From(new double[] { 1, 1, 1});

            var result = vector1 - 1;

            var expected = new Vector(3);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Vector_Negate_ReturnsResultAsExpected()
        {
            var vector1 = Vector.From(new double[] { 1, -1, 1, -1 });

            var result = -vector1;

            var expected = new Vector(4, new double[] { -1, 1, -1, 1 });

            Assert.AreEqual(expected, result);
        }

        [TestCase(1, 6)]
        [TestCase(2, 3.742)]
        [TestCase(3, 3.302)]
        public void Vector_Norm_ReturnsResultAsExpected(int p, double expected)
        {
            var vector = Vector.From(new double[] { 1, 2, 3 });

            var result = vector.Norm(p);

            Assert.AreEqual(expected, result, 0.001);
        }

        [Test]
        public void Vector_Normalize_ReturnsResultAsExpected()
        {
            var vector = Vector.From(new double[] { 3, 2, -1 });

            var result = vector.Normalize();

            var expected = new double[] { 0.801784, 0.534522, -0.267261 };

            Assert.That(result, Is.EqualTo(expected).Within(0.000001));
        }
    }
}
