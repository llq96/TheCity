using System.Collections.Generic;
using System.Linq;

namespace TheCity.Core
{
    public class CityData
    {
        public readonly string CityName;
        public readonly List<HouseData> HousesData;

        public readonly List<LivingAddressData> LivingAddressesData;
        public readonly List<WorkAddressData> WorkAddressesData;
        public readonly List<CitizenData> CitizensData;
        public readonly List<CompanyData> CompaniesData;

        public CityData(List<HouseData> houseDataList) : this("CityName", houseDataList)
        {
        }

        public CityData(string cityName, List<HouseData> housesData)
        {
            CityName = cityName;
            HousesData = housesData;

            LivingAddressesData = HousesData.SelectMany(x => x.LivingAddressesData).ToList();
            WorkAddressesData = HousesData.SelectMany(x => x.WorkAddressesData).ToList();

            CitizensData = HousesData
                .SelectMany(x => x.LivingAddressesData)
                .SelectMany(x => x.Citizens)
                .ToList();

            CompaniesData = HousesData
                .SelectMany(x => x.WorkAddressesData)
                .SelectMany(x => x.Companies)
                .ToList();
        }
    }
}