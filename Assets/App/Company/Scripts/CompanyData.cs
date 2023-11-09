namespace TheCity
{
    public class CompanyData
    {
        public CompanyName CompanyName { get; }
        public int AddressIndex { get; }

        public CompanyData(CompanyName companyName, int addressIndex)
        {
            CompanyName = companyName;
            AddressIndex = addressIndex;
        }
    }

    public struct CompanyName
    {
        public string Name { get; }
        public string Type { get; }
        public string FullName { get; }

        public CompanyName(string name, string type)
        {
            Name = name;
            Type = type;

            FullName = $"{name} {type}";
        }
    }
}