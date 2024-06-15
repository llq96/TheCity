using NUnit.Framework;

namespace TheCity.Tests
{
    public class CityDataTests
    {
        [Test]
        public void DefaultValuesCheck()
        {
            var cityData = new CityData();

            Assert.IsNotEmpty(cityData.CityName);
            Assert.IsEmpty(cityData.AddressesDataList);
            Assert.IsEmpty(cityData.CitizensDataList);
            Assert.IsEmpty(cityData.CompaniesDataList);
        }
    }
}