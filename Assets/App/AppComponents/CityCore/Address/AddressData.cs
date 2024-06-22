namespace TheCity
{
    public class AddressData
    {
        public StreetName StreetName { get; }
        public int HouseNumber { get; }
        public int RoomNumber { get; }
        public int GlobalRoomIndex { get; }
        public AddressType AddressType { get; private set; }

        public AddressData(StreetName streetName, int houseNumber, int roomNumber, int globalRoomIndex,
            AddressType addressType)
        {
            StreetName = streetName;
            HouseNumber = houseNumber;
            RoomNumber = roomNumber;
            GlobalRoomIndex = globalRoomIndex;
            AddressType = addressType;
        }

        public override string ToString()
        {
            return $"{StreetName}, {HouseNumber}, {RoomNumber}";
        }
    }

    public enum AddressType
    {
        Living,
        Working
    }
}