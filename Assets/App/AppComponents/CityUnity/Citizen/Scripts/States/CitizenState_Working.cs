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
        [Inject] private Animator Animator { get; }

        public override CitizenStateEnum CitizenStateEnum => CitizenStateEnum.Working;

        private static readonly int AnimatorTrigger_Work = Animator.StringToHash("Work");

        protected override void EnableStateAction()
        {
            base.EnableStateAction();
            Animator.SetTrigger(AnimatorTrigger_Work);
        }

        public void WorkAtPoint(Vector3 workPoint)
        {
            Citizen.transform.position = workPoint;
        }
    }
}