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
        [Inject] public CitizenAnimator CitizenAnimator { get; }

        public override CitizenStateEnum CitizenStateEnum => CitizenStateEnum.Sleeping;

        protected override void EnableStateAction()
        {
            base.EnableStateAction();
            CitizenAnimator.PlayAnimation_Sleep();
        }

        public void SleepAtPoint(Transform sleepPoint)
        {
            Citizen.transform.position = sleepPoint.position;
            Citizen.transform.rotation = sleepPoint.rotation;
        }
    }
}