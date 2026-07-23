using NUnit.Framework;
using UtilLib;

namespace UtilLib.Tests
{
    public class Tests
    {
        private UrlHostNameParser parser;

        [SetUp]
        public void Setup()
        {
            parser = new UrlHostNameParser();
        }

        [Test]
        public void ParseHostName_ValidHttpUrl_ShouldReturnHostName()
        {
            string url = "http://www.google.com/index.html";

            string result = parser.ParseHostName(url);

            Assert.That(result, Is.EqualTo("www.google.com"));
        }

        [Test]
        public void ParseHostName_ValidHttpsUrl_ShouldReturnHostName()
        {
            string url = "https://www.microsoft.com/home";

            string result = parser.ParseHostName(url);

            Assert.That(result, Is.EqualTo("www.microsoft.com"));
        }

        [Test]
        public void ParseHostName_InvalidProtocol_ShouldThrowFormatException()
        {
            string url = "ftp://www.google.com";

            var ex = Assert.Throws<FormatException>(() =>
            {
                parser.ParseHostName(url);
            });

            Assert.That(ex.Message, Is.EqualTo("Url is not in correct format"));
        }
    }
}