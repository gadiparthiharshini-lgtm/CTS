using NUnit.Framework;
using AccountsManagerLib;
using System;

namespace AccountsManagerLib.Tests
{
    public class Tests
    {
        private AccountsManager manager;

        [SetUp]
        public void Setup()
        {
            manager = new AccountsManager();
        }

        [TestCase("user_11", "secret@user11", "Welcome user_11!!!")]
        [TestCase("user_22", "secret@user22", "Welcome user_22!!!")]
        public void ValidateUser_ValidCredentials_ShouldReturnWelcomeMessage(string userId, string password, string expected)
        {
            string result = manager.ValidateUser(userId, password);

            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase("user_11", "wrongpassword")]
        [TestCase("wronguser", "secret@user11")]
        [TestCase("abc", "xyz")]
        public void ValidateUser_InvalidCredentials_ShouldReturnInvalidMessage(string userId, string password)
        {
            string result = manager.ValidateUser(userId, password);

            Assert.That(result, Is.EqualTo("Invalid user id/password"));
        }

        [TestCase("", "secret@user11")]
        [TestCase("user_11", "")]
        [TestCase("", "")]
        public void ValidateUser_EmptyCredentials_ShouldThrowFormatException(string userId, string password)
        {
            var ex = Assert.Throws<FormatException>(() =>
            {
                manager.ValidateUser(userId, password);
            });

            Assert.That(ex.Message, Is.EqualTo("Both user id and password are mandatory"));
        }
    }
}