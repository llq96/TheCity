using NUnit.Framework;

namespace TheCity.Tests
{
    public class AddressDataTests
    {
        [Test]
        public void Properties_WhenGetAfterConstructor_ReturnValuesSameAsWasArguments()
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
        public void ToString_AfterConstructor_ReturnsNotEmpty()
        {
            var addressData = CorrectThings.GetCorrectAddressData();
            Assert.IsNotEmpty(addressData.ToString());
        }
    }
}