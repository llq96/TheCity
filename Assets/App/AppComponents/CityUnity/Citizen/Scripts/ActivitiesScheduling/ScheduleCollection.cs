using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using TheCity.Core;
using Zenject;

namespace TheCity.Unity
{
    [UsedImplicitly]
    public class ScheduleCollection : IEnumerable<ScheduleActivity>
    {
        [Inject] private GameTime GameTime { get; }

        private List<ScheduleActivity> _list = new();

        private bool _isSorted;

        public void AddToHead(Activity activity)
        {
            Add(new ScheduleActivity(GameTime.GameDateTime, activity));
        }

        public void AddToTail(Activity activity)
        {
            var lastActivity = _list.LastOrDefault();
            if (lastActivity != null)
            {
                var dateTime = lastActivity.DateTime.AddMinutes(1);
                var scheduleActivity = new ScheduleActivity(dateTime, activity);
                _list.Add(scheduleActivity);
            }
            else
            {
                AddToHead(activity);
            }
        }

        public void Add(ScheduleActivity scheduleActivity)
        {
            _list.Add(scheduleActivity);
            _isSorted = false;
        }

        public void Remove(ScheduleActivity scheduleActivity)
        {
            _list.Remove(scheduleActivity);
        }


        private void Sort()
        {
            _list = _list.OrderBy(x => x.DateTime).ToList();
            _isSorted = true;
        }

        public bool TryDequeue(out ScheduleActivity item)
        {
            if (_list.Count == 0)
            {
                item = null;
                return false;
            }

            item = _list.First();
            _list.RemoveAt(0);

            return true;
        }

        public IEnumerator<ScheduleActivity> GetEnumerator()
        {
            if (!_isSorted)
            {
                Sort();
            }

            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}