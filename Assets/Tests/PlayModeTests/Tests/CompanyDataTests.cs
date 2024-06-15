using NUnit.Framework;
using System.Collections.Generic;

namespace TheCity.Tests
{
    [TestFixture]
    public class CompanyDataTests
    {
        [Test]
        public void ReturnSameValues_AsConstructorArguments()
        {
            var companyIndex = 1;
            var companyName = CorrectThings.GetCorrectCompanyName();
            var addressIndex = 2;
            var jobPosts = new List<JobPost>();

            var companyData = new CompanyData(companyIndex, companyName, addressIndex, jobPosts);

            Assert.AreEqual(companyIndex, companyData.CompanyIndex);
            Assert.AreEqual(companyName, companyData.CompanyName);
            Assert.AreEqual(addressIndex, companyData.AddressIndex);
            Assert.AreEqual(jobPosts, companyData.JobPosts);
        }

        [Test]
        public void ToString_NotEmpty()
        {
            var companyData = CorrectThings.GetCorrectCompanyData();

            Assert.IsNotEmpty(companyData.ToString());
        }
    }
}