using System;
using System.Threading;

class Program
{
    static readonly object lockA = new();
    static readonly object lockB = new();

    static void Method1()
    {
        lock (lockA)
        {
            Thread.Sleep(100);

            lock (lockB)
            {
                Console.WriteLine(
                    "Method1 Completed"
                );
            }
        }
    }

    static void Method2()
    {
        lock (lockA)
        {
            Thread.Sleep(100);

            lock (lockB)
            {
                Console.WriteLine(
                    "Method2 Completed"
                );
            }
        }
    }

    static void Main()
    {
        Thread t1 =
            new Thread(Method1);

        Thread t2 =
            new Thread(Method2);

        t1.Start();
        t2.Start();

        t1.Join();
        t2.Join();
    }
}