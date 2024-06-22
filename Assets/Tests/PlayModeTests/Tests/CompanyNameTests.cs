using TheCity.Core;
using NUnit.Framework;

namespace TheCity.Tests
{
    [TestFixture]
    public class CompanyNameTests
    {
        [Test]
        public void Constructor_WhenCalled_SetPropertiesCorrect()
        {
            var companyNameStr = "Google";
            var companyType = "Inc";

            var companyName = new CompanyName(companyNameStr, companyType);

            Assert.AreEqual(companyNameStr, companyName.Name);
            Assert.AreEqual(companyType, companyName.Type);
        }

        [Test]
        public void ToString_AfterConstructor_ReturnsNotEmpty()
        {
            var companyName = CorrectThings.GetCompanyName();

            Assert.IsNotEmpty(companyName.ToString());
        }

        [Test]
        public void FullName_AfterConstructor_ReturnsNotEmpty()
        {
            var companyName = CorrectThings.GetCompanyName();

            Assert.IsNotEmpty(companyName.FullName);
        }
    }
}