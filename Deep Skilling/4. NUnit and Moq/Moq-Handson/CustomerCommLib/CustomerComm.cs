namespace CustomerCommLib
{
    /// <summary>
    /// Business class that needs to send mail to customers.
    /// It depends on the <see cref="IMailSender"/> abstraction, injected through
    /// the constructor (constructor injection). This dependency injection is what
    /// allows the class to be unit tested with a mocked mail sender.
    /// </summary>
    public class CustomerComm
    {
        private readonly IMailSender _mailSender;

        /// <summary>
        /// Constructor injection: the dependency is provided from the outside,
        /// so tests can pass a mock and production code can pass a real
        /// <see cref="MailSender"/>.
        /// </summary>
        public CustomerComm(IMailSender mailSender)
        {
            _mailSender = mailSender;
        }

        /// <summary>
        /// Sends a mail to the customer and returns whether it succeeded.
        /// </summary>
        public bool SendMailToCustomer()
        {
            _mailSender.SendMail("cust@abc.com", "Some Message");
            return true;
        }
    }
}
