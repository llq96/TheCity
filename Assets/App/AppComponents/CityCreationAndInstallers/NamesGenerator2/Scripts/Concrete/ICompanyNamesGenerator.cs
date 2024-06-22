namespace TheCity
{
    public interface ICompanyNamesGenerator
    {
        CompanyName GetNextCompanyName();
        void Reset();
    }
}