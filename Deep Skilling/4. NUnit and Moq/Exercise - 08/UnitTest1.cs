using NUnit.Framework;
using UserManagerLib;
using System;

namespace UserManagerLib.Tests
{
    public class UserTests
    {
        private User userManager;

        [SetUp]
        public void Setup()
        {
            userManager = new User();
        }

        [Test]
        public void CreateUser_ValidPAN_ShouldNotThrowException()
        {
            User user = new User
            {
                PANCardNo = "ABCDE1234F"
            };

            Assert.DoesNotThrow(() => userManager.CreateUser(user));
        }

        [Test]
        public void CreateUser_NullPAN_ShouldThrowNullReferenceException()
        {
            User user = new User
            {
                PANCardNo = null
            };

            var ex = Assert.Throws<NullReferenceException>(() =>
            {
                userManager.CreateUser(user);
            });

            Assert.That(ex.Message, Is.EqualTo("Invalid Pan Card Number"));
        }

        [Test]
        public void CreateUser_EmptyPAN_ShouldThrowNullReferenceException()
        {
            User user = new User
            {
                PANCardNo = ""
            };

            var ex = Assert.Throws<NullReferenceException>(() =>
            {
                userManager.CreateUser(user);
            });

            Assert.That(ex.Message, Is.EqualTo("Invalid Pan Card Number"));
        }

        [Test]
        public void CreateUser_InvalidPANLength_ShouldThrowFormatException()
        {
            User user = new User
            {
                PANCardNo = "ABC123"
            };

            var ex = Assert.Throws<FormatException>(() =>
            {
                userManager.CreateUser(user);
            });

            Assert.That(ex.Message,
                Is.EqualTo("Pan Card Number Should contain only 10 characters"));
        }
    }
}