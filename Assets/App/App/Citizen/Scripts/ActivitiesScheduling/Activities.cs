namespace TheCity
{
    [TestsInfo("ActivityTests", 100)]
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

    public class Activity_GoToHome : Activity
    {
    }

    public class Activity_GoToWork : Activity
    {
    }

    public class Activity_FillSchedule : Activity
    {
    }

    public class Activity_Sleeping : Activity
    {
    }

    public class Activity_Working : Activity
    {
    }

}