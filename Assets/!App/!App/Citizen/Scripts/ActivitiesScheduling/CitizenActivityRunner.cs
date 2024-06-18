using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace TheCity
{
    [UsedImplicitly]
    public class CitizenActivityRunner
    {
        [Inject] public Citizen Citizen { get; }
        [Inject] private CitizenActivityScheduler CitizenActivityScheduler { get; }
        [Inject] private CitizenMover CitizenMover { get; }
        [Inject] private Room HomeRoom { get; }
        [Inject] private Company Company { get; }

        public void DoActivity(Activity activity)
        {
            // Debug.Log($"{Citizen} Start Do Activity {activity}");
            if (activity is Activity_StartWork)
            {
                CitizenMover.MoveTo(Company.Room.transform.position);
            }

            if (activity is Activity_EndWork)
            {
                // CitizenMover.MoveTo(HomeRoom.transform.position);
                CitizenActivityScheduler.AddActivityToHead(new Activity_GoToHome());
            }

            if (activity is Activity_GoToHome)
            {
                CitizenMover.MoveTo(HomeRoom.transform.position);
            }

            if (activity is Activity_FillSchedule)
            {
                CitizenActivityScheduler.FillScheduler();
            }
        }
    }
}