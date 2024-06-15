using NUnit.Framework;

namespace TheCity.Tests
{
    [TestFixture]
    public class CitizenCreationDataTests
    {
        [Test]
        public void ReturnSameValues_AsConstructorArguments()
        {
            var citizenData = CorrectThings.GetCorrectCitizenData();
            var companyData = CorrectThings.GetCorrectCompanyData();

            var citizenCreationData = new CitizenCreationData(citizenData, companyData);

            Assert.AreEqual(citizenData, citizenCreationData.CitizenData);
            Assert.AreEqual(companyData, citizenCreationData.CompanyData);
        }
    }
}