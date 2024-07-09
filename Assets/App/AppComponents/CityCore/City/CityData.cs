using System.Collections.Generic;
using System.Linq;

namespace TheCity.Core
{
    public class CityData
    {
        public readonly string CityName;
        public readonly List<StreetData> StreetsData;

        public readonly List<HouseData> HousesData;
        public readonly List<LivingAddressData> LivingAddressesData;
        public readonly List<WorkAddressData> WorkAddressesData;
        public readonly List<CitizenData> CitizensData;
        public readonly List<CompanyData> CompaniesData;

        public CityData(List<StreetData> streets) : this("CityName", streets)
        {
        }

        public CityData(string cityName, List<StreetData> streetsData)
        {
            CityName = cityName;
            StreetsData = streetsData;

            HousesData = StreetsData.SelectMany(x => x.HousesData).ToList();
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