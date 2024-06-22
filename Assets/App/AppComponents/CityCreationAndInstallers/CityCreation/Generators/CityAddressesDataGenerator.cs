using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace TheCity.CityGeneration
{
    [UsedImplicitly]
    [TestsInfo("CityAddressesDataGeneratorTests", 100)]
    public class CityAddressesDataGenerator
    {
        [Inject] private NamesGenerator NamesGenerator { get; }

        public List<AddressData> GenerateAddresses(int countLivingAddresses, int countWorkAddresses)
        {
            var addressesDataList = new List<AddressData>();

            var globalRoomIndex = 0;
            var randomStreetName = NamesGenerator.GenerateRandomStreetName(); //1 улица
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