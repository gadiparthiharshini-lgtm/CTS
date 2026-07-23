using EmployeeManagement;

Employee[] employees = new Employee[5];
int count = 0;

// Add Employee
void AddEmployee(Employee employee)
{
    if (count < employees.Length)
    {
        employees[count++] = employee;
        Console.WriteLine($"Employee {employee.Name} Added.");
    }
    else
    {
        Console.WriteLine("Employee Array is Full.");
    }
}

// Search Employee
void SearchEmployee(int id)
{
    for (int i = 0; i < count; i++)
    {
        if (employees[i].EmployeeId == id)
        {
            Console.WriteLine($"Found: {employees[i].EmployeeId} | {employees[i].Name} | {employees[i].Position} | ₹{employees[i].Salary}");
            return;
        }
    }

    Console.WriteLine("Employee Not Found.");
}

// Traverse Employees
void TraverseEmployees()
{
    Console.WriteLine("\nEmployee List");

    for (int i = 0; i < count; i++)
    {
        Console.WriteLine($"{employees[i].EmployeeId} | {employees[i].Name} | {employees[i].Position} | ₹{employees[i].Salary}");
    }
}

// Delete Employee
void DeleteEmployee(int id)
{
    for (int i = 0; i < count; i++)
    {
        if (employees[i].EmployeeId == id)
        {
            for (int j = i; j < count - 1; j++)
            {
                employees[j] = employees[j + 1];
            }

            employees[count - 1] = null!;
            count--;

            Console.WriteLine($"Employee ID {id} Deleted.");
            return;
        }
    }

    Console.WriteLine("Employee Not Found.");
}

// --------------------------

AddEmployee(new Employee
{
    EmployeeId = 101,
    Name = "Rahul",
    Position = "Developer",
    Salary = 50000
});

AddEmployee(new Employee
{
    EmployeeId = 102,
    Name = "Priya",
    Position = "Tester",
    Salary = 45000
});

TraverseEmployees();

Console.WriteLine();

SearchEmployee(102);

Console.WriteLine();

DeleteEmployee(101);

TraverseEmployees();