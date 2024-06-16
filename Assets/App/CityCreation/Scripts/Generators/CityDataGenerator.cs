using System.Linq;
using JetBrains.Annotations;
using Zenject;

namespace TheCity.CityGeneration
{
    [UsedImplicitly]
    public class CityDataGenerator
    {
        [Inject] private CityAddressesDataGenerator CityAddressesDataGenerator { get; }
        [Inject] private CityCompaniesDataGenerator CityCompaniesDataGenerator { get; }
        [Inject] private CityCitizensDataGenerator CityCitizensDataGenerator { get; }
        [Inject] private NamesGenerator NamesGenerator { get; }

        public CityData GenerateCityData(CityGenerationSettings generationSettings = null)
        {
            generationSettings ??= new();
            CityData cityData = new();

            NamesGenerator.Reset();

            var addresses = CityAddressesDataGenerator.GenerateAddresses(generationSettings.CountAddresses);
            cityData.AddressesDataList.AddRange(addresses);

            var _currentAddressIndex = 0;

            var companies = CityCompaniesDataGenerator
                .GenerateCompanies(generationSettings.CountCompanies, ref _currentAddressIndex);
            cityData.CompaniesDataList.AddRange(companies);

            var jobPostsList = companies.SelectMany(companyData => companyData.JobPosts).ToList();

            var citizens = CityCitizensDataGenerator
                .GenerateCitizens(generationSettings.CountCitizens, ref _currentAddressIndex, jobPostsList);

            cityData.CitizensDataList.AddRange(citizens);

            return cityData;
        }
    }
}

public class CityGenerationSettings
{
    public readonly int CountCitizens = 6;
    public readonly int CountCompanies = 3;
    public readonly int CountAddresses = 9;
}