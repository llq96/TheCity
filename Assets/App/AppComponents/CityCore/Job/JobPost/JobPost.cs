namespace TheCity.Core
{
    public record JobPost(
        int JobPostIndexInCompany,
        IJobTitle JobTitle,
        CompanyData CompanyData,
        WeeklySchedule WorkSchedule
    );
}