namespace TheCity
{
    public interface INamesGenerator
    {
        void Reset();
        CitizenName GenerateRandomCitizenName();
        StreetName GenerateRandomStreetName();
        CompanyName GenerateRandomCompanyName();
    }
}