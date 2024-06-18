namespace TheCity
{
    [TestsInfo("AddressDataTests", 100)]
    public class AddressData
    {
        public StreetName StreetName { get; }
        public int HouseNumber { get; }
        public int RoomNumber { get; }
        public int GlobalRoomIndex { get; }

        public AddressData(StreetName streetName, int houseNumber, int roomNumber, int globalRoomIndex)
        {
            StreetName = streetName;
            HouseNumber = houseNumber;
            RoomNumber = roomNumber;
            GlobalRoomIndex = globalRoomIndex;
        }

        public override string ToString()
        {
            return $"{StreetName}, {HouseNumber}, {RoomNumber}";
        }
    }
}