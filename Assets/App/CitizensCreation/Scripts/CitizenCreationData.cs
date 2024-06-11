namespace TheCity
{
    public class CitizenCreationData
    {
        public CitizenData CitizenData { get; }
        public CompanyData CompanyData { get; }

        public CitizenCreationData(CitizenData citizenData, CompanyData companyData)
        {
            CitizenData = citizenData;
            CompanyData = companyData;
        }
    }
}