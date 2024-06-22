using System;

namespace TheCity
{
    public readonly struct CitizenName
    {
        public string FirstName { get; }
        public string SecondName { get; }
        public string FullName { get; }

        public CitizenName(string firstName, string secondName)
        {
            if (string.IsNullOrEmpty(firstName))
                throw new ArgumentException($"Null Or Empty {nameof(firstName)}");

            if (string.IsNullOrEmpty(secondName))
                throw new ArgumentException($"Null Or Empty {nameof(secondName)}");

            FirstName = firstName;
            SecondName = secondName;

            FullName = $"{firstName} {secondName}";
        }

        public override string ToString() => FullName;
    }
}