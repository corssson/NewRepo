#nullable disable

using NUnit.Framework;
using System;

namespace ComplexNumberStruct.Tests
{
    [TestFixture]
    public class ComplexNumberTests
    {
        private const double Delta = 1e-13;

        [Test]
        public void ConstructorTest_ValidValues_PropertiesSetCorrectly()
        {
            var complex = new ComplexNumber(2.5, -3.7);

            Assert.That(complex.Re, Is.EqualTo(2.5).Within(Delta));
            Assert.That(complex.Im, Is.EqualTo(-3.7).Within(Delta));
        }

        [TestCase(3, 4, 5)]
        [TestCase(-3, 4, 5)]
        [TestCase(0, 0, 0)]
        [TestCase(1, 1, 1.4142135623730951)]
        [TestCase(-2, -2, 2.8284271247461903)]
        public void AbsTest_ComplexNumbers_CorrectModulus(double re, double im, double expectedAbs)
        {
            var complex = new ComplexNumber(re, im);
            double actualAbs = complex.Abs;
            Assert.That(actualAbs, Is.EqualTo(expectedAbs).Within(Delta));
        }

        [TestCase(0, 0, "0")]
        [TestCase(5, 0, "5")]
        [TestCase(0, 1, "i")]
        [TestCase(0, -1, "-i")]
        [TestCase(0, 5, "5i")]
        [TestCase(2, 3, "2 + 3i")]
        [TestCase(2, -3, "2 - 3i")]
        [TestCase(-2, 3, "-2 + 3i")]
        [TestCase(-2, -3, "-2 - 3i")]
        [TestCase(0, 2.5, "2.5i")]
        [TestCase(2.5, 0, "2.5")]
        public void ToStringTest_VariousNumbers_CorrectFormat(double re, double im, string expected)
        {
            var complex = new ComplexNumber(re, im);
            string result = complex.ToString();
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(1, 2, 1, 2, true)]
        [TestCase(1, 2, 1, 3, false)]
        [TestCase(1, 2, 2, 2, false)]
        [TestCase(-1, 1, -1, 1, true)]
        public void EqualsTest_TwoComplexNumbers_ExpectedResult(
            double re1, double im1, double re2, double im2, bool expected)
        {
            var complex1 = new ComplexNumber(re1, im1);
            var complex2 = new ComplexNumber(re2, im2);
            bool result = complex1.Equals(complex2);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void EqualsTest_NullObject_ReturnsFalse()
        {
            var complex = new ComplexNumber(1, 2);
            bool result = complex.Equals(null);
            Assert.That(result, Is.False);
        }

        [Test]
        public void EqualsTest_DifferentType_ReturnsFalse()
        {
            var complex = new ComplexNumber(1, 2);
            string other = "not a complex number";
            bool result = complex.Equals(other);
            Assert.That(result, Is.False);
        }

        [Test]
        public void GetHashCodeTest_EqualObjects_EqualHashCodes()
        {
            var complex1 = new ComplexNumber(3.14, 2.71);
            var complex2 = new ComplexNumber(3.14, 2.71);
            Assert.That(complex1.GetHashCode(), Is.EqualTo(complex2.GetHashCode()));
        }

        [Test]
        public void GetHashCodeTest_DifferentObjects_DifferentHashCodes()
        {
            var complex1 = new ComplexNumber(3.14, 2.71);
            var complex2 = new ComplexNumber(1.23, 4.56);
            Assert.That(complex1.GetHashCode(), Is.Not.EqualTo(complex2.GetHashCode()));
        }

        [Test]
        public void EqualityOperatorTest_EqualNumbers_ReturnsTrue()
        {
            var complex1 = new ComplexNumber(5.5, 7.7);
            var complex2 = new ComplexNumber(5.5, 7.7);
            Assert.That(complex1 == complex2, Is.True);
        }

        [Test]
        public void EqualityOperatorTest_DifferentNumbers_ReturnsFalse()
        {
            var complex1 = new ComplexNumber(5.5, 7.7);
            var complex2 = new ComplexNumber(5.5, 8.8);
            Assert.That(complex1 == complex2, Is.False);
        }

        [Test]
        public void InequalityOperatorTest_EqualNumbers_ReturnsFalse()
        {
            var complex1 = new ComplexNumber(5.5, 7.7);
            var complex2 = new ComplexNumber(5.5, 7.7);
            Assert.That(complex1 != complex2, Is.False);
        }

        [Test]
        public void InequalityOperatorTest_DifferentNumbers_ReturnsTrue()
        {
            var complex1 = new ComplexNumber(5.5, 7.7);
            var complex2 = new ComplexNumber(5.5, 8.8);
            Assert.That(complex1 != complex2, Is.True);
        }

        [TestCase(1, 2, 3, 4, 4, 6)]
        [TestCase(-1, -2, -3, -4, -4, -6)]
        [TestCase(1, -2, 3, 4, 4, 2)]
        [TestCase(0, 0, 5, 6, 5, 6)]
        public void AdditionTest_ComplexNumbers_CorrectSum(
            double re1, double im1, double re2, double im2,
            double expectedRe, double expectedIm)
        {
            var complex1 = new ComplexNumber(re1, im1);
            var complex2 = new ComplexNumber(re2, im2);
            var expected = new ComplexNumber(expectedRe, expectedIm);
            var result = complex1 + complex2;
            Assert.That(result.Re, Is.EqualTo(expected.Re).Within(Delta));
            Assert.That(result.Im, Is.EqualTo(expected.Im).Within(Delta));
        }

        [TestCase(5, 7, 3, 2, 2, 5)]
        [TestCase(-5, -7, -3, -2, -2, -5)]
        [TestCase(10, 20, 3, 4, 7, 16)]
        [TestCase(0, 0, 5, 6, -5, -6)]
        public void SubtractionTest_ComplexNumbers_CorrectDifference(
            double re1, double im1, double re2, double im2,
            double expectedRe, double expectedIm)
        {
            var complex1 = new ComplexNumber(re1, im1);
            var complex2 = new ComplexNumber(re2, im2);
            var expected = new ComplexNumber(expectedRe, expectedIm);
            var result = complex1 - complex2;
            Assert.That(result.Re, Is.EqualTo(expected.Re).Within(Delta));
            Assert.That(result.Im, Is.EqualTo(expected.Im).Within(Delta));
        }

        [Test]
        public void AdditionTest_WithZero_ReturnsSameNumber()
        {
            var complex = new ComplexNumber(3.14, 2.71);
            var zero = new ComplexNumber(0, 0);
            var result = complex + zero;
            Assert.That(result.Re, Is.EqualTo(complex.Re).Within(Delta));
            Assert.That(result.Im, Is.EqualTo(complex.Im).Within(Delta));
        }

        [Test]
        public void SubtractionTest_SameNumber_ReturnsZero()
        {
            var complex = new ComplexNumber(3.14, 2.71);
            var result = complex - complex;
            Assert.That(result.Re, Is.EqualTo(0).Within(Delta));
            Assert.That(result.Im, Is.EqualTo(0).Within(Delta));
        }

        [TestCase(1, 2, -1, -2)]
        [TestCase(-1, -2, 1, 2)]
        [TestCase(0, 5, 0, -5)]
        public void UnaryMinusTest_ComplexNumber_ReturnsNegated(double re, double im, double expectedRe, double expectedIm)
        {
            var complex = new ComplexNumber(re, im);
            var expected = new ComplexNumber(expectedRe, expectedIm);
            var result = -complex;
            Assert.That(result.Re, Is.EqualTo(expected.Re).Within(Delta));
            Assert.That(result.Im, Is.EqualTo(expected.Im).Within(Delta));
        }
    }
}