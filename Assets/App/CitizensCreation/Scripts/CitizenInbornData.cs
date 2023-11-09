namespace TheCity
{
    public class CitizenInbornData
    {
        public CitizenInbornData(CitizenName name, int addressIndex, int companyIndex)
        {
            Name = name;
            AddressIndex = addressIndex;
            CompanyIndex = companyIndex;
        }

        public CitizenName Name { get; }
        public int AddressIndex { get; }
        public int CompanyIndex { get; }
    }

    public struct CitizenName
    {
        public string FirstName { get; }
        public string SecondName { get; }
        public string FullName { get; }

        public CitizenName(string firstName, string secondName)
        {
            FirstName = firstName;
            SecondName = secondName;

            FullName = $"{firstName} {secondName}";
        }
    }
}