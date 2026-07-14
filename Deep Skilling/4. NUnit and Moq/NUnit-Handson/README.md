# NUnit Hands-On — Calculator Addition Tests

## Scenario / Objectives

Validate a calculator's **addition** operation using the **NUnit** testing
framework. This hands-on demonstrates the full NUnit test lifecycle and the
modern constraint-based assertion model.

Objectives:

- Create a `CalcLibrary` class library with a `Calculator` class.
- Create a separate NUnit test project that references `CalcLibrary`.
- Write a `CalculatorTests` fixture using `[TestFixture]`, `[SetUp]`,
  `[TearDown]`.
- Write a **parameterized** addition test using `[TestCase]` to feed inputs and
  expected results.
- Assert actual vs. expected using the constraint model:
  `Assert.That(actual, Is.EqualTo(expected))`.

---

## Concepts

### Unit testing vs. functional testing

| | Unit testing | Functional (system) testing |
|---|---|---|
| **Scope** | A single unit (class/method) in isolation | The whole feature/workflow end-to-end |
| **Dependencies** | Mocked/stubbed away | Real (DB, network, UI) |
| **Speed** | Milliseconds | Seconds–minutes |
| **Who runs it** | Developers, on every build | QA / automated suites |
| **Goal** | "Does this method behave correctly?" | "Does the system meet the requirement?" |

Here we unit-test `Calculator.Addition` in isolation — no UI, no I/O.

### NUnit attributes

- **`[TestFixture]`** — marks a class as a container of tests.
- **`[SetUp]`** — method run **before every** test; used to create a fresh SUT
  so tests don't share state.
- **`[TearDown]`** — method run **after every** test; used to release resources
  (here we null the reference; for `IDisposable` SUTs we'd call `Dispose()`).
- **`[Test]`** — marks a single test method.
- **`[TestCase(...)]`** — supplies a row of inputs + expected result, turning one
  method into many data-driven tests (positive, negative, zero, decimals).

### `Assert.That` constraint model

NUnit 4.x emphasizes the **constraint model**:

```csharp
Assert.That(actual, Is.EqualTo(expected));
Assert.That(actual, Is.EqualTo(expected).Within(0.0001)); // tolerance for doubles
```

It reads naturally (`actual` **is equal to** `expected`) and composes with
constraints like `Within`, `GreaterThan`, `Throws`, etc. The classic
`Assert.AreEqual(expected, actual)` style is discouraged in NUnit 4, which is
why this exercise uses `Assert.That`. A small tolerance (`.Within`) is used for
floating-point cases such as `1.1 + 2.2` which is not exactly `3.3` in binary.

---

## Project structure

```
NUnit-Handson/
├── README.md
├── CalcLibrary/
│   ├── Calculator.cs            # Calculator class (Addition + extras)
│   └── CalcLibrary.csproj        # classlib, net8.0
└── CalcLibrary.Tests/
    ├── CalculatorTests.cs        # [TestFixture] with [SetUp]/[TearDown]/[TestCase]
    └── CalcLibrary.Tests.csproj  # net8.0 test project (NUnit 4.x) + ProjectReference
```

---

## How to set up / run

### Create the projects (from scratch, for reference)

```bash
# library under test
dotnet new classlib -n CalcLibrary -f net8.0

# test project
dotnet new nunit -n CalcLibrary.Tests -f net8.0
dotnet add CalcLibrary.Tests reference CalcLibrary
```

### NuGet packages (already listed in the test .csproj)

```bash
dotnet add CalcLibrary.Tests package NUnit --version 4.2.2
dotnet add CalcLibrary.Tests package NUnit3TestAdapter --version 4.6.0
dotnet add CalcLibrary.Tests package Microsoft.NET.Test.Sdk --version 17.11.1
```

### Run the tests

```bash
# from the NUnit-Handson folder
dotnet test
```

### Run from Visual Studio

1. Open the solution / folder in Visual Studio 2022.
2. **Test → Test Explorer**.
3. Build the solution; tests appear in the tree.
4. Click **Run All**. Green checkmarks indicate passing tests.

---

## Expected result

All addition test cases pass (green). Sample cases:

| a | b | expected | result |
|----|----|----------|--------|
| 2 | 3 | 5 | Pass |
| -2 | -3 | -5 | Pass |
| -5 | 5 | 0 | Pass |
| 0 | 0 | 0 | Pass |
| 0 | 7 | 7 | Pass |
| 2.5 | 2.5 | 5.0 | Pass |
| 1.1 | 2.2 | 3.3 | Pass (within tolerance) |

Sample console output:

```
Passed!  - Failed: 0, Passed: 7, Skipped: 0, Total: 7
```

---

## Key takeaways

- Keep production code (`CalcLibrary`) and test code (`CalcLibrary.Tests`) in
  **separate projects**; the test project references the library.
- `[SetUp]`/`[TearDown]` keep each test **independent and repeatable**.
- `[TestCase]` makes tests **data-driven** — one method, many scenarios.
- Prefer the **constraint model** (`Assert.That`) in NUnit 4.x.
- Use a **tolerance** when comparing floating-point numbers.
