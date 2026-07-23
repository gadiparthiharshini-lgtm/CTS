CREATE VIEW EmployeeDetails AS
SELECT
    E.EmployeeID,
    E.FirstName,
    E.LastName,
    D.DepartmentName,
    E.Salary,
    E.JoinDate
FROM Employees E
JOIN Departments D
ON E.DepartmentID = D.DepartmentID;
GO
SELECT * FROM EmployeeDetails;
GO