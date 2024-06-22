using System.Collections.Generic;
using System.Text;


namespace TheCity.Core
{
    public class DaySchedule
    {
        public readonly List<DayScheduleItem> ScheduleItems = new();

        public override string ToString()
        {
            StringBuilder sb = new();
            ScheduleItems.ForEach(x => sb.AppendLine(x));
            return sb.ToString();
        }
    }
}