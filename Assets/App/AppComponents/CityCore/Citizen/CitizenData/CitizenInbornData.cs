namespace TheCity
{
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
}