using System.Collections.Generic;

namespace TheCity.Core
{
    public abstract record AddressData(
        HouseData HouseData,
        int RoomNumber
    );

    public record LivingAddressData(HouseData HouseData, int RoomNumber)
        : AddressData(HouseData, RoomNumber)
    {
        public List<CitizenData> Citizens { get; } = new();
    };

    public record WorkAddressData(HouseData HouseData, int RoomNumber)
        : AddressData(HouseData, RoomNumber)
    {
        public List<CompanyData> Companies { get; } = new();
    }
}