using AdapterPatternExample;

PaymentProcessor paypal = new PayPalAdapter();
paypal.ProcessPayment(1500);

PaymentProcessor stripe = new StripeAdapter();
stripe.ProcessPayment(2500);