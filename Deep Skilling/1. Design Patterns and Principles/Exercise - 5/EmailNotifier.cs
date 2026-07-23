using System;

namespace DecoratorPatternExample
{
    public class EmailNotifier : Notifier
    {
        public void Send(string message)
        {
            Console.WriteLine($"Email Notification: {message}");
        }
    }
}