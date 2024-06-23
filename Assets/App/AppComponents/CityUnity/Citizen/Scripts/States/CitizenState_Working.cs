using JetBrains.Annotations;
using TheCity.Core;
using UnityEngine;
using Zenject;

namespace TheCity.Unity
{
    [UsedImplicitly]
    public class CitizenState_Working : CitizenState
    {
        [Inject] public Citizen Citizen { get; }
        [Inject] public CitizenAnimator CitizenAnimator { get; }

        public override CitizenStateEnum CitizenStateEnum => CitizenStateEnum.Working;

        protected override void EnableStateAction()
        {
            base.EnableStateAction();
            CitizenAnimator.PlayAnimation_Work();
        }

        public void WorkAtPoint(Transform workPoint)
        {
            Citizen.transform.position = workPoint.position;
            Citizen.transform.rotation = workPoint.rotation;
        }
    }
}