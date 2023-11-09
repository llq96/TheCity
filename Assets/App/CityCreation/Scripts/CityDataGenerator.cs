using JetBrains.Annotations;
using Zenject;

namespace TheCity
{
    [UsedImplicitly]
    public class CityDataGenerator
    {
        [Inject] private NamesGenerator NamesGenerator { get; }

        public CityData GenerateCityData(CityGenerationSettings generationSettings = null)
        {
            generationSettings ??= new();

            CityData cityData = new();
            NamesGenerator.ClearGeneratedLists();

            GenerateCitizens(generationSettings, cityData);
            GenerateCompanies(generationSettings, cityData);

            return cityData;
        }


        #region Citizens

        private void GenerateCitizens(CityGenerationSettings generationSettings, CityData cityData)
        {
            for (int i = 0; i < generationSettings.CountCitizens; i++)
            {
                var newCitizenData = GenerateNewCitizenData();
                cityData.CitizensDataList.Add(newCitizenData);
            }
        }

        private CitizenData GenerateNewCitizenData()
        {
            var randomCitizenName = NamesGenerator.GenerateRandomCitizenName();
            var inbornData = new CitizenInbornData(randomCitizenName);
            var citizenData = new CitizenData(inbornData);
            return citizenData;
        }

        #endregion

        #region Companies

        private void GenerateCompanies(CityGenerationSettings generationSettings, CityData cityData)
        {
            for (int i = 0; i < generationSettings.CountCompanies; i++)
            {
                var newCompanyData = GenerateNewCompanyData();
                cityData.CompaniesDataList.Add(newCompanyData);
            }
        }

        private CompanyData GenerateNewCompanyData()
        {
            var randomCompanyName = NamesGenerator.GenerateRandomCompanyName();
            var companyData = new CompanyData(randomCompanyName);
            return companyData;
        }

        #endregion
    }

    public class CityGenerationSettings
    {
        public int CountCitizens = 3;
        public int CountCompanies = 3;
    }
}