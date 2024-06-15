using NUnit.Framework;

namespace TheCity.Tests
{
    public class AddressDataTests
    {
        [Test]
        public void ReturnSameValue_AsConstructorArguments()
        {
            var street = new StreetName("Wall Street");
            var houseNumber = 1;
            var roomNumber = 2;
            var globalRoomIndex = 3;

            var addressData = new AddressData(street, houseNumber, roomNumber, globalRoomIndex);

            Assert.AreEqual(street, addressData.StreetName);
            Assert.AreEqual(houseNumber, addressData.HouseNumber);
            Assert.AreEqual(roomNumber, addressData.RoomNumber);
            Assert.AreEqual(globalRoomIndex, addressData.GlobalRoomIndex);
        }

        [Test]
        public void ToString_NotEmpty()
        {
            var addressData = GetCorrectAddressData();
            Assert.IsNotEmpty(addressData.ToString());
        }

        private static AddressData GetCorrectAddressData()
        {
            var street = new StreetName("Wall Street");
            var houseNumber = 1;
            var roomNumber = 2;
            var globalRoomIndex = 3;

            var addressData = new AddressData(street, houseNumber, roomNumber, globalRoomIndex);

            return addressData;
        }
    }
}