# Moq Hands-On — Write Testable Code with Moq

## Scenario / Objectives

A class needs to **send mail to customers** through an SMTP mail server. The real
mail-sending code (`SmtpClient`) hits an external server, so it cannot be unit
tested directly. We refactor to an **`IMailSender` interface** and inject it,
then use **Moq** to mock that interface so `CustomerComm` can be tested in
isolation — no network, no SMTP server.

Objectives:

- Build a `CustomerCommLib` library with:
  - `IMailSender` — `bool SendMail(string toAddress, string message)`.
  - `MailSender : IMailSender` — real SMTP implementation (untestable).
  - `CustomerComm` — depends on `IMailSender` via **constructor injection**;
    `SendMailToCustomer()` calls `SendMail(...)` and returns `true`.
- Build a `CustomerComm.Tests` project (NUnit + Moq) that **mocks**
  `IMailSender` to always return `true`, and asserts `SendMailToCustomer()`
  returns `true`.

---

## Concepts

### Mocking and why we need it

`MailSender` depends on an SMTP server. Calling it from a unit test would be
slow, flaky, and might actually send email. **Mocking** replaces that real
dependency with an in-memory, programmable substitute so the test stays fast,
deterministic, and isolated.

### Test doubles: mock vs. fake vs. stub

- **Stub** — returns canned answers to calls (provides indirect *input*).
- **Mock** — a stub that also lets you **verify interactions** (e.g. "SendMail
  was called once"). Created here with `new Mock<IMailSender>()`.
- **Fake** — a working but lightweight implementation (e.g. an in-memory list
  instead of a database), not suitable for production.

Moq creates **mocks** (which can also act as stubs).

### Dependency injection (constructor injection) → testability

`CustomerComm` does **not** create its own `MailSender`. Instead the dependency
is passed into the constructor:

```csharp
public CustomerComm(IMailSender mailSender) { _mailSender = mailSender; }
```

This **inversion of control** means production code can pass a real
`MailSender`, while tests can pass `mock.Object`. Without DI, `CustomerComm`
would be hard-wired to SMTP and untestable.

### Isolating external dependencies (SMTP) in tests

Because `CustomerComm` depends on the `IMailSender` **abstraction**, the test
swaps in a mock:

```csharp
mock.Setup(x => x.SendMail(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
```

`It.IsAny<string>()` matches any argument, so the mock accepts whatever address
and message `CustomerComm` passes and always returns `true` — completely
bypassing the real SMTP server.

> Note: `SmtpClient` is obsolete in modern .NET (MailKit is recommended for
> production), but it ships with .NET 8 and is used here per the exercise.

---

## Project structure

```
Moq-Handson/
├── README.md
├── CustomerCommLib/
│   ├── IMailSender.cs            # interface: bool SendMail(toAddress, message)
│   ├── MailSender.cs            # real SMTP implementation (untestable)
│   ├── CustomerComm.cs          # SUT: constructor-injected IMailSender
│   └── CustomerCommLib.csproj    # classlib, net8.0
└── CustomerComm.Tests/
    ├── CustomerCommTests.cs      # [TestFixture] + [OneTimeSetUp] + Moq mock
    └── CustomerComm.Tests.csproj # net8.0 test project (NUnit 4.x + Moq) + ProjectReference
```

---

## How to set up / run

### Create the projects (from scratch, for reference)

```bash
dotnet new classlib -n CustomerCommLib -f net8.0

dotnet new nunit -n CustomerComm.Tests -f net8.0
dotnet add CustomerComm.Tests reference CustomerCommLib
```

### NuGet packages (already listed in the test .csproj)

```bash
dotnet add CustomerComm.Tests package NUnit --version 4.2.2
dotnet add CustomerComm.Tests package NUnit3TestAdapter --version 4.6.0
dotnet add CustomerComm.Tests package Microsoft.NET.Test.Sdk --version 17.11.1
dotnet add CustomerComm.Tests package Moq --version 4.20.72
```

### Run the tests

```bash
# from the Moq-Handson folder
dotnet test
```

### Run from Visual Studio

1. Open in Visual Studio 2022.
2. **Test → Test Explorer**.
3. Build, then **Run All**. Green check = pass.

---

## Expected result

The test passes (green) without touching any SMTP server.

| Test | Assertion | Result |
|------|-----------|--------|
| `SendMailToCustomer_WhenCalled_ReturnsTrue` | `Assert.That(result, Is.True)` | Pass |

Sample console output:

```
Passed!  - Failed: 0, Passed: 1, Skipped: 0, Total: 1
```

---

## Key takeaways

- Depend on **abstractions** (`IMailSender`), not concrete classes, to enable
  substitution in tests.
- **Constructor injection** is what makes the class mockable.
- Use **Moq** (`Mock<T>`, `.Setup(...)`, `.Returns(...)`, `It.IsAny<T>()`) to
  isolate the unit from slow/external dependencies like SMTP.
- `[OneTimeSetUp]` runs setup **once** per fixture (vs. `[SetUp]` per test) —
  fine here because the mock is immutable across the test(s).
- A unit test should never depend on real email, databases, or networks.
