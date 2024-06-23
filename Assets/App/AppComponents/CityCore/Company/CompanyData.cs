using System.Collections.Generic;

namespace TheCity.Core
{
    public record CompanyData(
        int CompanyIndex,
        CompanyName CompanyName, 
        int AddressIndex,
        List<JobPost> JobPosts
    );

    public readonly struct CompanyName
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

        public override string ToString() => FullName;
    }
}