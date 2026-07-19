using System;

class Student
{
    public required string Name { get; set; }
    public required string Department { get; set; }
}

class Program
{
    static void Main()
    {
        Student student = new()
        {
            Name = "Vardhan",
            Department = "CSE"
        };

        Console.WriteLine(
            $"{student.Name} - {student.Department}"
        );

        // This causes compile-time error
        // Student s = new();
    }
}