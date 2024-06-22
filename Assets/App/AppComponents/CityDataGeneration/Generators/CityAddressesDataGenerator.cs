using System.Collections.Generic;
using TheCity.Core;
using Zenject;

namespace TheCity.CityDataGeneration
{
    public class CityAddressesDataGenerator
    {
        [Inject] private IStreetNamesGenerator StreetNamesGenerator { get; }

        public List<AddressData> GenerateAddresses(int countLivingAddresses, int countWorkAddresses)
        {
            var addressesDataList = new List<AddressData>();

            var globalRoomIndex = 0;
            var randomStreetName = StreetNamesGenerator.GetNextStreetName(); //1 улица
            for (int i = 0; i < countLivingAddresses; i++)
            {
                var newAddressData =
                    new AddressData(randomStreetName, i, Random.Range(10, 50), globalRoomIndex++,
                        AddressType.Living); //1 адрес на 1 дом
                addressesDataList.Add(newAddressData);
            }

            for (int i = 0; i < countWorkAddresses; i++)
            {
                var newAddressData =
                    new AddressData(randomStreetName, i, Random.Range(10, 50), globalRoomIndex++,
                        AddressType.Working); //1 адрес на 1 дом
                addressesDataList.Add(newAddressData);
            }

            return addressesDataList;
        }
    }
}