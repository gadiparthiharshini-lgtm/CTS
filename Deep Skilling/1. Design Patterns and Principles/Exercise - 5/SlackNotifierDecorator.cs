using System;

namespace DecoratorPatternExample
{
    public class SlackNotifierDecorator : NotifierDecorator
    {
        public SlackNotifierDecorator(Notifier notifier) : base(notifier)
        {
        }

        public override void Send(string message)
        {
            base.Send(message);
            Console.WriteLine($"Slack Notification: {message}");
        }
    }
}