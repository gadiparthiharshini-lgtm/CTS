using System;

public record Employee
{
    public int Id { get; init; }

    public string Name { get; init; }

    public string Department { get; init; }
}

class Program
{
    static void Main()
    {
        Employee emp1 = new()
        {
            Id = 1,
            Name = "Vardhan",
            Department = "IT"
        };

        Employee emp2 =
            emp1 with
            {
                Department = "HR"
            };

        Console.WriteLine(emp1);
        Console.WriteLine(emp2);
    }
}