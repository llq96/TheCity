namespace TheCity
{
    public readonly struct TimeOnly
    {
        public readonly int Hour;
        public readonly int Minute;

        public TimeOnly(int hour, int minute)
        {
            Hour = hour;
            Minute = minute;
        }

        public override string ToString()
        {
            return $"{Hour.ToString().PadLeft(2, '0')}:{Minute.ToString().PadLeft(2, '0')}";
        }
    }
}