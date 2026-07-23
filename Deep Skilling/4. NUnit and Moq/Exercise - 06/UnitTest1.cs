using NUnit.Framework;
using SeasonsLib;

namespace SeasonsLib.Tests
{
    public class Tests
    {
        private SeasonTeller teller;

        [SetUp]
        public void Setup()
        {
            teller = new SeasonTeller();
        }

        private static readonly object[] SeasonTestData =
        {
            new object[] { "February", "Spring" },
            new object[] { "March", "Spring" },

            new object[] { "April", "Summer" },
            new object[] { "May", "Summer" },
            new object[] { "June", "Summer" },

            new object[] { "July", "Monsoon" },
            new object[] { "August", "Monsoon" },
            new object[] { "September", "Monsoon" },

            new object[] { "October", "Autumn" },
            new object[] { "November", "Autumn" },

            new object[] { "December", "Winter" },
            new object[] { "January", "Winter" },

            new object[] { "Hello", "Invalid Season" }
        };

        [TestCaseSource(nameof(SeasonTestData))]
        public void DisplaySeasonBy_ShouldReturnExpectedSeason(string month, string expected)
        {
            string result = teller.DisplaySeasonBy(month);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}