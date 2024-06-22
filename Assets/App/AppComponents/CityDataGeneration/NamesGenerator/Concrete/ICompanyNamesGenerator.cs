using TheCity.Core;

namespace TheCity.CityDataGeneration
{
    public interface ICompanyNamesGenerator
    {
        CompanyName GetNextCompanyName();
        void Reset();
    }
}