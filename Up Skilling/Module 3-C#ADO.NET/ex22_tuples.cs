using System;

class Program
{
    static (int, string) GetData()
    {
        return (101, "Vardhan");
    }

    static void Main()
    {
        var (id, name) = GetData();

        Console.WriteLine($"Id: {id}");
        Console.WriteLine($"Name: {name}");
    }
}