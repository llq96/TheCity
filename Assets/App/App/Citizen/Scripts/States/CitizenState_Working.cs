using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace TheCity
{
    [UsedImplicitly]
    public class CitizenState_Working : CitizenState
    {
        [Inject] private Animator Animator { get; }

        public override CitizenStateEnum CitizenStateEnum => CitizenStateEnum.Working;

        private static readonly int AnimatorTrigger_Work = Animator.StringToHash("Work");

        protected override void EnableStateAction()
        {
            base.EnableStateAction();
            Debug.Log("Work Triggered");
            Animator.SetTrigger(AnimatorTrigger_Work);
        }

        public void WorkAtPoint(Vector3 workPoint)
        {
            Debug.Log("WorkAtPoint");
            Citizen.transform.position = workPoint;
        }
    }
}