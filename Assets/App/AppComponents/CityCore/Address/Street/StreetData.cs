using System.Collections.Generic;

namespace TheCity.Core
{
    public record StreetData(StreetName StreetName)
    {
        public List<HouseData> HousesData { get; } = new();
    };
}