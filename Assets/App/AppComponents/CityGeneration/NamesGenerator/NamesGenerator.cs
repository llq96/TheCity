using Zenject;

namespace TheCity
{
    public class NamesGenerator : INamesGenerator
    {
        [Inject] private ICitizenNamesGenerator CitizenNamesGenerator { get; }
        [Inject] private IStreetNamesGenerator StreetNamesGenerator { get; }
        [Inject] private ICompanyNamesGenerator CompanyNamesGenerator { get; }


        public void Reset()
        {
            CitizenNamesGenerator.Reset();
            StreetNamesGenerator.Reset();
            CompanyNamesGenerator.Reset();
        }

        public CitizenName GenerateRandomCitizenName()
        {
            return CitizenNamesGenerator.GetNextCitizenName();
        }

        public StreetName GenerateRandomStreetName()
        {
            return StreetNamesGenerator.GetNextStreetName();
        }

        public CompanyName GenerateRandomCompanyName()
        {
            return CompanyNamesGenerator.GetNextCompanyName();
        }
    }
}