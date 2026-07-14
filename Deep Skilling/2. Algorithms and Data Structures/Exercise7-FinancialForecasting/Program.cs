using FinancialForecasting;

// ---------------------------------------------------------------------------
// Exercise 7 - Financial Forecasting
// Projects an investment forward using a recursive future-value formula,
// prints a year-by-year table, then shows that the optimized (iterative)
// version produces the same result. Finally illustrates the exponential
// recursion pitfall via Fibonacci and how memoization fixes it.
// ---------------------------------------------------------------------------

Console.WriteLine("=== Financial Forecasting Tool ===\n");

// Sample scenario.
double presentValue = 10_000.0; // initial investment
double growthRate   = 0.08;     // 8% annual growth
int years           = 10;       // forecast horizon

Console.WriteLine($"Present value : {presentValue:C}");
Console.WriteLine($"Annual growth : {growthRate:P0}");
Console.WriteLine($"Horizon       : {years} years\n");

// Year-by-year projection using the recursive method.
Console.WriteLine("Year | Projected Value (recursive)");
Console.WriteLine("-----|----------------------------");
for (int year = 0; year <= years; year++)
{
    double value = ForecastService.FutureValue(presentValue, growthRate, year);
    Console.WriteLine($"{year,4} | {value,15:C}");
}
Console.WriteLine();

// Show the optimized iterative version matches the recursive one.
double recursiveFinal = ForecastService.FutureValue(presentValue, growthRate, years);
double iterativeFinal = ForecastService.FutureValueIterative(presentValue, growthRate, years);

Console.WriteLine($"Recursive  result after {years} years: {recursiveFinal:C}");
Console.WriteLine($"Iterative  result after {years} years: {iterativeFinal:C}");
Console.WriteLine(Math.Abs(recursiveFinal - iterativeFinal) < 1e-6
    ? "Results match (the optimized version is equivalent).\n"
    : "Results differ!\n");

// Demonstrate the recursion pitfall and the memoization optimization.
Console.WriteLine("=== Recursion pitfall: overlapping sub-problems ===");
int fibN = 30;
long fibNaive    = ForecastService.FibonacciNaive(fibN);
long fibMemoized = ForecastService.FibonacciMemoized(fibN);
Console.WriteLine($"Fibonacci({fibN}) naive    = {fibNaive}   // ~O(2^n): recomputes sub-results");
Console.WriteLine($"Fibonacci({fibN}) memoized = {fibMemoized}   // O(n): each sub-result cached once");
Console.WriteLine();
Console.WriteLine("Takeaway: naive future-value recursion is already O(n) (one call per year),");
Console.WriteLine("but any recursion with overlapping sub-problems (like Fibonacci) explodes to");
Console.WriteLine("O(2^n). Memoization or converting to iteration brings it back to O(n).");
