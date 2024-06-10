using System.Collections.Generic;
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
        [Inject] private PossibleJobTitles PossibleJobTitles { get; }

        public CityData GenerateCityData(CityGenerationSettings generationSettings = null)
        {
            generationSettings ??= new();

            CityData cityData = new();
            NamesGenerator.ClearGeneratedLists();

            GenerateAddresses(generationSettings, cityData);
            var _currentAddressIndex = 0;
            GenerateCompanies(generationSettings, cityData, ref _currentAddressIndex);
            GenerateCitizens(generationSettings, cityData, ref _currentAddressIndex);

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
            ref int addressIndex)
        {
            var citizensWithCurrentAddress = 0;
            for (int i = 0; i < generationSettings.CountCitizens; i++)
            {
                var newCitizenData = GenerateNewCitizenData(addressIndex, i % generationSettings.CountCompanies);
                cityData.CitizensDataList.Add(newCitizenData);

                citizensWithCurrentAddress++;
                if (citizensWithCurrentAddress >= CitizenPerAddress)
                {
                    addressIndex++;
                }
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
            ref int addressIndex)
        {
            for (int i = 0; i < generationSettings.CountCompanies; i++)
            {
                var newCompanyData = GenerateNewCompanyData(addressIndex);
                cityData.CompaniesDataList.Add(newCompanyData);
                addressIndex++;
            }
        }

        private CompanyData GenerateNewCompanyData(int addressIndex)
        {
            var randomCompanyName = NamesGenerator.GenerateRandomCompanyName();
            var countJobPosts = Random.Range(1, 3); //TODO
            var jobPosts = new List<JobPost>();
            for (int i = 0; i < countJobPosts; i++)
            {
                var jobTitle = PossibleJobTitles.JobTitles.GetRandomElement();
                var jobPost = new JobPost(jobTitle);
                jobPosts.Add(jobPost);
            }

            var companyData = new CompanyData(randomCompanyName, addressIndex, jobPosts);
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