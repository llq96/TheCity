using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace TheCity
{
    [UsedImplicitly]
    public class CityDataGenerator
    {
        private const int CitizenPerAddress = 2;
        [Inject] private NamesGenerator NamesGenerator { get; }

        private int _currentAddressIndex;

        public CityData GenerateCityData(CityGenerationSettings generationSettings = null)
        {
            generationSettings ??= new();

            CityData cityData = new();
            NamesGenerator.ClearGeneratedLists();

            GenerateAddresses(generationSettings, cityData);
            _currentAddressIndex = 0;
            GenerateCitizens(generationSettings, cityData, _currentAddressIndex);
            _currentAddressIndex = Mathf.CeilToInt(generationSettings.CountCitizens / (float)CitizenPerAddress);
            GenerateCompanies(generationSettings, cityData, _currentAddressIndex);

            return cityData;
        }

        #region Addresses

        private void GenerateAddresses(CityGenerationSettings generationSettings, CityData cityData)
        {
            var randomStreetName = NamesGenerator.GenerateRandomStreetName();
            for (int i = 0; i < generationSettings.CountAddresses; i++)
            {
                var newAddressData = new AddressData(randomStreetName, i, Random.Range(10, 50), i);
                cityData.AddressesDataList.Add(newAddressData);
            }
        }

        #endregion

        #region Citizens

        private void GenerateCitizens(CityGenerationSettings generationSettings, CityData cityData,
            int startAddressIndex)
        {
            for (int i = 0; i < generationSettings.CountCitizens; i++)
            {
                var newCitizenData =
                    GenerateNewCitizenData(
                        startAddressIndex + i / CitizenPerAddress,
                        i % generationSettings.CountCompanies);
                cityData.CitizensDataList.Add(newCitizenData);
            }
        }

        private CitizenData GenerateNewCitizenData(int addressIndex, int companyIndex)
        {
            var randomCitizenName = NamesGenerator.GenerateRandomCitizenName();
            var inbornData = new CitizenInbornData(randomCitizenName, addressIndex, companyIndex);
            var citizenData = new CitizenData(inbornData);
            return citizenData;
        }

        #endregion

        #region Companies

        private void GenerateCompanies(CityGenerationSettings generationSettings, CityData cityData,
            int startAddressIndex)
        {
            for (int i = 0; i < generationSettings.CountCompanies; i++)
            {
                var newCompanyData = GenerateNewCompanyData(startAddressIndex + i);
                cityData.CompaniesDataList.Add(newCompanyData);
            }
        }

        private CompanyData GenerateNewCompanyData(int addressIndex)
        {
            var randomCompanyName = NamesGenerator.GenerateRandomCompanyName();
            var companyData = new CompanyData(randomCompanyName, addressIndex);
            return companyData;
        }

        #endregion
    }

    public class CityGenerationSettings
    {
        public int CountCitizens = 6;
        public int CountCompanies = 3;
        public int CountAddresses = 9;
    }
}