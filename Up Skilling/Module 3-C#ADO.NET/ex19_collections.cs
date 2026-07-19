using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> cities = new()
        {
            "Guntur",
            "Vijayawada",
            "Hyderabad"
        };

        cities.Add("Bangalore");
        cities.Remove("Hyderabad");

        Console.WriteLine("List Items");

        foreach (string city in cities)
        {
            Console.WriteLine(city);
        }

        Dictionary<int, string> students =
            new Dictionary<int, string>()
            {
                {1,"Vardhan"},
                {2,"Ravi"},
                {3,"Sai"}
            };

        students.Add(4, "Kiran");
        students.Remove(2);

        Console.WriteLine("\nDictionary Items");

        foreach (var item in students)
        {
            Console.WriteLine(
                $"{item.Key} - {item.Value}"
            );
        }
    }
}