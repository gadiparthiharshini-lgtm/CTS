namespace FinancialForecasting;

/// <summary>
/// Financial forecasting helpers that project a present value forward in time
/// using a constant annual growth rate. Provides a naive recursive method, an
/// optimized iterative method, and a memoized example that illustrates how
/// memoization tames exponential recursion.
/// </summary>
public static class ForecastService
{
    /// <summary>
    /// Calculates a future value <b>recursively</b>:
    /// <c>FutureValue(pv, r, n) = FutureValue(pv, r, n-1) * (1 + r)</c>,
    /// with the base case <c>FutureValue(pv, r, 0) = pv</c>.
    /// </summary>
    /// <param name="presentValue">Starting amount (e.g. initial investment).</param>
    /// <param name="growthRate">Annual growth rate as a decimal (e.g. 0.08 for 8%).</param>
    /// <param name="years">Number of years to project forward (must be >= 0).</param>
    /// <returns>The projected value after <paramref name="years"/> years.</returns>
    /// <remarks>
    /// This recursion makes a <b>single</b> call per level, so its depth is
    /// <c>n</c> and its time complexity is <b>O(n)</b> with <b>O(n)</b> call-stack
    /// space. It is "naive" only in that it uses the stack where a loop would do;
    /// it is NOT exponential. (Contrast with <see cref="FibonacciNaive"/> below,
    /// which IS exponential.)
    /// </remarks>
    public static double FutureValue(double presentValue, double growthRate, int years)
    {
        if (years < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(years), "Years cannot be negative.");
        }

        // Base case: zero years left -> value is the present value.
        if (years == 0)
        {
            return presentValue;
        }

        // Recursive case: grow one year, then recurse on the remaining years.
        return FutureValue(presentValue, growthRate, years - 1) * (1 + growthRate);
    }

    /// <summary>
    /// <b>Optimized</b> iterative future-value calculation. Equivalent result to
    /// <see cref="FutureValue"/> but runs in O(n) time with O(1) space — no
    /// call-stack growth and no risk of stack overflow for large horizons.
    /// </summary>
    /// <param name="presentValue">Starting amount.</param>
    /// <param name="growthRate">Annual growth rate as a decimal.</param>
    /// <param name="years">Number of years to project forward (must be >= 0).</param>
    /// <returns>The projected value after <paramref name="years"/> years.</returns>
    public static double FutureValueIterative(double presentValue, double growthRate, int years)
    {
        if (years < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(years), "Years cannot be negative.");
        }

        double value = presentValue;
        for (int year = 0; year < years; year++)
        {
            value *= 1 + growthRate;
        }

        return value;
    }

    /// <summary>
    /// Naive Fibonacci to demonstrate the classic recursion pitfall:
    /// it re-computes the same sub-problems repeatedly, giving roughly
    /// <b>O(2^n)</b> time. Used in the demo to motivate memoization.
    /// </summary>
    public static long FibonacciNaive(int n)
    {
        if (n < 0) throw new ArgumentOutOfRangeException(nameof(n));
        if (n < 2) return n;                                  // base cases F(0)=0, F(1)=1
        return FibonacciNaive(n - 1) + FibonacciNaive(n - 2); // two branches => exponential
    }

    /// <summary>
    /// <b>Memoized</b> Fibonacci. By caching each sub-result, every value is
    /// computed once, collapsing the cost from O(2^n) down to <b>O(n)</b>.
    /// This is the optimization strategy for any recursion with overlapping
    /// sub-problems.
    /// </summary>
    public static long FibonacciMemoized(int n, Dictionary<int, long>? memo = null)
    {
        if (n < 0) throw new ArgumentOutOfRangeException(nameof(n));
        if (n < 2) return n;

        memo ??= new Dictionary<int, long>();
        if (memo.TryGetValue(n, out long cached))
        {
            return cached; // Already solved — reuse instead of recomputing.
        }

        long result = FibonacciMemoized(n - 1, memo) + FibonacciMemoized(n - 2, memo);
        memo[n] = result;
        return result;
    }
}
