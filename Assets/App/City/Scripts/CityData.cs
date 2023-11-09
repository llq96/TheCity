using System.Collections.Generic;

namespace TheCity
{
    public class CityData
    {
        public readonly string CityName = "CityName";
        public readonly List<CitizenData> CitizensDataList = new();
        public readonly List<CompanyData> CompaniesDataList = new();
    }
}