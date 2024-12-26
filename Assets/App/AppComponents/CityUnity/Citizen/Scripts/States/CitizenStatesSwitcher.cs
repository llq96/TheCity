using JetBrains.Annotations;
using TheCity.AI;
using TheCity.Core;
using UnityEngine;
using Zenject;

namespace TheCity.Unity
{
    [UsedImplicitly]
    public class CitizenStatesSwitcher : BaseCitizenStatesSwitcher, IInitializable
    {
        [Inject] private CitizenThinker CitizenThinker { get; }
        [Inject] protected CitizenState_Moving State_Moving { get; }
        [Inject] protected CitizenState_Sleeping State_Sleeping { get; }
        [Inject] protected CitizenState_Working State_Working { get; }

        public void Initialize()
        {
            States.Add(State_Moving);
            States.Add(State_Sleeping);
            States.Add(State_Working);
        }

        public void SetState_Moving(Vector3 destination)
        {
            if (SetState(State_Moving))
            {
                State_Moving.MoveTo(destination);
            }
        }

        public void SetState_Sleeping(Transform sleepPoint)
        {
            if (SetState(State_Sleeping))
            {
                CitizenThinker.ThinkAboutIt("Я собираюсь спать");
                State_Sleeping.SleepAtPoint(sleepPoint);
            }
        }

        public void SetState_Working(Transform workPoint)
        {
            if (SetState(State_Working))
            {
                CitizenThinker.ThinkAboutIt("Я собираюсь работать");
                State_Working.WorkAtPoint(workPoint);
            }
        }
    }
}