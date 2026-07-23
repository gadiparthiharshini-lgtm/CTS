using System;

namespace StrategyPatternExample
{
    public class CreditCardPayment : PaymentStrategy
    {
        public void Pay(double amount)
        {
            Console.WriteLine($"Paid ₹{amount} using Credit Card.");
        }
    }
}