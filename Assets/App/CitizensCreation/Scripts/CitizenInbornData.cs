namespace TheCity
{
    public class CitizenInbornData
    {
        public string FirstName { get; }
        public string SecondName { get; }

        public CitizenInbornData(string firstName, string secondName)
        {
            FirstName = firstName;
            SecondName = secondName;
        }
    }
}