using CalcLibrary;
using NUnit.Framework;

namespace CalcLibrary.Tests
{
    /// <summary>
    /// Unit tests for the <see cref="Calculator"/> class.
    /// Demonstrates the NUnit lifecycle attributes ([TestFixture], [SetUp],
    /// [TearDown]) and parameterized tests via [TestCase], using the modern
    /// NUnit constraint model (Assert.That) introduced/required in NUnit 4.x.
    /// </summary>
    [TestFixture]
    public class CalculatorTests
    {
        // The system under test. Re-created fresh before every test method
        // so that one test never leaks state into another.
        private Calculator _calculator;

        /// <summary>
        /// Runs BEFORE each test method.
        /// Used to create/initialize the object(s) needed by the test.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
        }

        /// <summary>
        /// Runs AFTER each test method.
        /// Used to clean up resources. Calculator holds no unmanaged resources,
        /// so we simply drop the reference. If the SUT implemented IDisposable
        /// we would call _calculator.Dispose() here instead.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            _calculator = null;
        }

        /// <summary>
        /// Validates the addition operation across a range of inputs.
        /// Each [TestCase] row supplies two inputs and the expected result.
        /// </summary>
        /// <param name="a">First operand.</param>
        /// <param name="b">Second operand.</param>
        /// <param name="expected">Expected sum.</param>
        [Test]
        [TestCase(2, 3, 5)]            // positive + positive
        [TestCase(-2, -3, -5)]         // negative + negative
        [TestCase(-5, 5, 0)]           // negative + positive => zero
        [TestCase(0, 0, 0)]            // zero + zero
        [TestCase(0, 7, 7)]            // zero + positive
        [TestCase(2.5, 2.5, 5.0)]      // decimals
        [TestCase(1.1, 2.2, 3.3)]      // decimals (note: float rounding handled by tolerance below)
        public void Addition_VariousInputs_ReturnsExpectedSum(double a, double b, double expected)
        {
            // Act
            double actual = _calculator.Addition(a, b);

            // Assert (constraint model). A small tolerance protects against
            // binary floating-point rounding (e.g. 1.1 + 2.2 != exactly 3.3).
            Assert.That(actual, Is.EqualTo(expected).Within(0.0001));
        }
    }
}
