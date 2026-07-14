# Advanced SQL (T-SQL / SQL Server) — Hands-On Solutions

Part of the **Cognizant Digital Nurture – .NET FSE Deepskilling** program.

This folder contains my worked solutions for the **Advanced SQL** hands-on exercises.
All scripts are written in **T-SQL** for **Microsoft SQL Server** and are **self-contained**:
each `.sql` file creates its own schema, inserts sample data, then runs the solution
queries — so any script can be opened and executed on its own.

---

## Mandatory hands-on

| Skill | Filename | Exercise |
|-------|----------|----------|
| Ranking / Window Functions | `Mandatory/01-Ranking-and-Window-Functions.sql` | Exercise 1 – Top 3 most expensive products per category with `ROW_NUMBER` / `RANK` / `DENSE_RANK` |
| Stored Procedures | `Mandatory/02-Create-Stored-Procedure.sql` | Exercise 1 – Create a Stored Procedure (`sp_GetEmployeesByDepartment`, `sp_InsertEmployee`) |
| Stored Procedures (return data) | `Mandatory/03-Return-Data-from-Stored-Procedure.sql` | Exercise 5 – Return Data from a Stored Procedure (`sp_GetEmployeeCountByDepartment`) |

## Additional hands-on

| Skill | Filename | Exercise |
|-------|----------|----------|
| Indexes | `Additional/01-Index-Handson.sql` | Exercises 1–3 – Non-clustered, clustered, and composite indexes |
| Scalar Functions | `Additional/02-Return-Data-from-Scalar-Function.sql` | Exercise 7 – Return Data from a Scalar Function (`fn_CalculateAnnualSalary`) |
| Stored Procedures (execute) | `Additional/03-Execute-Stored-Procedure.sql` | Exercise 4 – Execute a Stored Procedure (`sp_GetEmployeesByDepartment`) |

---

## What each script demonstrates

### Mandatory

- **01 – Ranking and Window Functions** *(Online Retail Store schema)*
  Uses `ROW_NUMBER()`, `RANK()` and `DENSE_RANK()` with `PARTITION BY Category ORDER BY Price DESC`
  to find the top 3 most expensive products per category. Sample data includes deliberate
  **price ties** so the difference between the three functions is clearly visible (`ROW_NUMBER`
  is always unique; `RANK` leaves gaps after ties; `DENSE_RANK` does not). Includes a CTE that
  filters to the top 3 per category.
  **Key concept:** window/ranking functions.

- **02 – Create Stored Procedure** *(Employee Management System schema)*
  Creates `sp_GetEmployeesByDepartment` (parameterized `SELECT` by `@DepartmentID`) and
  `sp_InsertEmployee` (parameterized `INSERT`). Includes example `EXEC` calls with expected output.
  **Key concept:** creating parameterized stored procedures.

- **03 – Return Data from a Stored Procedure** *(Employee schema)*
  Creates `sp_GetEmployeeCountByDepartment`, which counts employees in a department and returns
  the value three ways: as a **result set**, via an **OUTPUT parameter**, and via a **RETURN** value.
  **Key concept:** returning values from stored procedures (result set vs OUTPUT vs RETURN).

### Additional

- **01 – Index Hands-on** *(Online Retail Store schema)*
  Implements a **non-clustered** index on `Products.ProductName`, a **clustered** index on
  `Orders.OrderDate` (with notes on why the PK is declared `NONCLUSTERED` first, since a table
  can have only one clustered index), and a **composite** index on `Orders(CustomerID, OrderDate)`.
  Includes before/after queries plus guidance on `SET STATISTICS TIME/IO` and the actual execution
  plan to compare **seek vs scan**.
  **Key concept:** index types and how they improve query performance.

- **02 – Return Data from a Scalar Function** *(Employee schema variant: HR / IT / Finance)*
  Creates the scalar function `fn_CalculateAnnualSalary(@Salary)` returning `@Salary * 12`, then
  calls it for `EmployeeID = 1` and verifies the annual salary.
  **Key concept:** scalar user-defined functions returning a single value.

- **03 – Execute Stored Procedure** *(Employee schema variant: HR / IT / Finance)*
  (Re)creates `sp_GetEmployeesByDepartment` and executes it for a specific department, showing
  both **named** and **positional** parameter styles with expected output.
  **Key concept:** executing stored procedures.

---

## How to run

1. Open the `.sql` file in **SQL Server Management Studio (SSMS)** or **Azure Data Studio**.
2. Connect to any test database (e.g. create one with `CREATE DATABASE AdvancedSqlDemo;`
   then `USE AdvancedSqlDemo;`). Do **not** run against a production database.
3. Execute the whole script (F5). Each script is self-contained — it creates the schema and
   sample data, so there is no setup needed beforehand.
4. For the index hands-on (`Additional/01`), enable **Include Actual Execution Plan** (Ctrl+M)
   and read the `STATISTICS TIME` / `STATISTICS IO` messages to compare performance before and
   after each index.

> **Note:** Scripts are written for **Microsoft SQL Server (T-SQL)** and use SQL Server specifics
> such as `GO` batch separators, `OBJECT_ID(...)` existence checks, and `OUTPUT` parameters.
> They are idempotent — re-running drops and recreates the objects.
