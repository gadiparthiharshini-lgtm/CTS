# 4. NUnit and Moq — Hands-On Solutions

Unit-testing hands-on exercises for the Cognizant **Digital Nurture — .NET FSE
Deepskilling** program. Both projects target **.NET 8** and use **NUnit 4.x**.

## Index

| # | Hands-on | Description |
|---|----------|-------------|
| 1 | [NUnit-Handson](./NUnit-Handson/) | Validate a `Calculator.Addition` operation using NUnit `[TestFixture]`, `[SetUp]`, `[TearDown]`, `[TestCase]`, and the `Assert.That` constraint model. |
| 2 | [Moq-Handson](./Moq-Handson/) | Write testable code with **Moq**: mock an `IMailSender` (SMTP) dependency injected into `CustomerComm` so it can be unit tested in isolation. |

## Tooling

- Target framework: `net8.0`
- NUnit `4.2.2`, NUnit3TestAdapter `4.6.0`, Microsoft.NET.Test.Sdk `17.11.1`
- Moq `4.20.72` (Moq-Handson only)

Run any exercise with `dotnet test` from its subfolder, or via **Test Explorer**
in Visual Studio 2022.
