using System.Linq;
using System.Text;
using TheCity.Core;
using UnityEngine;

namespace TheCity.Unity
{
    public static class BeautifulLogExtensions
    {
        public static void PrintFormattedInfo(this Citizen citizen)
        {
            Debug.Log(citizen.GetFormattedInfo());
        }

        public static string GetFormattedInfo(this Citizen citizen)
        {
            StringBuilder sb = new();
            sb.AppendLine($"I am {citizen.InbornData.Name}");
            sb.AppendLine($"I live in {citizen.HomeRoom}");
            sb.AppendLine($"I work in {citizen.Company}");
            sb.AppendLine($"I work as {citizen.JobPost.JobTitle}");
            sb.AppendLine("Work Schedule:");
            sb.AppendWithIndent($"{citizen.JobPost.WorkSchedule}", 1);

            return sb.ToString();
        }

        public static void PrintFormattedInfo(this CitizenActivityScheduler scheduler)
        {
            StringBuilder sb = new();
            sb.AppendLine($"{scheduler.Citizen} Activity Schedule:");
            sb.AppendLine($"Current Activity : {scheduler.CurrentActivity}");

            int dateIndent = 1;
            int activityIndent = 2;

            var groupByDate = scheduler.ReadOnlyScheduleActivities.GroupBy(x => x.DateTime.Date);
            foreach (var group in groupByDate)
            {
                sb.AppendLineWithIndent($"Date {group.Key.ToShortDateString()}:", dateIndent);
                foreach (var scheduleActivity in group)
                {
                    var log = $"{scheduleActivity.DateTime.ToShortTimeString()} - {scheduleActivity.Activity}";
                    sb.AppendLineWithIndent(log, activityIndent);
                }

                sb.AppendLine();
            }

            Debug.Log(sb.ToString());
        }
    }
}