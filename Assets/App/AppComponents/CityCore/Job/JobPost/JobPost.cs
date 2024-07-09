namespace TheCity.Core
{
    public record JobPost(
        IJobTitle JobTitle,
        CompanyData CompanyData,
        WeeklySchedule WorkSchedule
    );
}