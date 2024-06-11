using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using TheCity.InGameTime;
using Unity.VisualScripting;
using Zenject;

namespace TheCity
{
    [UsedImplicitly]
    public class CitizenActivityScheduler : ITickable, Zenject.IInitializable
    {
        [Inject] public Citizen Citizen { get; }
        [Inject] private JobPost JobPost { get; }
        [Inject] private GameTime GameTime { get; }
        [Inject] private CitizenActivityRunner CitizenActivityRunner { get; }

        public IList<ScheduleActivity> ScheduleActivities => _scheduleActivities.AsReadOnlyList();

        //TODO Очередь не нравится, хочется Insert или сортировку при добавлении.
        private readonly Queue<ScheduleActivity> _scheduleActivities = new();
        private ScheduleActivity _nearestActivity;
        private ScheduleActivity _lastActivity;

        public void Initialize()
        {
            FillScheduler();
        }

        public void FillScheduler()
        {
            FillWithWorkSchedule();
            AddFillScheduleActivity();

            this.PrintFormattedInfo();
        }

        private void FillWithWorkSchedule()
        {
            var workSchedule = JobPost.WorkSchedule;

            for (int i = 0; i < 7; i++)
            {
                var gameTime = GameTime.GameDateTime.AddDays(i);
                var dayOfWeek = gameTime.DayOfWeek;
                var workDaySchedule = workSchedule[dayOfWeek];
                foreach (var scheduleItem in workDaySchedule.ScheduleItems)
                {
                    var activity = scheduleItem.Activity;
                    var time = scheduleItem.Time;
                    var dateTime = new DateTime(gameTime.Year, gameTime.Month, gameTime.Day, time.Hour, time.Minute, 0);
                    var scheduleActivity = new ScheduleActivity(dateTime, activity);
                    _scheduleActivities.Enqueue(scheduleActivity);

                    // Debug.Log($"Add Activity {activity}, date: {dateTime.ToString()}");
                }
            }
        }

        private void AddFillScheduleActivity()
        {
            var lastActivity = _scheduleActivities.Last();
            var dateTime = lastActivity.DateTime.AddMinutes(1);
            var activity = new Activity_FillSchedule();
            var scheduleActivity = new ScheduleActivity(dateTime, activity);
            _scheduleActivities.Enqueue(scheduleActivity);
        }

        public void Tick()
        {
            if (_nearestActivity == null)
            {
                _scheduleActivities.TryDequeue(out _nearestActivity);
            }

            if (_nearestActivity == null) return;

            if (_nearestActivity.DateTime < GameTime.GameDateTime)
            {
                DoNearestActivity();
            }
        }

        private void DoNearestActivity()
        {
            CitizenActivityRunner.DoActivity(_nearestActivity.Activity);
            _lastActivity = _nearestActivity;
            _nearestActivity = null;
        }
    }
}