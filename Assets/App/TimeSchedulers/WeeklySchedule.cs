using System;
using System.Collections.Generic;

namespace TheCity
{
    public class WeeklySchedule
    {
        public DaySchedule SundaySchedule { get; } = new();
        public DaySchedule MondaySchedule { get; } = new();
        public DaySchedule TuesdaySchedule { get; } = new();
        public DaySchedule WednesdaySchedule { get; } = new();
        public DaySchedule ThursdaySchedule { get; } = new();
        public DaySchedule FridaySchedule { get; } = new();
        public DaySchedule SaturdaySchedule { get; } = new();

        private readonly List<DaySchedule> _schedules;

        public WeeklySchedule()
        {
            _schedules = new List<DaySchedule>
            {
                SundaySchedule, MondaySchedule, TuesdaySchedule, WednesdaySchedule,
                ThursdaySchedule, FridaySchedule, SaturdaySchedule
            };
        }

        public DaySchedule this[DayOfWeek dayOfWeek] => _schedules[(int)dayOfWeek];

        public DaySchedule GetDaySchedule(DayOfWeek dayOfWeek) => this[dayOfWeek];
    }
}