using ConverterLib;
using Moq;
using NUnit.Framework;

namespace ConverterLib.Tests
{
    public class Tests
    {
        private Mock<IDollarToEuroExchangeRateFeed> mockExchangeRate;
        private Converter converter;

        [SetUp]
        public void Setup()
        {
            mockExchangeRate = new Mock<IDollarToEuroExchangeRateFeed>();

            mockExchangeRate
                .Setup(x => x.GetActualUSDollarValue())
                .Returns(0.85);

            converter = new Converter(mockExchangeRate.Object);
        }

        [Test]
        public void CelsiusToKelvin_ShouldReturn373Point15_WhenInputIs100()
        {
            Assert.That(converter.CelsiusToKelvin(100), Is.EqualTo(373.15));
        }

        [Test]
        public void KilogramToPound_ShouldReturn22Point05_WhenInputIs10()
        {
            Assert.That(converter.KilogramToPound(10), Is.EqualTo(22.05));
        }

        [Test]
        public void KilometerToMile_ShouldReturn6Point215_WhenInputIs10()
        {
            Assert.That(converter.KilometerToMile(10), Is.EqualTo(6.215).Within(0.01));
        }

        [Test]
        public void LiterToGallon_ShouldReturn2Point642_WhenInputIs10()
        {
            Assert.That(converter.LiterToGallon(10), Is.EqualTo(2.642).Within(0.01));
        }

        [Test]
        public void USDToEuro_ShouldReturn85_WhenInputIs100()
        {
            Assert.That(converter.USDToEuro(100), Is.EqualTo(85));
        }
    }
}