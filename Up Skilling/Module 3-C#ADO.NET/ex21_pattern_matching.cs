using System;

class Program
{
    static void DisplayInfo(object obj)
    {
        if (obj is int number)
        {
            Console.WriteLine(
                $"Integer: {number}"
            );
        }
        else if (obj is string text)
        {
            Console.WriteLine(
                $"String: {text}"
            );
        }

        string result = obj switch
        {
            int => "It is an Integer",
            string => "It is a String",
            double => "It is a Double",
            _ => "Unknown Type"
        };

        Console.WriteLine(result);
    }

    static void Main()
    {
        DisplayInfo(100);
        DisplayInfo("Hello");
        DisplayInfo(10.5);
    }
}