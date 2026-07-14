/*****************************************************************************************
  File   : 03-Execute-Stored-Procedure.sql
  Skill  : Advanced SQL - Stored Procedures (executing)
  Schema : Employee Management System (this doc's variant: 1 HR, 2 IT, 3 Finance)
  Topic  : Creating a parameterized proc and EXECUTING it

  Exercise 4 - "Execute a Stored Procedure":
    (Re)create sp_GetEmployeesByDepartment(@DepartmentID), then EXEC it for a
    specific department and review the results.

  I show BOTH ways to pass the parameter:
    - named    : EXEC ... @DepartmentID = 2
    - positional: EXEC ... 2

  Self-contained: schema + sample data + proc. Re-runnable (drops first).
*****************************************************************************************/

-------------------------------------------------------------------------------
-- 0) Idempotent cleanup
-------------------------------------------------------------------------------
IF OBJECT_ID('dbo.sp_GetEmployeesByDepartment', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_GetEmployeesByDepartment;
IF OBJECT_ID('dbo.Employees',   'U') IS NOT NULL DROP TABLE dbo.Employees;
IF OBJECT_ID('dbo.Departments', 'U') IS NOT NULL DROP TABLE dbo.Departments;
GO

-------------------------------------------------------------------------------
-- 1) Schema + 2) Sample data (this doc's variant: 1 HR, 2 IT, 3 Finance)
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
-- 3) (Re)create the proc to execute.
-------------------------------------------------------------------------------
CREATE PROCEDURE dbo.sp_GetEmployeesByDepartment
    @DepartmentID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT EmployeeID, FirstName, LastName, DepartmentID, Salary, JoinDate
    FROM dbo.Employees
    WHERE DepartmentID = @DepartmentID;
END;
GO

-------------------------------------------------------------------------------
-- 4) Exercise 4 - EXECUTE the procedure.
-------------------------------------------------------------------------------

-- Style 1 - NAMED parameter (most readable, order-independent):
EXEC dbo.sp_GetEmployeesByDepartment @DepartmentID = 2;   -- IT department

-- Style 2 - POSITIONAL parameter (value passed in declared order):
EXEC dbo.sp_GetEmployeesByDepartment 2;                   -- same result as above
GO

/*  Expected output for DepartmentID = 2 (IT):
    EmployeeID  FirstName  LastName  DepartmentID  Salary    JoinDate
    2           Jane       Smith     2             6000.00   2019-03-22

  Try another department to review different results:
*/
EXEC dbo.sp_GetEmployeesByDepartment @DepartmentID = 3;   -- Finance
/*  Expected:
    EmployeeID  FirstName  LastName  DepartmentID  Salary    JoinDate
    3           Bob        Johnson   3             5500.00   2021-07-01
*/
GO
