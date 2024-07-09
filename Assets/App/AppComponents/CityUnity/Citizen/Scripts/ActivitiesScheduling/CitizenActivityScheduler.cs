using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using TheCity.Core;
using Zenject;

namespace TheCity.Unity
{
    [UsedImplicitly]
    public class CitizenActivityScheduler : ITickable, Zenject.IInitializable
    {
        [Inject] public Citizen Citizen { get; }
        [Inject] private JobPost JobPost { get; }
        [Inject] private GameTime GameTime { get; }
        [Inject] private CitizenActivityRunner CitizenActivityRunner { get; }
        [Inject] private ScheduleCollection ScheduleActivities { get; }

        public IList<ScheduleActivity> ReadOnlyScheduleActivities => ScheduleActivities.ToList().AsReadOnly();

        private ScheduleActivity _currentActivity;

        public ScheduleActivity CurrentActivity => _currentActivity;

        public void Initialize()
        {
            FillScheduler();

            // this.PrintFormattedInfo();
        }

        public void FillScheduler()
        {
            AddActivityToHead(new Activity_GoToHome());
            FillWithWorkSchedule();
            AddActivityToTail(new Activity_FillSchedule());
        }

        public void AddActivityToHead(Activity activity)
        {
            ScheduleActivities.AddToHead(activity);
        }

        public void AddActivityToTail(Activity activity)
        {
            ScheduleActivities.AddToTail(activity);
        }

        private void FillWithWorkSchedule()
        {
            var workSchedule = JobPost.WorkSchedule;

            for (int i = 0; i < 7; i++)
            {
                var gameTime = GameTime.GameDateTime.Value.AddDays(i);
                var dayOfWeek = gameTime.DayOfWeek;
                var workDaySchedule = workSchedule[dayOfWeek];
                foreach (var scheduleItem in workDaySchedule.ScheduleItems)
                {
                    var activity = scheduleItem.Activity;
                    var time = scheduleItem.Time;
                    var dateTime = new DateTime(gameTime.Year, gameTime.Month, gameTime.Day, time.Hour, time.Minute, 0);

                    if (dateTime < GameTime.GameDateTime) continue;

                    var scheduleActivity = new ScheduleActivity(dateTime, activity);
                    ScheduleActivities.Add(scheduleActivity);

                    // Debug.Log($"Add Activity {activity}, date: {dateTime.ToString()}");
                }
            }
        }

        public void Tick()
        {
            TryEndCurrentActivity();
            if (_currentActivity == null)
            {
                TryDoNearestActivity();
            }
        }

        private void TryEndCurrentActivity()
        {
            if (_currentActivity != null)
            {
                if (CitizenActivityRunner.TryEndActivity(_currentActivity.Activity))
                {
                    _currentActivity = null;
                }
            }
        }

        private void TryDoNearestActivity()
        {
            var _nearestActivity = ScheduleActivities.FirstOrDefault();

            if (_nearestActivity == null) return;

            if (_nearestActivity.DateTime <= GameTime.GameDateTime)
            {
                _currentActivity = _nearestActivity;
                CitizenActivityRunner.TryDoActivity(_nearestActivity.Activity);
                ScheduleActivities.Remove(_nearestActivity);
            }
        }
    }
}