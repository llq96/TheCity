using NUnit.Framework;

namespace TheCity.Tests
{
    public class CitizenInbornDataTests
    {
        [Test]
        public void ReturnSameValues_AsConstructorArguments()
        {
            var citizenName = new CitizenName("John", "Smith");
            var addressIndex = 1;
            var companyIndex = 2;
            var jobPostIndex = 3;

            var citizenInbornData = new CitizenInbornData(citizenName, addressIndex, companyIndex, jobPostIndex);

            Assert.AreEqual(citizenName, citizenInbornData.Name);
            Assert.AreEqual(addressIndex, citizenInbornData.AddressIndex);
            Assert.AreEqual(companyIndex, citizenInbornData.CompanyIndex);
            Assert.AreEqual(jobPostIndex, citizenInbornData.JobPostIndex);
        }

        [Test]
        public void ToString_NotEmpty()
        {
            var citizenInbornData = CorrectThings.GetCorrectInbornData();
            Assert.IsNotEmpty(citizenInbornData.ToString());
        }
    }
}