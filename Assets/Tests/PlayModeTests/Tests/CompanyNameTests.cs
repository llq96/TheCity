using NUnit.Framework;

namespace TheCity.Tests
{
    [TestFixture]
    public class CompanyNameTests
    {
        [Test]
        public void ReturnSameValues_AsConstructorArguments()
        {
            var companyNameStr = "Google";
            var companyType = "Inc";

            var companyName = new CompanyName(companyNameStr, companyType);

            Assert.AreEqual(companyNameStr, companyName.Name);
            Assert.AreEqual(companyType, companyName.Type);
        }

        [Test]
        public void ToString_NotEmpty()
        {
            var companyName = CorrectThings.GetCorrectCompanyName();

            Assert.IsNotEmpty(companyName.ToString());
        }

        [Test]
        public void FullName_NotEmpty()
        {
            var companyName = CorrectThings.GetCorrectCompanyName();

            Assert.IsNotEmpty(companyName.FullName);
        }
    }
}