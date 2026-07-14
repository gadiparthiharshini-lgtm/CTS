/*****************************************************************************************
  File   : 02-Return-Data-from-Scalar-Function.sql
  Skill  : Advanced SQL - User Defined Functions (scalar)
  Schema : Employee Management System (this doc's variant: 1 HR, 2 IT, 3 Finance)
  Topic  : Creating and using a scalar UDF that RETURNS a single value

  Prerequisite: create scalar function fn_CalculateAnnualSalary(@Salary) = @Salary * 12.

  Exercise 7 - "Return Data from a Scalar Function":
    Execute fn_CalculateAnnualSalary for EmployeeID = 1 and verify the result.

  Self-contained: schema + sample data + function. Re-runnable (drops first).
*****************************************************************************************/

-------------------------------------------------------------------------------
-- 0) Idempotent cleanup
-------------------------------------------------------------------------------
IF OBJECT_ID('dbo.fn_CalculateAnnualSalary', 'FN') IS NOT NULL
    DROP FUNCTION dbo.fn_CalculateAnnualSalary;
IF OBJECT_ID('dbo.Employees',   'U') IS NOT NULL DROP TABLE dbo.Employees;
IF OBJECT_ID('dbo.Departments', 'U') IS NOT NULL DROP TABLE dbo.Departments;
GO

-------------------------------------------------------------------------------
-- 1) Schema + 2) Sample data (this doc's variant)
--    Departments: 1 HR, 2 IT, 3 Finance
--    Employees  : John Doe (HR), Jane Smith (IT), Bob Johnson (Finance)
-------------------------------------------------------------------------------
CREATE TABLE dbo.Departments (
    DepartmentID   INT          PRIMARY KEY,
    DepartmentName VARCHAR(100) NOT NULL
);

CREATE TABLE dbo.Employees (
    EmployeeID   INT           PRIMARY KEY,
    FirstName    VARCHAR(50)   NOT NULL,
    LastName     VARCHAR(50)   NOT NULL,
    DepartmentID INT           NULL,
    Salary       DECIMAL(10,2) NOT NULL,
    JoinDate     DATE          NOT NULL,
    CONSTRAINT FK_Employees_Departments FOREIGN KEY (DepartmentID)
        REFERENCES dbo.Departments (DepartmentID)
);
GO

INSERT INTO dbo.Departments (DepartmentID, DepartmentName) VALUES
    (1, 'HR'), (2, 'IT'), (3, 'Finance');

INSERT INTO dbo.Employees (EmployeeID, FirstName, LastName, DepartmentID, Salary, JoinDate) VALUES
    (1, 'John', 'Doe',     1, 5000.00, '2020-01-15'),
    (2, 'Jane', 'Smith',   2, 6000.00, '2019-03-22'),
    (3, 'Bob',  'Johnson', 3, 5500.00, '2021-07-01');
GO

-------------------------------------------------------------------------------
-- 3) Prerequisite scalar function: annual salary = monthly salary * 12.
--    A scalar UDF takes input(s) and RETURNS one scalar value.
-------------------------------------------------------------------------------
CREATE FUNCTION dbo.fn_CalculateAnnualSalary (@Salary DECIMAL(10,2))
RETURNS DECIMAL(10,2)
AS
BEGIN
    RETURN @Salary * 12;
END;
GO

-------------------------------------------------------------------------------
-- 4) Exercise 7 - execute the function for EmployeeID = 1 and verify.
--    Scalar functions must be called with the schema prefix (dbo.).
-------------------------------------------------------------------------------
SELECT
    FirstName,
    Salary,
    dbo.fn_CalculateAnnualSalary(Salary) AS AnnualSalary
FROM dbo.Employees
WHERE EmployeeID = 1;
GO

/*  Expected output (John Doe, monthly 5000 -> annual 60000):
    FirstName  Salary    AnnualSalary
    ---------  --------  ------------
    John       5000.00   60000.00
*/

-- Bonus: call it on every employee to show it works row-by-row.
SELECT EmployeeID, FirstName, Salary,
       dbo.fn_CalculateAnnualSalary(Salary) AS AnnualSalary
FROM dbo.Employees;
/*  Expected:
    1  John  5000.00  60000.00
    2  Jane  6000.00  72000.00
    3  Bob   5500.00  66000.00
*/
GO
