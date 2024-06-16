using NUnit.Framework;

namespace TheCity.Tests
{
    [TestFixture]
    public class CitizenDataTests
    {
        [Test]
        public void Properties_WhenGetAfterConstructor_ReturnValuesSameAsWasArguments()
        {
            var inbornData = CorrectThings.GetCorrectInbornData();

            var citizenData = new CitizenData(inbornData);

            Assert.AreEqual(inbornData, citizenData.CitizenInbornData);
        }
    }
}