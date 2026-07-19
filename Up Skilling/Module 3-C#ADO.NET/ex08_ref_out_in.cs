using System;

class Program
{
    static void UpdateValue(ref int number)
    {
        number += 10;
    }

    static void GetValue(out int number)
    {
        number = 50;
    }

    static void DisplayValue(in int number)
    {
        Console.WriteLine(number);
    }

    static void Main()
    {
        int a = 10;

        Console.WriteLine($"Before Ref: {a}");
        UpdateValue(ref a);
        Console.WriteLine($"After Ref: {a}");

        int b;

        GetValue(out b);
        Console.WriteLine($"Out Value: {b}");

        DisplayValue(in a);
    }
}