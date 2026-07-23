using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> skills=new List<string>
        {
            "HTML",
            "CSS",
            "JavaScript"
        };

        foreach(string skill in skills)
        {
            Console.WriteLine(skill);
        }
    }
}