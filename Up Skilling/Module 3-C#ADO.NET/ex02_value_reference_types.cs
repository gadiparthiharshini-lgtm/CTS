using System;

class Person
{
    public string Name;
}

class Program
{
    static void ModifyValue(int num)
    {
        num = 100;
    }

    static void ModifyReference(Person p)
    {
        p.Name = "Updated Name";
    }

    static void Main()
    {
        int number = 10;

        Person person = new Person
        {
            Name = "John"
        };

        Console.WriteLine($"Before: {number}");
        ModifyValue(number);
        Console.WriteLine($"After: {number}");

        Console.WriteLine($"Before: {person.Name}");
        ModifyReference(person);
        Console.WriteLine($"After: {person.Name}");
    }
}