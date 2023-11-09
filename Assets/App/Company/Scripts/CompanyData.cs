namespace TheCity
{
    public class CompanyData
    {
        public CompanyName CompanyName { get; }

        public CompanyData(CompanyName companyName)
        {
            CompanyName = companyName;
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