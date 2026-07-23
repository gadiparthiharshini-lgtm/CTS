using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        await PrintMessage();
    }

    static async Task PrintMessage()
    {
        await Task.Delay(2000);
        Console.WriteLine("Async Completed");
    }
}