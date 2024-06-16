using System;

namespace TheCity
{
    [TestsInfo("CitizenInbornDataTests", 100)]
    public class CitizenInbornData
    {
        public CitizenName Name { get; }
        public int AddressIndex { get; }
        public int CompanyIndex { get; }
        public int JobPostIndex { get; }

        public CitizenInbornData(CitizenName name, int addressIndex, int companyIndex, int jobPostIndex)
        {
            Name = name;
            AddressIndex = addressIndex;
            CompanyIndex = companyIndex;
            JobPostIndex = jobPostIndex;
        }

        public override string ToString() => Name.ToString();
    }

    [TestsInfo("CitizenNameTests", 100)]
    public readonly struct CitizenName
    {
        public string FirstName { get; }
        public string SecondName { get; }
        public string FullName { get; }

        public CitizenName(string firstName, string secondName)
        {
            if (string.IsNullOrEmpty(firstName))
                throw new ArgumentException($"Null Or Empty {nameof(firstName)}");

            if (string.IsNullOrEmpty(secondName))
                throw new ArgumentException($"Null Or Empty {nameof(secondName)}");

            FirstName = firstName;
            SecondName = secondName;

            FullName = $"{firstName} {secondName}";
        }

        public override string ToString() => FullName;
    }
}