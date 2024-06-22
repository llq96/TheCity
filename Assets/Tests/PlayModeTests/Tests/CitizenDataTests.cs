using TheCity.Core;
using NUnit.Framework;

namespace TheCity.Tests
{
    [TestFixture]
    public class CitizenDataTests
    {
        [Test]
        public void Constructor_WhenCalled_SetPropertiesCorrect()
        {
            var inbornData = CorrectThings.GetInbornData();

            var citizenData = new CitizenData(inbornData);

            Assert.AreEqual(inbornData, citizenData.CitizenInbornData);
        }
    }
}