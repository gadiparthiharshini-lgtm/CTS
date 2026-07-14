using CustomerCommLib;
using Moq;
using NUnit.Framework;

namespace CustomerComm.Tests
{
    /// <summary>
    /// Unit tests for <see cref="CustomerCommLib.CustomerComm"/>.
    ///
    /// The real <see cref="MailSender"/> talks to an SMTP server, which we do not
    /// want to do during a unit test. Instead we use Moq to create a "test double"
    /// (a mock) of <see cref="IMailSender"/>. The mock is configured so that
    /// SendMail accepts any two strings and always returns true, letting us test
    /// CustomerComm in complete isolation from the network.
    /// </summary>
    [TestFixture]
    public class CustomerCommTests
    {
        // Mock of the dependency and the system under test.
        private Mock<IMailSender> _mockMailSender;
        private CustomerCommLib.CustomerComm _customerComm;

        /// <summary>
        /// Runs ONCE for the whole fixture (before any test).
        /// Builds the mock and injects it into the CustomerComm under test.
        /// </summary>
        [OneTimeSetUp]
        public void Setup()
        {
            _mockMailSender = new Mock<IMailSender>();

            // Configure the mock: for ANY toAddress and ANY message, return true.
            _mockMailSender
                .Setup(x => x.SendMail(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(true);

            // Constructor injection of the mock object.
            _customerComm = new CustomerCommLib.CustomerComm(_mockMailSender.Object);
        }

        /// <summary>
        /// Verifies that SendMailToCustomer returns true when the (mocked)
        /// mail sender reports success.
        /// </summary>
        [Test]
        public void SendMailToCustomer_WhenCalled_ReturnsTrue()
        {
            bool result = _customerComm.SendMailToCustomer();

            Assert.That(result, Is.True);
        }
    }
}
