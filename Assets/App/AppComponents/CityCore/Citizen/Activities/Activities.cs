namespace TheCity.Core
{
    public class Activity
    {
        public override string ToString() => GetType().Name;
    }

    public class Activity_GoToHome : Activity
    {
    }

    public class Activity_Sleeping : Activity
    {
    }

    public class Activity_FillSchedule : Activity
    {
    }
}