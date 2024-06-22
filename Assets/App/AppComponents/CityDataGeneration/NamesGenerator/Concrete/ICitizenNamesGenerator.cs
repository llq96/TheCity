using TheCity.Core;

namespace TheCity.CityDataGeneration
{
    public interface ICitizenNamesGenerator
    {
        CitizenName GetNextCitizenName();
        void Reset();
    }
}