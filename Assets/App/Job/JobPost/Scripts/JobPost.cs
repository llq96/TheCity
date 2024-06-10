namespace TheCity
{
    public class JobPost
    {
        public JobTitle JobTitle { get; }

        public JobPost(JobTitle jobTitle)
        {
            JobTitle = jobTitle;
        }
    }
}