namespace TheCity
{
    public class JobPost
    {
        public IJobTitle JobTitle { get; }
        public int JobPostIndexInCompany { get; }
        public CompanyData CompanyData { get; }
        public WeeklySchedule WorkSchedule { get; }

        public JobPost(int jobPostIndexInCompany, IJobTitle jobTitle,
            CompanyData companyData, WeeklySchedule workSchedule)
        {
            JobPostIndexInCompany = jobPostIndexInCompany;
            JobTitle = jobTitle;
            CompanyData = companyData;
            WorkSchedule = workSchedule;
        }

        public override string ToString()
        {
            return $"{JobTitle.JobName} in {CompanyData.CompanyName}";
        }
    }
}