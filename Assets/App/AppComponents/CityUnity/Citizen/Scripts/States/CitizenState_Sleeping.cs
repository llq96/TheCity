using JetBrains.Annotations;
using TheCity.Core;
using UnityEngine;
using Zenject;

namespace TheCity.Unity
{
    [UsedImplicitly]
    public class CitizenState_Sleeping : CitizenState
    {
        [Inject] public Citizen Citizen { get; }
        [Inject] private Animator Animator { get; }

        private static readonly int AnimatorTrigger_Sleep = Animator.StringToHash("Sleep");

        public override CitizenStateEnum CitizenStateEnum => CitizenStateEnum.Sleeping;

        protected override void EnableStateAction()
        {
            base.EnableStateAction();
            Animator.SetTrigger(AnimatorTrigger_Sleep);
        }

        public void SleepAtPoint(Transform sleepPoint)
        {
            Citizen.transform.position = sleepPoint.position;
            Citizen.transform.rotation = sleepPoint.rotation;
        }
    }
}