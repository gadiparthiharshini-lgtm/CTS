#nullable enable
using System;

class Person
{
    public string? Name { get; set; }
}

class Program
{
    static void Main()
    {
        Person? person = null;

        Console.WriteLine(
            person?.Name ?? "No Name"
        );

        person = new Person
        {
            Name = "Vardhan"
        };

        Console.WriteLine(
            person?.Name ?? "No Name"
        );
    }
}