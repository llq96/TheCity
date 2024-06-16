namespace TheCity
{
    [TestsInfo("DayScheduleItemTests", 100)]
    public class DayScheduleItem
    {
        public TimeOnly Time { get; }
        public Activity Activity { get; }

        public DayScheduleItem(TimeOnly time, Activity activity)
        {
            Time = time;
            Activity = activity;
        }

        public override string ToString() => $"{Time} - {Activity}";
    }
}