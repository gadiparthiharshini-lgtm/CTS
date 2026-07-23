using System;
using System.Collections.Generic;

class Student
{
    public int Id;
    public string Name;
}

class Program
{
    static void Main()
    {
        List<Student> students=
        new List<Student>();

        students.Add(
            new Student
            {
                Id=101,
                Name="Pramod"
            });

        students.Add(
            new Student
            {
                Id=102,
                Name="Rahul"
            });

        foreach(var s in students)
        {
            Console.WriteLine(
                $"{s.Id} {s.Name}");
        }
    }
}