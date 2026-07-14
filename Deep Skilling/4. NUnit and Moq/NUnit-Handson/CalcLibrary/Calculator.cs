namespace CalcLibrary
{
    /// <summary>
    /// A simple calculator class that provides basic arithmetic operations.
    /// This is the "system under test" (SUT) for the NUnit hands-on exercise.
    /// </summary>
    public class Calculator
    {
        /// <summary>
        /// Adds two numbers and returns the sum.
        /// This is the primary method validated by the unit tests.
        /// </summary>
        /// <param name="a">First operand.</param>
        /// <param name="b">Second operand.</param>
        /// <returns>The sum of <paramref name="a"/> and <paramref name="b"/>.</returns>
        public double Addition(double a, double b)
        {
            return a + b;
        }

        /// <summary>
        /// Subtracts <paramref name="b"/> from <paramref name="a"/>.
        /// Added for completeness; not the focus of the exercise.
        /// </summary>
        public double Subtraction(double a, double b)
        {
            return a - b;
        }

        /// <summary>
        /// Multiplies two numbers.
        /// Added for completeness; not the focus of the exercise.
        /// </summary>
        public double Multiplication(double a, double b)
        {
            return a * b;
        }

        /// <summary>
        /// Divides <paramref name="a"/> by <paramref name="b"/>.
        /// Throws <see cref="DivideByZeroException"/> when <paramref name="b"/> is zero.
        /// Added for completeness; not the focus of the exercise.
        /// </summary>
        public double Division(double a, double b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }

            return a / b;
        }
    }
}
