using System.Collections.Generic;
using TheCity.Core;

namespace TheCity.CityDataGeneration
{
    public class CityAddressesDataGenerator
    {
        private readonly IStreetNamesGenerator _streetNamesGenerator;

        public CityAddressesDataGenerator(IStreetNamesGenerator streetNamesGenerator)
        {
            _streetNamesGenerator = streetNamesGenerator;
        }

        public List<AddressData> GenerateAddresses(int countLivingAddresses, int countWorkAddresses)
        {
            var addressesDataList = new List<AddressData>();

            var globalRoomIndex = 0;
            var randomStreetName = _streetNamesGenerator.GetNextStreetName(); //1 улица
            for (int i = 0; i < countLivingAddresses; i++)
            {
                var newAddressData =
                    new AddressData(randomStreetName, i + 1, Random.Range(10, 50), globalRoomIndex++,
                        AddressType.Living); //1 адрес на 1 дом
                addressesDataList.Add(newAddressData);
            }

            for (int i = 0; i < countWorkAddresses; i++)
            {
                var newAddressData =
                    new AddressData(randomStreetName, i + 1, Random.Range(10, 50), globalRoomIndex++,
                        AddressType.Working); //1 адрес на 1 дом
                addressesDataList.Add(newAddressData);
            }

            return addressesDataList;
        }
    }
}