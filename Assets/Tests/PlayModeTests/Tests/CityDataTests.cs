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
            var streetData = CorrectThings.GetStreetData();
            var cityData = new CityData(new List<StreetData> { streetData });

            Assert.IsNotEmpty(cityData.CityName);
            Assert.IsNotEmpty(cityData.StreetsData);

            //Empty if creation without full generation city
            Assert.IsEmpty(cityData.HousesData);
            Assert.IsEmpty(cityData.LivingAddressesData);
            Assert.IsEmpty(cityData.WorkAddressesData);
            Assert.IsEmpty(cityData.CitizensData);
            Assert.IsEmpty(cityData.CompaniesData);
        }
    }
}