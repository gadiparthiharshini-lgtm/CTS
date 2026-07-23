using System;

class Student
{
    public string Name;
    public int Age;

    public void Display()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Age: {Age}");
    }

    static void Main()
    {
        Student s=new Student();
        s.Name="Pramod";
        s.Age=22;
        s.Display();
    }
}