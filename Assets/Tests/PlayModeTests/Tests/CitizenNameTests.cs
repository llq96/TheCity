using NUnit.Framework;

namespace TheCity.Tests
{
    public class CitizenNameTests
    {
        [Test]
        public void ReturnSameValue_AsConstructorArguments()
        {
            var firstName = "John";
            var secondName = "Smith";

            var citizenName = new CitizenName(firstName, secondName);

            Assert.AreEqual(firstName, citizenName.FirstName);
            Assert.AreEqual(secondName, citizenName.SecondName);
        }

        [Test]
        public void FullNameNotEmpty()
        {
            var firstName = "John";
            var secondName = "Smith";

            var citizenName = new CitizenName(firstName, secondName);

            Assert.IsNotEmpty(citizenName.FullName);
        }

        [Test]
        public void ThrowWhen_FirstName_IsNull()
        {
            string firstName = null;
            var secondName = "Smith";

            Assert.Catch(() =>
            {
                var citizenName = new CitizenName(firstName, secondName);
            });
        }

        [Test]
        public void ThrowWhen_FirstName_IsEmpty()
        {
            var firstName = "";
            var secondName = "Smith";

            Assert.Catch(() =>
            {
                var citizenName = new CitizenName(firstName, secondName);
            });
        }

        [Test]
        public void ThrowWhen_SecondName_IsNull()
        {
            var firstName = "John";
            string secondName = null;

            Assert.Catch(() =>
            {
                var citizenName = new CitizenName(firstName, secondName);
            });
        }

        [Test]
        public void ThrowWhen_SecondName_IsEmpty()
        {
            var firstName = "John";
            var secondName = "";

            Assert.Catch(() =>
            {
                var citizenName = new CitizenName(firstName, secondName);
            });
        }
    }
}