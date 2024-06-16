using NUnit.Framework;

namespace TheCity.Tests
{
    [TestFixture]
    public class JobPostTests
    {
        [Test]
        public void Constructor_WhenCalled_SetPropertiesCorrect()
        {
            var jobPostIndex = 1;
            var jobTitle = CorrectThings.GetIJobTitle();
            var companyData = CorrectThings.GetCompanyData();
            var workSchedule = CorrectThings.GetWeeklySchedule();

            var jobPost = new JobPost(jobPostIndex, jobTitle, companyData, workSchedule);

            Assert.AreEqual(jobPostIndex, jobPost.JobPostIndexInCompany);
            Assert.AreEqual(jobTitle, jobPost.JobTitle);
            Assert.AreEqual(companyData, jobPost.CompanyData);
            Assert.AreEqual(workSchedule, jobPost.WorkSchedule);
        }

        [Test]
        public void ToString_AfterConstructor_ReturnsNotEmpty()
        {
            var addressData = CorrectThings.GetJobPost();
            Assert.IsNotEmpty(addressData.ToString());
        }
    }
}