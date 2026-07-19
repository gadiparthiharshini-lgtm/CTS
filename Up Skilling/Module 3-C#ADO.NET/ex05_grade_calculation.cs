using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter Score: ");
        int score = Convert.ToInt32(Console.ReadLine());

        if (score >= 90)
            Console.WriteLine("Grade A");
        else if (score >= 75)
            Console.WriteLine("Grade B");
        else if (score >= 50)
            Console.WriteLine("Grade C");
        else
            Console.WriteLine("Grade F");

        string grade = score switch
        {
            >= 90 => "A",
            >= 75 => "B",
            >= 50 => "C",
            _ => "F"
        };

        Console.WriteLine($"Switch Grade: {grade}");
    }
}