using NUnit.Framework;
using CalcLibrary;

namespace CalcLibrary.Tests
{
    public class Tests
    {
        private SimpleCalculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new SimpleCalculator();
        }

        [TestCase(10, 20, 30)]
        [TestCase(100, 200, 300)]
        [TestCase(5, 5, 10)]
        [TestCase(-5, 10, 5)]
        public void Addition_ShouldReturnExpectedResult(double a, double b, double expected)
        {
            double actual = calculator.Addition(a, b);

            Assert.That(actual, Is.EqualTo(expected));
        }
        [TestCase(30, 20, 10)]
        [TestCase(100, 50, 50)]
        [TestCase(10, 5, 5)]
        [TestCase(-5, -5, 0)]
        public void Subtraction_ShouldReturnExpectedResult(double a, double b, double expected)
        {
            double actual = calculator.Subtraction(a, b);

            Assert.That(actual, Is.EqualTo(expected));
        }
        [TestCase(10, 20, 200)]
        [TestCase(5, 5, 25)]
        [TestCase(0, 100, 0)]
        [TestCase(-5, 10, -50)]
        public void Multiplication_ShouldReturnExpectedResult(double a, double b, double expected)
        {
            double actual = calculator.Multiplication(a, b);

            Assert.That(actual, Is.EqualTo(expected));
        }
        [TestCase(10, 2, 5)]
        [TestCase(20, 4, 5)]
        [TestCase(100, 10, 10)]
        [TestCase(-20, 5, -4)]
        public void Division_ShouldReturnExpectedResult(double a, double b, double expected)
        {
            double actual = calculator.Division(a, b);

            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void Division_ByZero_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                calculator.Division(10, 0);
            });
        }
    }
}