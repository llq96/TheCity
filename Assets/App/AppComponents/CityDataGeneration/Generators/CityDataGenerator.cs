using System.Linq;
using TheCity.Core;

namespace TheCity.CityDataGeneration
{
    public class CityDataGenerator
    {
        private readonly CityAddressesDataGenerator _cityAddressesDataGenerator;
        private readonly CityCompaniesDataGenerator _cityCompaniesDataGenerator;
        private readonly CityCitizensDataGenerator _cityCitizensDataGenerator;
        private readonly ICitizenNamesGenerator _citizenNamesGenerator;
        private readonly IStreetNamesGenerator _streetNamesGenerator;
        private readonly ICompanyNamesGenerator _companyNamesGenerator;

        public CityDataGenerator(
            CityAddressesDataGenerator cityAddressesDataGenerator,
            CityCompaniesDataGenerator cityCompaniesDataGenerator,
            CityCitizensDataGenerator cityCitizensDataGenerator,
            ICitizenNamesGenerator citizenNamesGenerator,
            IStreetNamesGenerator streetNamesGenerator,
            ICompanyNamesGenerator companyNamesGenerator)
        {
            _cityAddressesDataGenerator = cityAddressesDataGenerator;
            _cityCompaniesDataGenerator = cityCompaniesDataGenerator;
            _cityCitizensDataGenerator = cityCitizensDataGenerator;
            _citizenNamesGenerator = citizenNamesGenerator;
            _streetNamesGenerator = streetNamesGenerator;
            _companyNamesGenerator = companyNamesGenerator;
        }


        public CityData GenerateCityData(CityGenerationSettings generationSettings = null)
        {
            generationSettings ??= new();
            CityData cityData = new();

            _citizenNamesGenerator.Reset();
            _streetNamesGenerator.Reset();
            _companyNamesGenerator.Reset();

            var addresses = _cityAddressesDataGenerator.GenerateAddresses(
                generationSettings.CountLivingAddresses,
                generationSettings.CountWorkingAddresses);
            cityData.AddressesDataList.AddRange(addresses);

            var companies = _cityCompaniesDataGenerator
                .GenerateCompanies(generationSettings.CountCompanies, ref addresses);
            cityData.CompaniesDataList.AddRange(companies);

            var jobPostsList = companies.SelectMany(companyData => companyData.JobPosts).ToList();

            var citizens = _cityCitizensDataGenerator
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