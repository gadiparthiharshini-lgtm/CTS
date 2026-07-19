using System;
using System.Threading;
using System.Threading.Tasks;

class Counter
{
    public int Value = 0;

    public void Increment()
    {
        for (int i = 0; i < 100000; i++)
        {
            Value++;
        }
    }
}

class Program
{
    static void Main()
    {
        Counter counter = new();

        Task t1 =
            Task.Run(
                counter.Increment
            );

        Task t2 =
            Task.Run(
                counter.Increment
            );

        Task.WaitAll(t1, t2);

        Console.WriteLine(
            $"Counter Value: {counter.Value}"
        );
    }
}