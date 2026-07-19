using System;

class Person(string firstName, int age)
{
    public string FirstName { get; } = firstName;
    public int Age { get; } = age;

    public void DisplayInfo()
    {
        Console.WriteLine($"Name: {FirstName}");
        Console.WriteLine($"Age: {Age}");
    }
}

class Program
{
    static void Main()
    {
        Person person = new("Vardhan", 21);

        person.DisplayInfo();
    }
}