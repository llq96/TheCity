namespace TheCity
{
    public class Activity
    {
        public override string ToString() => GetType().Name;
    }

    public class Activity_StartWork : Activity
    {
    }

    public class Activity_EndWork : Activity
    {
    }

    public class Activity_FillSchedule : Activity
    {
    }
}