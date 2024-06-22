using System;

namespace TheCity
{
    [TestsInfo("TimeOnlyTests", 100)]
    public readonly struct TimeOnly
    {
        public readonly int Hour;
        public readonly int Minute;

        public TimeOnly(int hour, int minute)
        {
            if (hour < 0 || hour >= 24)
                throw new ArgumentException("Incorrect Hour");

            if (minute < 0 || minute >= 60)
                throw new ArgumentException("Incorrect Minute");

            Hour = hour;
            Minute = minute;
        }

        public override string ToString()
        {
            return $"{Hour.ToString().PadLeft(2, '0')}:{Minute.ToString().PadLeft(2, '0')}";
        }
    }
}