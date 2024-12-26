using System;
using System.Linq;
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
        [Inject] private Citizen Citizen { get; }
        [Inject] private ThinkGenerator ThinkGenerator { get; }
        [Inject] private GameTime GameTime { get; }
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
                Test("Я собираюсь спать");
                State_Sleeping.SleepAtPoint(sleepPoint);
            }
        }

        public void SetState_Working(Transform workPoint)
        {
            if (SetState(State_Working))
            {
                Test("Я собираюсь работать");
                State_Working.WorkAtPoint(workPoint);
            }
        }

        private bool isNeedGenerateThink = true;

        private async void Test(string additionalContext)
        {
            if (!isNeedGenerateThink) return;
            isNeedGenerateThink = false;

            var context = Citizen.GetFormattedInfo();
            context += $"\n Сейчас {GameTime.GameDateTime.Value.Date.ToString("dd/MM/yyyy HH:mm")}";
            context += $"\n {additionalContext}";
            var think = await ThinkGenerator.GenerateThink(context);
            Debug.Log(think);
        }
    }
}