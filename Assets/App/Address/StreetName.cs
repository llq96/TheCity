namespace TheCity
{
    public readonly struct StreetName
    {
        public string Name { get; }
        public string FullName { get; }

        public StreetName(string name)
        {
            Name = name;
            FullName = $"{name} St.";
        }

        public override string ToString() => FullName;
    }
}