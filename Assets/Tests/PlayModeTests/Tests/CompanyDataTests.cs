using NUnit.Framework;

namespace TheCity.Tests
{
    [TestFixture]
    public class CompanyNameTests
    {
        [Test]
        public void ReturnSameValue_AsConstructorArguments()
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
            var companyNameStr = "Google";
            var companyType = "Inc";

            var companyName = new CompanyName(companyNameStr, companyType);

            Assert.IsNotEmpty(companyName.ToString());
        }

        [Test]
        public void FullName_NotEmpty()
        {
            var companyNameStr = "Google";
            var companyType = "Inc";

            var companyName = new CompanyName(companyNameStr, companyType);

            Assert.IsNotEmpty(companyName.FullName);
        }
    }
}