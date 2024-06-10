using System.Collections.Generic;

namespace TheCity
{
    public class CompanyData
    {
        public int CompanyIndex { get; }
        public CompanyName CompanyName { get; }
        public int AddressIndex { get; }
        public List<JobPost> JobPosts { get; }

        public CompanyData(int companyIndex, CompanyName companyName, int addressIndex, List<JobPost> jobPosts)
        {
            CompanyIndex = companyIndex;
            CompanyName = companyName;
            AddressIndex = addressIndex;
            JobPosts = jobPosts;
        }

        public override string ToString() => CompanyName.ToString();
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

        public override string ToString() => FullName;
    }
}