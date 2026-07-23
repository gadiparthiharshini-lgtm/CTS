using System;

namespace AdapterPatternExample
{
    public class StripeGateway
    {
        public void Pay(double amount)
        {
            Console.WriteLine($"Paid ₹{amount} using Stripe.");
        }
    }
}