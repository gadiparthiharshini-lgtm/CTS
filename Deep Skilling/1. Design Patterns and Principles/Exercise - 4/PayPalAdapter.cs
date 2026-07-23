namespace AdapterPatternExample
{
    public class PayPalAdapter : PaymentProcessor
    {
        private readonly PayPalGateway payPalGateway = new PayPalGateway();

        public void ProcessPayment(double amount)
        {
            payPalGateway.MakePayment(amount);
        }
    }
}