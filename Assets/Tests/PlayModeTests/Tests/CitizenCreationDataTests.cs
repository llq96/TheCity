using NUnit.Framework;

namespace TheCity.Tests
{
    [TestFixture]
    public class CitizenCreationDataTests
    {
        [Test]
        public void Constructor_WhenCalled_SetPropertiesCorrect()
        {
            var citizenData = CorrectThings.GetCitizenData();
            var companyData = CorrectThings.GetCompanyData();

            var citizenCreationData = new CitizenCreationData(citizenData, companyData);

            Assert.AreEqual(citizenData, citizenCreationData.CitizenData);
            Assert.AreEqual(companyData, citizenCreationData.CompanyData);
        }
    }
}