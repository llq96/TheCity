using NUnit.Framework;

namespace TheCity.Tests
{
    public class CitizenInbornDataTests
    {
        [Test]
        public void ReturnSameValue_AsConstructorArguments()
        {
            var citizenName = new CitizenName("FirstName", "SecondName");
            var addressIndex = UnityEngine.Random.Range(1, 100);
            var companyIndex = UnityEngine.Random.Range(1, 100);
            var jobPostIndex = UnityEngine.Random.Range(1, 100);

            var citizenInbornData = new CitizenInbornData(citizenName, addressIndex, companyIndex, jobPostIndex);

            Assert.AreEqual(citizenInbornData.Name, citizenName);
            Assert.AreEqual(citizenInbornData.AddressIndex, addressIndex);
            Assert.AreEqual(citizenInbornData.CompanyIndex, companyIndex);
            Assert.AreEqual(citizenInbornData.JobPostIndex, jobPostIndex);
        }

        [Test]
        public void CorrectToString()
        {
            var citizenInbornData = GetCorrectInbornData();
            Assert.IsNotEmpty(citizenInbornData.ToString());
        }

        private static CitizenInbornData GetCorrectInbornData()
        {
            var citizenName = new CitizenName("FirstName", "SecondName");
            var addressIndex = UnityEngine.Random.Range(1, 100);
            var companyIndex = UnityEngine.Random.Range(1, 100);
            var jobPostIndex = UnityEngine.Random.Range(1, 100);

            var citizenInbornData = new CitizenInbornData(citizenName, addressIndex, companyIndex, jobPostIndex);

            return citizenInbornData;
        }
    }
}