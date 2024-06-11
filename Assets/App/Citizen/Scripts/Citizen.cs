using System.Linq;
using System.Text;
using UnityEngine;
using Zenject;

namespace TheCity
{
    public class Citizen : MonoBehaviour
    {
        [Inject] private CitizenData CitizenData { get; }
        [Inject] private CitizenInbornData InbornData { get; }

        [Inject] private Room HomeRoom { get; }

        [Inject] private Company Company { get; }
        [Inject] private JobPost JobPost { get; }

        [Inject] private CitizenActivityScheduler CitizenActivityScheduler { get; }

        [Inject] private CitizenMover CitizenMover { get; }

        private void Start()
        {
            Debug.Log(this);
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.Append($"I am {InbornData.Name}");
            sb.AppendLine();
            sb.Append($"I live in {HomeRoom}");
            sb.AppendLine();
            sb.Append($"I work in {Company}");
            sb.AppendLine();
            sb.Append($"I work as {JobPost.JobTitle}");
            sb.AppendLine();
            sb.Append($"From {JobPost.WorkSchedule.MondaySchedule.ScheduleItems.First().Time}"); //TODO
            sb.AppendLine();
            sb.Append($"To {JobPost.WorkSchedule.MondaySchedule.ScheduleItems.Last().Time}");
            sb.AppendLine();
            return sb.ToString();
        }
    }
}