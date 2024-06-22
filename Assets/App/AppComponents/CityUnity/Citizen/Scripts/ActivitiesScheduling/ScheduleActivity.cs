using System;
using TheCity.Core;

namespace TheCity.Unity
{
    public class ScheduleActivity
    {
        public DateTime DateTime { get; }
        public Activity Activity { get; }

        public ScheduleActivity(DateTime dateTime, Activity activity)
        {
            DateTime = dateTime;
            Activity = activity;
        }

        public override string ToString()
        {
            return $"{DateTime} - {Activity}";
        }
    }
}