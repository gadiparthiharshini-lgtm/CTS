CREATE PROCEDURE GetEmployeeById
    @EmployeeID INT
AS
BEGIN
    SELECT *
    FROM Employees
    WHERE EmployeeID = @EmployeeID;
END;
GO
EXEC GetEmployeeById @EmployeeID = 1;
GO
EXEC GetEmployeeById @EmployeeID = 3;
GO