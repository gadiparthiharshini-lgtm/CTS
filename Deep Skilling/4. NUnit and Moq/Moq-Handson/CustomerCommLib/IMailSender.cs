namespace CustomerCommLib
{
    /// <summary>
    /// Abstraction over the mail-sending capability.
    /// Depending on this interface (instead of a concrete SmtpClient wrapper)
    /// is what makes <see cref="CustomerComm"/> testable: in tests we can
    /// substitute a mock implementation via Moq instead of hitting a real
    /// SMTP server.
    /// </summary>
    public interface IMailSender
    {
        /// <summary>
        /// Sends a mail message.
        /// </summary>
        /// <param name="toAddress">Recipient email address.</param>
        /// <param name="message">Message body.</param>
        /// <returns><c>true</c> if the mail was sent.</returns>
        bool SendMail(string toAddress, string message);
    }
}
