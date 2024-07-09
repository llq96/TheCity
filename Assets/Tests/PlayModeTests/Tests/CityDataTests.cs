using TheCity.Core;
using NUnit.Framework;

namespace TheCity.Tests
{
    public class CityDataTests
    {
        [Test]
        public void Properties_WhenGetAfterConstructor_IsCorrect()
        {
            var cityData = new CityData();

            Assert.IsNotEmpty(cityData.CityName);
            Assert.IsEmpty(cityData.HouseDataList);
            Assert.IsEmpty(cityData.CitizensDataList);
            Assert.IsEmpty(cityData.CompaniesDataList);
        }
    }
}