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

        [Test]
        public void Addition_ShouldReturn30_WhenAdding10And20()
        {
            double result = calculator.Addition(10, 20);

            Assert.That(result, Is.EqualTo(30));
        }
    }
}