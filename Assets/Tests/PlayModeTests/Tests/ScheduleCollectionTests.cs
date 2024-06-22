using TheCity.Unity;
using NUnit.Framework;
using System;
using System.Linq;
using Zenject;

namespace TheCity.Tests
{
    [TestFixture]
    public class ScheduleCollectionTests : ZenjectEmptyContextsUnitTestFixture //AI Generated.
    {
        [Inject] private ScheduleCollection ScheduleCollection { get; }

        private void CorrectSetUp()
        {
            PreInstall();

            CorrectThings.BindGameTime(Container);
            Container.Bind<ScheduleCollection>().AsSingle().NonLazy();

            PostInstall();
        }

        [Test]
        public void AddToHead_WhenCalled_AddsActivityToHeadOfSchedule()
        {
            CorrectSetUp();
            var initialCount = ScheduleCollection.Count();
            var activity = CorrectThings.GetActivity();

            ScheduleCollection.AddToHead(activity);

            Assert.AreEqual(initialCount + 1, ScheduleCollection.Count());
            Assert.AreEqual(activity, ScheduleCollection.First().Activity);
        }

        [Test]
        public void AddToTail_WhenCalled_AddsActivityToTailOfSchedule()
        {
            CorrectSetUp();
            var initialCount = ScheduleCollection.Count();
            var activity = CorrectThings.GetActivity();

            ScheduleCollection.AddToTail(activity);

            Assert.AreEqual(initialCount + 1, ScheduleCollection.Count());
            Assert.AreEqual(activity, ScheduleCollection.Last().Activity);
        }

        [Test]
        public void Remove_WhenCalled_RemovesActivityFromSchedule()
        {
            CorrectSetUp();
            var activityToRemove = CorrectThings.GetScheduleActivity();
            ScheduleCollection.Add(activityToRemove);
            var initialCount = ScheduleCollection.Count();

            ScheduleCollection.Remove(activityToRemove);

            Assert.AreEqual(initialCount - 1, ScheduleCollection.Count());
            Assert.IsFalse(ScheduleCollection.Contains(activityToRemove));
        }

        [Test]
        public void TryDequeue_WithNonEmptySchedule_ReturnsTrueAndRemovesFirstActivity()
        {
            CorrectSetUp();
            var activity1 = CorrectThings.GetActivity();
            var activity2 = CorrectThings.GetActivity();
            ScheduleCollection.Add(new ScheduleActivity(DateTime.Now, activity1));
            ScheduleCollection.Add(new ScheduleActivity(DateTime.Now.AddHours(1), activity2));

            bool result = ScheduleCollection.TryDequeue(out var dequeuedActivity);

            Assert.IsTrue(result);
            Assert.AreEqual(activity1, dequeuedActivity.Activity);
            Assert.IsFalse(ScheduleCollection.Contains(dequeuedActivity));
        }

        [Test]
        public void TryDequeue_WithEmptySchedule_ReturnsFalseAndNoChanges()
        {
            CorrectSetUp();
            bool result = ScheduleCollection.TryDequeue(out var dequeuedActivity);

            Assert.IsFalse(result);
            Assert.IsNull(dequeuedActivity);
        }
    }
}