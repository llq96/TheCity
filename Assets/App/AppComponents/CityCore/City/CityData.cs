using System.Collections.Generic;

namespace TheCity.Core
{
    public class CityData //TODO Rework
    {
        public readonly string CityName = "CityName";
        public readonly List<HouseData> HouseDataList = new();
        // public readonly List<AddressData> AddressesDataList = new();
        public readonly List<CitizenData> CitizensDataList = new();
        public readonly List<CompanyData> CompaniesDataList = new();
    }
}