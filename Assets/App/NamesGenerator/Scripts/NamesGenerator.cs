using JetBrains.Annotations;
using Zenject;

namespace TheCity
{
    [UsedImplicitly]
    public class NamesGenerator
    {
        [Inject] private CitizenNamesGenerator CitizenNamesGenerator { get; }
        [Inject] private StreetNamesGenerator StreetNamesGenerator { get; }
        [Inject] private CompanyNamesGenerator CompanyNamesGenerator { get; }


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