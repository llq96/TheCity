using System;
using NUnit.Framework;

namespace TheCity.Tests
{
    public class CitizenNameTests
    {
        [Test]
        public void ReturnSameValue_AsConstructorArguments()
        {
            var firstName = Guid.NewGuid().ToString();
            var secondName = Guid.NewGuid().ToString();

            var citizenName = new CitizenName(firstName, secondName);

            Assert.AreEqual(citizenName.FirstName, firstName);
            Assert.AreEqual(citizenName.SecondName, secondName);
        }

        [Test]
        public void FullNameNotEmpty()
        {
            var firstName = Guid.NewGuid().ToString();
            var secondName = Guid.NewGuid().ToString();

            var citizenName = new CitizenName(firstName, secondName);

            Assert.IsNotEmpty(citizenName.FullName);
        }

        [Test]
        public void ThrowWhen_FirstName_IsNull()
        {
            string firstName = null;
            var secondName = Guid.NewGuid().ToString();

            Assert.Catch(() =>
            {
                var citizenName = new CitizenName(firstName, secondName);
            });
        }

        [Test]
        public void ThrowWhen_FirstName_IsEmpty()
        {
            var firstName = "";
            var secondName = Guid.NewGuid().ToString();

            Assert.Catch(() =>
            {
                var citizenName = new CitizenName(firstName, secondName);
            });
        }

        [Test]
        public void ThrowWhen_SecondName_IsNull()
        {
            var firstName = Guid.NewGuid().ToString();
            string secondName = null;

            Assert.Catch(() =>
            {
                var citizenName = new CitizenName(firstName, secondName);
            });
        }

        [Test]
        public void ThrowWhen_SecondName_IsEmpty()
        {
            var firstName = Guid.NewGuid().ToString();
            var secondName = "";

            Assert.Catch(() =>
            {
                var citizenName = new CitizenName(firstName, secondName);
            });
        }
    }
}