namespace TheCity
{
    public interface ICitizenNamesGenerator
    {
        CitizenName GetNextCitizenName();
        void Reset();
    }
}