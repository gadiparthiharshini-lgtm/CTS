using StrategyPatternExample;

PaymentContext payment = new PaymentContext(new CreditCardPayment());

payment.ExecutePayment(5000);

payment.SetStrategy(new PayPalPayment());

payment.ExecutePayment(3000);