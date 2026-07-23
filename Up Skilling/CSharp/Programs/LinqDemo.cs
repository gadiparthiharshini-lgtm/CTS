using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] nums={10,20,30,40,50};

        var result=
            nums.Where(x=>x>25);

        foreach(var n in result)
        {
            Console.WriteLine(n);
        }
    }
}