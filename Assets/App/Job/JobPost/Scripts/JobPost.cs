namespace TheCity
{
    public class JobPost
    {
        public JobTitle JobTitle { get; }
        public int JobPostIndexInCompany { get; }
        public CompanyData CompanyData { get; }

        public JobPost(int jobPostIndexInCompany, JobTitle jobTitle, CompanyData companyData)
        {
            JobPostIndexInCompany = jobPostIndexInCompany;
            JobTitle = jobTitle;
            CompanyData = companyData;
        }
    }
}