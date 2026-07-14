/*****************************************************************************************
  File   : 03-Return-Data-from-Stored-Procedure.sql
  Skill  : Advanced SQL - Stored Procedures (returning data)
  Schema : Employee Management System
  Topic  : Returning a value from a stored procedure

  Exercise 5 - "Return Data from a Stored Procedure":
    Create sp_GetEmployeeCountByDepartment that takes @DepartmentID and returns the
    NUMBER of employees in that department.

  I show THREE ways to return data so I understand the differences:
    (1) as a RESULT SET   -> SELECT COUNT(*)
    (2) as an OUTPUT param -> @EmployeeCount OUTPUT
    (3) as a RETURN value  -> RETURN (integer status/value)

  Self-contained: schema + sample data + proc. Re-runnable (drops first).
*****************************************************************************************/

-------------------------------------------------------------------------------
-- 0) Idempotent cleanup
-------------------------------------------------------------------------------
IF OBJECT_ID('dbo.sp_GetEmployeeCountByDepartment', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_GetEmployeeCountByDepartment;
IF OBJECT_ID('dbo.Employees',   'U') IS NOT NULL DROP TABLE dbo.Employees;
IF OBJECT_ID('dbo.Departments', 'U') IS NOT NULL DROP TABLE dbo.Departments;
GO

-------------------------------------------------------------------------------
-- 1) Schema + 2) Sample data
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
    (1, 'HR'), (2, 'Finance'), (3, 'IT'), (4, 'Marketing');

-- Put 2 employees in IT (dept 3) so the count is interesting (not just 1).
INSERT INTO dbo.Employees (EmployeeID, FirstName, LastName, DepartmentID, Salary, JoinDate) VALUES
    (1, 'John',    'Doe',     1, 5000.00, '2020-01-15'),
    (2, 'Jane',    'Smith',   2, 6000.00, '2019-03-22'),
    (3, 'Michael', 'Johnson', 3, 7000.00, '2018-07-30'),
    (4, 'Emily',   'Davis',   4, 5500.00, '2021-11-05'),
    (5, 'Sara',    'Lee',     3, 6500.00, '2022-05-10');
GO

-------------------------------------------------------------------------------
-- 3) Exercise 5 - the proc.
--    It produces a result set AND sets an OUTPUT param AND uses RETURN,
--    so the caller can choose whichever mechanism they need.
-------------------------------------------------------------------------------
CREATE PROCEDURE dbo.sp_GetEmployeeCountByDepartment
    @DepartmentID  INT,
    @EmployeeCount INT = 0 OUTPUT   -- (2) OUTPUT parameter
AS
BEGIN
    SET NOCOUNT ON;

    -- Compute the count once.
    SELECT @EmployeeCount = COUNT(*)
    FROM dbo.Employees
    WHERE DepartmentID = @DepartmentID;

    -- (1) Also expose it as a RESULT SET for convenience.
    SELECT @EmployeeCount AS EmployeeCount;

    -- (3) RETURN the value too (RETURN can only carry an INT status code).
    RETURN @EmployeeCount;
END;
GO

-------------------------------------------------------------------------------
-- 4) Example calls
-------------------------------------------------------------------------------

-- (a) Use it as a RESULT SET (simplest):
EXEC dbo.sp_GetEmployeeCountByDepartment @DepartmentID = 3;
/*  Expected result set:
    EmployeeCount
    -------------
    2
*/

-- (b) Capture the OUTPUT parameter into a variable:
DECLARE @CountOut INT;
EXEC dbo.sp_GetEmployeeCountByDepartment
     @DepartmentID  = 3,
     @EmployeeCount = @CountOut OUTPUT;
PRINT 'IT department employee count (OUTPUT param) = ' + CAST(@CountOut AS VARCHAR(10));
-- Expected PRINT: IT department employee count (OUTPUT param) = 2
GO

-- (c) Capture the RETURN value:
DECLARE @CountRet INT;
EXEC @CountRet = dbo.sp_GetEmployeeCountByDepartment @DepartmentID = 1;  -- HR has 1 employee
PRINT 'HR department employee count (RETURN value) = ' + CAST(@CountRet AS VARCHAR(10));
-- Expected PRINT: HR department employee count (RETURN value) = 1
GO

/*  Notes to self:
    - RETURN is conventionally for status codes (0 = success). It works for small ints
      like a count, but OUTPUT params / result sets are the cleaner way to return DATA.
    - OUTPUT lets you return multiple values and non-int types (RETURN is int-only).
*/
