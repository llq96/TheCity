using System.Linq;
using TheCity.Core;

namespace TheCity.CityDataGeneration
{
    public class CityDataGenerator
    {
        private readonly CityStreetsDataGenerator _cityStreetsDataGenerator;
        private readonly CityHousesDataGenerator _cityHousesDataGenerator;
        private readonly CityCompaniesDataGenerator _cityCompaniesDataGenerator;
        private readonly CityCitizensDataGenerator _cityCitizensDataGenerator;
        private readonly ICitizenNamesGenerator _citizenNamesGenerator;
        private readonly IStreetNamesGenerator _streetNamesGenerator;
        private readonly ICompanyNamesGenerator _companyNamesGenerator;

        public CityDataGenerator(
            CityStreetsDataGenerator cityStreetsDataGenerator,
            CityHousesDataGenerator cityHousesDataGenerator,
            CityCompaniesDataGenerator cityCompaniesDataGenerator,
            CityCitizensDataGenerator cityCitizensDataGenerator,
            ICitizenNamesGenerator citizenNamesGenerator,
            IStreetNamesGenerator streetNamesGenerator,
            ICompanyNamesGenerator companyNamesGenerator)
        {
            _cityStreetsDataGenerator = cityStreetsDataGenerator;
            _cityHousesDataGenerator = cityHousesDataGenerator;
            _cityCompaniesDataGenerator = cityCompaniesDataGenerator;
            _cityCitizensDataGenerator = cityCitizensDataGenerator;
            _citizenNamesGenerator = citizenNamesGenerator;
            _streetNamesGenerator = streetNamesGenerator;
            _companyNamesGenerator = companyNamesGenerator;
        }


        public CityData GenerateCityData(CityGenerationSettings generationSettings = null)
        {
            generationSettings ??= new();

            _citizenNamesGenerator.Reset();
            _streetNamesGenerator.Reset();
            _companyNamesGenerator.Reset();

            var streets = _cityStreetsDataGenerator.GenerateStreetsData(generationSettings.CountStreets);

            var houses = _cityHousesDataGenerator.GenerateHousesByCountAddresses(
                streets,
                generationSettings.CountLivingAddresses,
                generationSettings.CountWorkingAddresses);

            var workAddresses = houses.SelectMany(x => x.WorkAddressesData).ToList();
            var livingAddresses = houses.SelectMany(x => x.LivingAddressesData).ToList();

            var companies = _cityCompaniesDataGenerator
                .GenerateCompanies(generationSettings.CountCompanies, workAddresses);

            var jobPostsList = companies.SelectMany(companyData => companyData.JobPosts).ToList();

            var citizens = _cityCitizensDataGenerator
                .GenerateCitizens(generationSettings.CountCitizens, livingAddresses, jobPostsList);

            CityData cityData = new(streets);
            return cityData;
        }
    }
}

public class CityGenerationSettings
{
    public readonly int CountStreets = 1;
    public readonly int CountCitizens = 1;
    public readonly int CountCompanies = 6;
    public readonly int CountLivingAddresses = 6;
    public readonly int CountWorkingAddresses = 6;
}