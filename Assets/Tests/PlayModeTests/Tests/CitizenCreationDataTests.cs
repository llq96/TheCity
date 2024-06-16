using NUnit.Framework;

namespace TheCity.Tests
{
    [TestFixture]
    public class CitizenCreationDataTests
    {
        [Test]
        public void Properties_WhenGetAfterConstructor_ReturnValuesSameAsWasArguments()
        {
            var citizenData = CorrectThings.GetCitizenData();
            var companyData = CorrectThings.GetCompanyData();

            var citizenCreationData = new CitizenCreationData(citizenData, companyData);

            Assert.AreEqual(citizenData, citizenCreationData.CitizenData);
            Assert.AreEqual(companyData, citizenCreationData.CompanyData);
        }
    }
}