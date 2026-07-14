using System.Net;
using System.Net.Mail;

namespace CustomerCommLib
{
    /// <summary>
    /// Real implementation of <see cref="IMailSender"/> that sends email through
    /// an SMTP server using <see cref="SmtpClient"/>.
    ///
    /// NOTE: This class CANNOT be meaningfully unit tested because it depends on
    /// an external system (an SMTP server). That is exactly why we introduced the
    /// <see cref="IMailSender"/> abstraction — so callers can be tested in
    /// isolation by mocking the interface.
    ///
    /// NOTE: <see cref="SmtpClient"/> is marked obsolete in modern .NET
    /// (Microsoft recommends MailKit for production), but it still exists in
    /// .NET 8 and is used here to mirror the hands-on exercise document.
    /// </summary>
    public class MailSender : IMailSender
    {
        public bool SendMail(string toAddress, string message)
        {
            // The following replicates the exercise's SMTP implementation.
            // Credentials and host below are PLACEHOLDERS — replace with real
            // values for an actual send. They are never exercised by unit tests.
            MailMessage mail = new MailMessage();
            SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("youremail@gmail.com"); // placeholder
            mail.To.Add(toAddress);
            mail.Subject = "Test Mail";
            mail.Body = message;

            smtpServer.Port = 587;
            smtpServer.Credentials = new NetworkCredential(
                "youremail@gmail.com",  // placeholder username
                "password");            // placeholder password
            smtpServer.EnableSsl = true;

            smtpServer.Send(mail);

            return true;
        }
    }
}
