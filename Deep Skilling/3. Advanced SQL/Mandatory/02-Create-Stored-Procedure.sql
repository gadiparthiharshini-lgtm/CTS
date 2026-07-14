/*****************************************************************************************
  File   : 02-Create-Stored-Procedure.sql
  Skill  : Advanced SQL - Stored Procedures
  Schema : Employee Management System
  Topic  : Creating stored procedures (parameterized SELECT and parameterized INSERT)

  Exercise 1 - "Create a Stored Procedure":
    - sp_GetEmployeesByDepartment : takes @DepartmentID and returns employees in that dept.
    - sp_InsertEmployee           : takes employee details and INSERTs a new row.

  Self-contained: creates schema + sample data, then the procs. Re-runnable (drops first).
*****************************************************************************************/

-------------------------------------------------------------------------------
-- 0) Idempotent cleanup (drop procs + child table before parent table)
-------------------------------------------------------------------------------
IF OBJECT_ID('dbo.sp_GetEmployeesByDepartment', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_GetEmployeesByDepartment;
IF OBJECT_ID('dbo.sp_InsertEmployee', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_InsertEmployee;
IF OBJECT_ID('dbo.Employees',   'U') IS NOT NULL DROP TABLE dbo.Employees;
IF OBJECT_ID('dbo.Departments', 'U') IS NOT NULL DROP TABLE dbo.Departments;
GO

-------------------------------------------------------------------------------
-- 1) Schema : Employee Management System
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

-------------------------------------------------------------------------------
-- 2) Sample data (exactly as given in the hands-on doc)
-------------------------------------------------------------------------------
INSERT INTO dbo.Departments (DepartmentID, DepartmentName) VALUES
    (1, 'HR'),
    (2, 'Finance'),
    (3, 'IT'),
    (4, 'Marketing');

INSERT INTO dbo.Employees (EmployeeID, FirstName, LastName, DepartmentID, Salary, JoinDate) VALUES
    (1, 'John',    'Doe',     1, 5000.00, '2020-01-15'),
    (2, 'Jane',    'Smith',   2, 6000.00, '2019-03-22'),
    (3, 'Michael', 'Johnson', 3, 7000.00, '2018-07-30'),
    (4, 'Emily',   'Davis',   4, 5500.00, '2021-11-05');
GO

-------------------------------------------------------------------------------
-- 3) Exercise 1 - retrieval proc: employees by department.
--    A stored procedure lets us reuse this parameterized query by name.
-------------------------------------------------------------------------------
CREATE PROCEDURE dbo.sp_GetEmployeesByDepartment
    @DepartmentID INT
AS
BEGIN
    SET NOCOUNT ON;   -- suppress the "(n rows affected)" extra message

    SELECT EmployeeID, FirstName, LastName, DepartmentID, Salary, JoinDate
    FROM dbo.Employees
    WHERE DepartmentID = @DepartmentID;
END;
GO

-------------------------------------------------------------------------------
-- 4) Exercise 1 - insert proc (from the doc): add a new employee.
-------------------------------------------------------------------------------
CREATE PROCEDURE dbo.sp_InsertEmployee
    @FirstName    VARCHAR(50),
    @LastName     VARCHAR(50),
    @DepartmentID INT,
    @Salary       DECIMAL(10,2),
    @JoinDate     DATE
AS
BEGIN
    SET NOCOUNT ON;

    -- EmployeeID is not IDENTITY in this schema, so compute the next id.
    DECLARE @NextID INT = (SELECT ISNULL(MAX(EmployeeID), 0) + 1 FROM dbo.Employees);

    INSERT INTO dbo.Employees (EmployeeID, FirstName, LastName, DepartmentID, Salary, JoinDate)
    VALUES (@NextID, @FirstName, @LastName, @DepartmentID, @Salary, @JoinDate);
END;
GO

-------------------------------------------------------------------------------
-- 5) Example EXEC calls (run these to test).
-------------------------------------------------------------------------------

-- (a) Get all employees in IT (DepartmentID = 3):
EXEC dbo.sp_GetEmployeesByDepartment @DepartmentID = 3;
/*  Expected output:
    EmployeeID  FirstName  LastName  DepartmentID  Salary    JoinDate
    3           Michael    Johnson   3             7000.00   2018-07-30
*/

-- (b) Insert a new employee, then re-query the department to confirm:
EXEC dbo.sp_InsertEmployee
    @FirstName    = 'Sara',
    @LastName     = 'Lee',
    @DepartmentID = 3,
    @Salary       = 6500.00,
    @JoinDate     = '2022-05-10';

EXEC dbo.sp_GetEmployeesByDepartment @DepartmentID = 3;
/*  Expected output (now 2 rows in IT):
    EmployeeID  FirstName  LastName  DepartmentID  Salary    JoinDate
    3           Michael    Johnson   3             7000.00   2018-07-30
    5           Sara       Lee       3             6500.00   2022-05-10
*/
GO
