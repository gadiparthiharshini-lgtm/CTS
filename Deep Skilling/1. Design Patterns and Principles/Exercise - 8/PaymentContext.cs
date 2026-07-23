namespace StrategyPatternExample
{
    public class PaymentContext
    {
        private PaymentStrategy strategy;

        public PaymentContext(PaymentStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void SetStrategy(PaymentStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void ExecutePayment(double amount)
        {
            strategy.Pay(amount);
        }
    }
}