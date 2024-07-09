using System.Collections.Generic;

namespace TheCity.Core
{
    public record HouseData(StreetData StreetData)
    {
        public List<LivingAddressData> LivingAddressesData { get; } = new();
        public List<WorkAddressData> WorkAddressesData { get; } = new();
    }
}