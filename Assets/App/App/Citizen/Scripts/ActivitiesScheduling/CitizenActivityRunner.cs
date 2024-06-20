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
        [Inject] private CitizenStatesSwitcher CitizenStatesSwitcher { get; }
        [Inject] private Room HomeRoom { get; }
        [Inject] private Company Company { get; }

        private Vector3 CitizenPosition => Citizen.transform.position;

        #region Destinations

        private Vector3 WorkDestination => Company.Room.transform.position;
        private float DistanceToWorkDestination => (WorkDestination - CitizenPosition).magnitude;

        private Vector3 HomeDestination => HomeRoom.transform.position;
        private float DistanceToHomeDestination => (HomeDestination - CitizenPosition).magnitude;

        #endregion

        public void TryDoActivity(Activity activity)
        {
            // Debug.Log($"{Citizen} Start Do Activity {activity}");

            if (activity is Activity_StartWork)
            {
                CitizenStatesSwitcher.SetState_Moving(WorkDestination);
            }
            
            if (activity is Activity_GoToWork)
            {
                CitizenActivityScheduler.AddActivityToHead(new Activity_GoToWork());
            }

            if (activity is Activity_Working)
            {
                CitizenStatesSwitcher.SetState_Sleeping(); //TODO
            }

            if (activity is Activity_EndWork)
            {
                CitizenActivityScheduler.AddActivityToHead(new Activity_GoToHome());
            }

            if (activity is Activity_GoToHome)
            {
                CitizenStatesSwitcher.SetState_Moving(HomeDestination);
            }

            if (activity is Activity_Sleeping)
            {
                CitizenStatesSwitcher.SetState_Sleeping();
            }

            if (activity is Activity_FillSchedule)
            {
                CitizenActivityScheduler.FillScheduler();
            }
        }


        public bool TryEndActivity(Activity activity)
        {
            if (activity is Activity_GoToWork)
            {
                if (DistanceToWorkDestination <= 1f)
                {
                    CitizenActivityScheduler.AddActivityToHead(new Activity_Working());
                    return true;
                }

                return false;
            }

            if (activity is Activity_GoToHome)
            {
                if (DistanceToHomeDestination <= 1f)
                {
                    CitizenActivityScheduler.AddActivityToHead(new Activity_Sleeping());
                    return true;
                }

                return false;
            }

            return true;
        }
    }
}