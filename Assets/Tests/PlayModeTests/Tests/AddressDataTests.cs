using NUnit.Framework;
using Random = UnityEngine.Random;

namespace TheCity.Tests
{
    public class AddressDataTests
    {
        [Test]
        public void ReturnSameValue_AsConstructorArguments()
        {
            var street = new StreetName("SomeName");
            var houseNumber = Random.Range(1, 100);
            var roomNumber = Random.Range(1, 100);
            var globalRoomIndex = Random.Range(1, 100);

            var addressData = new AddressData(street, houseNumber, roomNumber, globalRoomIndex);

            Assert.AreEqual(addressData.StreetName, street);
            Assert.AreEqual(addressData.HouseNumber, houseNumber);
            Assert.AreEqual(addressData.RoomNumber, roomNumber);
            Assert.AreEqual(addressData.GlobalRoomIndex, globalRoomIndex);
        }

        [Test]
        public void CorrectToString()
        {
            var addressData = GetCorrectAddressData();
            Assert.IsNotEmpty(addressData.ToString());
        }

        private static AddressData GetCorrectAddressData()
        {
            var street = new StreetName("SomeName");
            var houseNumber = Random.Range(1, 100);
            var roomNumber = Random.Range(1, 100);
            var globalRoomIndex = Random.Range(1, 100);

            var addressData = new AddressData(street, houseNumber, roomNumber, globalRoomIndex);

            return addressData;
        }
    }
}