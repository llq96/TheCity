using System.Linq;
using Zenject;

namespace TheCity.CityGeneration
{
    public class CityDataGenerator
    {
        [Inject] private CityAddressesDataGenerator CityAddressesDataGenerator { get; }
        [Inject] private CityCompaniesDataGenerator CityCompaniesDataGenerator { get; }
        [Inject] private CityCitizensDataGenerator CityCitizensDataGenerator { get; }

        [Inject] private ICitizenNamesGenerator CitizenNamesGenerator { get; }
        [Inject] private IStreetNamesGenerator StreetNamesGenerator { get; }
        [Inject] private ICompanyNamesGenerator CompanyNamesGenerator { get; }


        public CityData GenerateCityData(CityGenerationSettings generationSettings = null)
        {
            generationSettings ??= new();
            CityData cityData = new();

            CitizenNamesGenerator.Reset();
            StreetNamesGenerator.Reset();
            CompanyNamesGenerator.Reset();

            var addresses = CityAddressesDataGenerator.GenerateAddresses(
                generationSettings.CountLivingAddresses,
                generationSettings.CountWorkingAddresses);
            cityData.AddressesDataList.AddRange(addresses);

            var companies = CityCompaniesDataGenerator
                .GenerateCompanies(generationSettings.CountCompanies, ref addresses);
            cityData.CompaniesDataList.AddRange(companies);

            var jobPostsList = companies.SelectMany(companyData => companyData.JobPosts).ToList();

            var citizens = CityCitizensDataGenerator
                .GenerateCitizens(generationSettings.CountCitizens, ref addresses, jobPostsList);

            cityData.CitizensDataList.AddRange(citizens);

            return cityData;
        }
    }
}

public class CityGenerationSettings
{
    public readonly int CountCitizens = 6;
    public readonly int CountCompanies = 3;
    public readonly int CountLivingAddresses = 3;
    public readonly int CountWorkingAddresses = 3;
}