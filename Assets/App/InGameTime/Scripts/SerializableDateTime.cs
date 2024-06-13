using System;
using UnityEngine;

namespace TheCity
{
    [Serializable]
    public class SerializableDateTime
    {
        [SerializeField] [Range(1970, 2100)] private int _year = 2000;
        [SerializeField] [Range(1, 12)] private int _month = 1;
        [SerializeField] [Range(1, 31)] private int _day = 1;
        [SerializeField] [Range(0, 23)] private int _hour;
        [SerializeField] [Range(0, 59)] private int _minute;
        [SerializeField] [Range(0, 59)] private int _second;
        [SerializeField] [Range(0, 999)] private int _millisecond;

        public DateTime GetDateTime()
        {
            return new DateTime(_year, _month, _day, _hour, _minute, _second, _millisecond);
        }

        public void SetDateTime(DateTime dateTime)
        {
            _year = dateTime.Year;
            _month = dateTime.Month;
            _day = dateTime.Day;
            _hour = dateTime.Hour;
            _minute = dateTime.Minute;
            _second = dateTime.Second;
            _millisecond = dateTime.Millisecond;
        }

        #region Private Serializable Field Names

        public const string Name_Of_Year = nameof(_year);
        public const string Name_Of_Month = nameof(_month);
        public const string Name_Of_Day = nameof(_day);
        public const string Name_Of_Hour = nameof(_hour);
        public const string Name_Of_Minute = nameof(_minute);
        public const string Name_Of_Second = nameof(_second);
        public const string Name_Of_Millisecond = nameof(_millisecond);

        #endregion
    }
}