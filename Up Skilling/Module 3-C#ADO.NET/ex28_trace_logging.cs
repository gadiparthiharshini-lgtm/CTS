using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        Trace.Listeners.Add(
            new TextWriterTraceListener(
                "app.log"
            )
        );

        Trace.AutoFlush = true;

        Trace.WriteLine(
            "Application Started"
        );

        int a = 10;
        int b = 20;

        Trace.WriteLine(
            $"Sum = {a + b}"
        );

        Trace.WriteLine(
            "Application Ended"
        );

        Console.WriteLine(
            "Logs written to app.log"
        );
    }
}