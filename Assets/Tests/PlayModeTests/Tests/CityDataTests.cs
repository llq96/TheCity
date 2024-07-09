using System.Collections.Generic;
using TheCity.Core;
using NUnit.Framework;

namespace TheCity.Tests
{
    public class CityDataTests
    {
        [Test]
        public void Properties_WhenGetAfterConstructor_IsCorrect()
        {
            var houseData = CorrectThings.GetHouseData();
            var cityData = new CityData(new List<HouseData> { houseData });

            Assert.IsNotEmpty(cityData.CityName);
            Assert.IsNotEmpty(cityData.HousesData);

            //Empty if creation without full generation city
            Assert.IsEmpty(cityData.LivingAddressesData);
            Assert.IsEmpty(cityData.WorkAddressesData);
            Assert.IsEmpty(cityData.CitizensData);
            Assert.IsEmpty(cityData.CompaniesData);
        }
    }
}