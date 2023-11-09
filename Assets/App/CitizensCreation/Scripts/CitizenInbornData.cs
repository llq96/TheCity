namespace TheCity
{
    public class CitizenInbornData
    {
        public CitizenName Name { get; }

        public CitizenInbornData(CitizenName name)
        {
            Name = name;
        }
    }

    public struct CitizenName
    {
        public string FirstName { get; }
        public string SecondName { get; }
        public string FullName { get; }

        public CitizenName(string firstName, string secondName)
        {
            FirstName = firstName;
            SecondName = secondName;

            FullName = $"{firstName} {secondName}";
        }
    }
}