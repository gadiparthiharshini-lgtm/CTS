# Exercise 7 — Financial Forecasting

## Scenario / Goal
Build a financial forecasting tool that predicts future values based on past
data. Given a present value and an assumed annual growth rate, project the
investment forward year by year, implement the projection **recursively**, then
discuss and apply optimizations to avoid excessive computation.

> Implemented in **C# (.NET 8)**.

## Concept — Recursion
**Recursion** is when a method solves a problem by calling itself on a smaller
version of the same problem until it reaches a **base case** that can be answered
directly. It simplifies problems that are naturally self-similar: you describe the
solution in terms of "the answer to a slightly smaller problem", and the call
stack handles the bookkeeping for you.

### Future value as a recurrence
The future value of an investment after `n` years at a constant growth rate `r`:

```
FutureValue(pv, r, 0) = pv                              (base case)
FutureValue(pv, r, n) = FutureValue(pv, r, n-1) * (1+r) (recursive case)
```

This unrolls to the familiar compound-interest formula
`FutureValue = pv * (1 + r)^n`.

### Time complexity — naive vs optimized

| Implementation                    | Calls per level | Time   | Space   |
|-----------------------------------|-----------------|--------|---------|
| Recursive `FutureValue`           | 1               | O(n)   | O(n) stack |
| Iterative `FutureValueIterative`  | —               | O(n)   | O(1)    |

The future-value recursion makes **one** call per level, so it is already `O(n)`
in time. Its only weakness is `O(n)` **call-stack space** (and stack-overflow risk
for very large horizons). Converting it to a simple loop keeps the `O(n)` time but
drops to `O(1)` space.

### The real recursion pitfall: overlapping sub-problems
The danger appears when a recursion branches and re-computes the same sub-problem
many times. The classic example is naive Fibonacci:

```
Fib(n) = Fib(n-1) + Fib(n-2)   // two recursive calls each level
```

This forms a binary call tree and costs roughly **O(2^n)** — `Fib(30)` triggers
over a million calls. The fix:

- **Memoization** — cache each sub-result the first time it is computed and reuse
  it thereafter. Every distinct value is computed once → **O(n)**.
- **Convert to iteration** (bottom-up) — build results from the base cases upward,
  also **O(n)** time with **O(1)** space.

This exercise includes `FibonacciNaive` (O(2^n)) and `FibonacciMemoized` (O(n))
to make the optimization concrete.

## Project structure
```
Exercise7-FinancialForecasting/
├── FinancialForecasting.csproj   # net8.0 console app
├── ForecastService.cs            # recursive + iterative FV, naive + memoized Fib
├── Program.cs                    # demo: year-by-year table, optimization check
└── README.md
```

## How to run
```bash
cd Exercise7-FinancialForecasting
dotnet run
```

## Expected output
> Currency is formatted with the machine's current culture; the values below use
> `en-US` (`$`). On a different locale the symbol/separators may vary, but the
> numbers are the same.

```
=== Financial Forecasting Tool ===

Present value : $10,000.00
Annual growth : 8 %
Horizon       : 10 years

Year | Projected Value (recursive)
-----|----------------------------
   0 |      $10,000.00
   1 |      $10,800.00
   2 |      $11,664.00
   3 |      $12,597.12
   4 |      $13,604.89
   5 |      $14,693.28
   6 |      $15,868.74
   7 |      $17,138.24
   8 |      $18,509.30
   9 |      $19,990.05
  10 |      $21,589.25

Recursive  result after 10 years: $21,589.25
Iterative  result after 10 years: $21,589.25
Results match (the optimized version is equivalent).

=== Recursion pitfall: overlapping sub-problems ===
Fibonacci(30) naive    = 832040   // ~O(2^n): recomputes sub-results
Fibonacci(30) memoized = 832040   // O(n): each sub-result cached once

Takeaway: naive future-value recursion is already O(n) (one call per year),
but any recursion with overlapping sub-problems (like Fibonacci) explodes to
O(2^n). Memoization or converting to iteration brings it back to O(n).
```

## Key takeaways
- Recursion expresses self-similar problems via a base case + a smaller sub-problem.
- The future-value recurrence equals compound interest `pv * (1+r)^n`.
- Linear (single-branch) recursion like future value is `O(n)`; converting to a
  loop removes the `O(n)` stack cost.
- Branching recursion with overlapping sub-problems (Fibonacci) is `O(2^n)`;
  **memoization** or **iteration** optimizes it to `O(n)`.
