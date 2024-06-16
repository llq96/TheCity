using NUnit.Framework;

namespace TheCity.Tests
{
    public class CitizenNameTests
    {
        [Test]
        public void Properties_WhenGetAfterConstructor_ReturnValuesSameAsWasArguments()
        {
            var firstName = "John";
            var secondName = "Smith";

            var citizenName = new CitizenName(firstName, secondName);

            Assert.AreEqual(firstName, citizenName.FirstName);
            Assert.AreEqual(secondName, citizenName.SecondName);
        }

        [Test]
        public void FullName_AfterConstructor_ReturnsNotEmpty()
        {
            var firstName = "John";
            var secondName = "Smith";

            var citizenName = new CitizenName(firstName, secondName);

            Assert.IsNotEmpty(citizenName.FullName);
        }

        [Test]
        public void Constructor_NullFirstName_Throw()
        {
            string firstName = null;
            var secondName = "Smith";

            Assert.Catch(() =>
            {
                var citizenName = new CitizenName(firstName, secondName);
            });
        }

        [Test]
        public void Constructor_EmptyFirstName_Throw()
        {
            var firstName = "";
            var secondName = "Smith";

            Assert.Catch(() =>
            {
                var citizenName = new CitizenName(firstName, secondName);
            });
        }

        [Test]
        public void Constructor_NullSecondName_Throw()
        {
            var firstName = "John";
            string secondName = null;

            Assert.Catch(() =>
            {
                var citizenName = new CitizenName(firstName, secondName);
            });
        }

        [Test]
        public void Constructor_EmptySecondName_Throw()
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