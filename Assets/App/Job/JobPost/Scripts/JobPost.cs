namespace TheCity
{
    public class JobPost
    {
        public JobTitle JobTitle { get; }
        public int JobPostIndexInCompany { get; }
        public CompanyData CompanyData { get; }
        public WeeklySchedule WorkSchedule { get; }

        public JobPost(int jobPostIndexInCompany, JobTitle jobTitle,
            CompanyData companyData, WeeklySchedule workSchedule)
        {
            JobPostIndexInCompany = jobPostIndexInCompany;
            JobTitle = jobTitle;
            CompanyData = companyData;
            WorkSchedule = workSchedule;
        }
    }
}