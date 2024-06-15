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

            CityAddressesDataGenerator.GenerateAddresses(generationSettings, cityData);
            var _currentAddressIndex = 0;

            CityCompaniesDataGenerator.GenerateCompanies(generationSettings, cityData, ref _currentAddressIndex);
            var jobPostsList = CityCompaniesDataGenerator.GetJobPostsList(cityData);

            CityCitizensDataGenerator.GenerateCitizens(generationSettings, cityData, ref _currentAddressIndex,
                jobPostsList);

            return cityData;
        }
    }

    public class CityGenerationSettings
    {
        public int CountCitizens = 6;
        public int CountCompanies = 3;
        public int CountAddresses = 9;
    }
}