using System;

class Calculator
{
    public int CalculateTotal(int a, int b)
    {
        return a + b;
    }

    public double CalculateTotal(
        double a,
        double b,
        double c)
    {
        return a + b + c;
    }
}

class Program
{
    static void Main()
    {
        Calculator calc = new();

        Console.WriteLine(
            calc.CalculateTotal(10, 20)
        );

        Console.WriteLine(
            calc.CalculateTotal(
                10.5,
                20.5,
                30.5
            )
        );
    }
}