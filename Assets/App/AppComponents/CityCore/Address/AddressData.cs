namespace TheCity.Core
{
    public record AddressData(
        StreetName StreetName,
        int HouseNumber,
        int RoomNumber,
        int GlobalRoomIndex,
        AddressType AddressType
    );


    public enum AddressType
    {
        Living,
        Working
    }
}