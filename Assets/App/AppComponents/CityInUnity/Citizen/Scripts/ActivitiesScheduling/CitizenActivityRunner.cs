using System;
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
        [Inject] private LivingRoom HomeRoom { get; }
        [Inject] private Company Company { get; }

        private Vector3 CitizenPosition => Citizen.transform.position;

        #region Destinations

        private Vector3 WorkDestination => Company.Room.JobPostsPlaces[Citizen.InbornData.JobPostIndex].position;
        private float DistanceToWorkDestination => (WorkDestination - CitizenPosition).magnitude;

        private Vector3 HomeDestination => HomeRoom.transform.position;
        private float DistanceToHomeDestination => (HomeDestination - CitizenPosition).magnitude;

        #endregion

        public void TryDoActivity(Activity activity)
        {
            // Debug.Log($"{Citizen} Start Do Activity {activity}");

            if (activity is WorkActivity workActivity)
            {
                TryDoActivity(workActivity);
                return;
            }

            switch (activity)
            {
                case Activity_FillSchedule activityFillSchedule:
                    CitizenActivityScheduler.FillScheduler();
                    break;
                case Activity_GoToHome activityGoToHome:
                    CitizenStatesSwitcher.SetState_Moving(HomeDestination);
                    break;
                case Activity_Sleeping activitySleeping:
                    CitizenStatesSwitcher.SetState_Sleeping();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(activity.GetType().ToString());
            }
        }

        public void TryDoActivity(WorkActivity activity)
        {
            switch (activity)
            {
                case Activity_EndWork activityEndWork:
                    CitizenActivityScheduler.AddActivityToHead(new Activity_GoToHome());
                    break;
                case Activity_GoToWork activityGoToWork:
                    CitizenStatesSwitcher.SetState_Moving(WorkDestination);
                    break;
                case Activity_StartWork activityStartWork:
                    CitizenActivityScheduler.AddActivityToHead(new Activity_GoToWork());
                    break;
                case Activity_Working activityWorking:
                    CitizenStatesSwitcher.SetState_Working(WorkDestination);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(activity.GetType().ToString());
            }
        }


        public bool TryEndActivity(Activity activity)
        {
            switch (activity)
            {
                case Activity_GoToHome activityGoToHome:
                    if (DistanceToHomeDestination <= 1f)
                    {
                        CitizenActivityScheduler.AddActivityToHead(new Activity_Sleeping());
                        return true;
                    }

                    return false;

                case Activity_GoToWork activityGoToWork:
                    if (DistanceToWorkDestination <= 1f)
                    {
                        CitizenActivityScheduler.AddActivityToHead(new Activity_Working());
                        return true;
                    }

                    return false;

                default:
                    return true;
            }
        }
    }
}