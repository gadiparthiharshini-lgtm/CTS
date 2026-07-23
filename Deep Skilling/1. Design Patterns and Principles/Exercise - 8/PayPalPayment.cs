using System;

namespace StrategyPatternExample
{
    public class PayPalPayment : PaymentStrategy
    {
        public void Pay(double amount)
        {
            Console.WriteLine($"Paid ₹{amount} using PayPal.");
        }
    }
}