namespace AdapterPatternExample
{
    public class StripeAdapter : PaymentProcessor
    {
        private readonly StripeGateway stripeGateway = new StripeGateway();

        public void ProcessPayment(double amount)
        {
            stripeGateway.Pay(amount);
        }
    }
}