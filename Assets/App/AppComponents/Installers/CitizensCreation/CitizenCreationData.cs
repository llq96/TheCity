using TheCity.Core;

namespace TheCity.Installers
{
    public record CitizenCreationData(
        CitizenData CitizenData,
        CompanyData CompanyData
    );
}