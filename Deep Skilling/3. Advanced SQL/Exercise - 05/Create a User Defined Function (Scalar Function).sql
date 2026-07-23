CREATE FUNCTION GetAnnualSalary
(
    @MonthlySalary DECIMAL(10,2)
)
RETURNS DECIMAL(10,2)
AS
BEGIN
    RETURN @MonthlySalary * 12;
END;
GO
SELECT dbo.GetAnnualSalary(5000) AS AnnualSalary;
GO
SELECT
    EmployeeID,
    FirstName,
    Salary,
    dbo.GetAnnualSalary(Salary) AS AnnualSalary
FROM Employees;
GO
