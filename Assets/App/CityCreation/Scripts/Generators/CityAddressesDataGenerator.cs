using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace TheCity.CityGeneration
{
    [UsedImplicitly]
    public class CityAddressesDataGenerator
    {
        [Inject] private NamesGenerator NamesGenerator { get; }

        public void GenerateAddresses(CityGenerationSettings generationSettings, CityData cityData)
        {
            var randomStreetName = NamesGenerator.GenerateRandomStreetName();
            for (int i = 0; i < generationSettings.CountAddresses; i++)
            {
                var newAddressData = new AddressData(randomStreetName, i, Random.Range(10, 50), i);
                cityData.AddressesDataList.Add(newAddressData);
            }
        }
    }
}