namespace TheCity.Core
{
    public record AddressData(
        StreetName StreetName,
        int HouseIndex,
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