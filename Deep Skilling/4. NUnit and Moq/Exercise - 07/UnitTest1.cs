using NUnit.Framework;
using LeapYearCalculatorLib;

namespace LeapYearCalculatorLib.Tests
{
    public class LeapYearCalculatorTests
    {
        private LeapYearCalculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new LeapYearCalculator();
        }

        [TestCase(2000, 1)]
        [TestCase(2024, 1)]
        [TestCase(2028, 1)]
        public void IsLeapYear_ValidLeapYear_ReturnsOne(int year, int expected)
        {
            int result = calculator.IsLeapYear(year);

            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(2023, 0)]
        [TestCase(1900, 0)]
        [TestCase(2025, 0)]
        public void IsLeapYear_ValidNonLeapYear_ReturnsZero(int year, int expected)
        {
            int result = calculator.IsLeapYear(year);

            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(1700, -1)]
        [TestCase(10000, -1)]
        [TestCase(-5, -1)]
        public void IsLeapYear_InvalidYear_ReturnsMinusOne(int year, int expected)
        {
            int result = calculator.IsLeapYear(year);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}