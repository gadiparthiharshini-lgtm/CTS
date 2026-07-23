BEGIN TRY
    INSERT INTO Employees
    (
        EmployeeID,
        FirstName,
        LastName,
        DepartmentID,
        Salary,
        JoinDate
    )
    VALUES
    (
        1,                      -- Duplicate EmployeeID (will cause error)
        'Alex',
        'Brown',
        1,
        6000,
        '2024-01-01'
    );
END TRY
BEGIN CATCH
    INSERT INTO AuditLog
    (
        Action,
        ErrorMessage
    )
    VALUES
    (
        'Insert Employee',
        ERROR_MESSAGE()
    );
END CATCH;
GO
SELECT * FROM AuditLog;