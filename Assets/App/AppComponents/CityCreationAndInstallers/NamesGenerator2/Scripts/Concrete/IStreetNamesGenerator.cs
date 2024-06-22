namespace TheCity
{
    public interface IStreetNamesGenerator
    {
        StreetName GetNextStreetName();
        void Reset();
    }
}