namespace TheCity.Core
{
    public record DayScheduleItem(
        TimeOnly Time,
        Activity Activity
    );
}