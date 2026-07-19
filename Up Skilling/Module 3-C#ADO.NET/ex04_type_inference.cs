using System;

class Student
{
    public string Name { get; set; }

    public Student(string name)
    {
        Name = name;
    }
}

class Program
{
    static void Main()
    {
        var age = 21;
        var city = "Guntur";

        Student student = new("Vardhan");

        Console.WriteLine($"{age} - {age.GetType()}");
        Console.WriteLine($"{city} - {city.GetType()}");
        Console.WriteLine($"{student.Name} - {student.GetType()}");
    }
}