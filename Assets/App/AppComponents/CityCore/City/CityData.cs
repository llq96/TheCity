using System.Collections.Generic;

namespace TheCity.Core
{
    public class CityData
    {
        public readonly string CityName = "CityName";
        public readonly List<AddressData> AddressesDataList = new();
        public readonly List<CitizenData> CitizensDataList = new();
        public readonly List<CompanyData> CompaniesDataList = new();
    }
}