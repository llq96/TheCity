using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace TheCity
{
    [UsedImplicitly]
    public class CitizenState_Moving : CitizenState, ITickable
    {
        [Inject] private NavMeshAgent NavMeshAgent { get; }
        [Inject] private Animator Animator { get; }

        private static readonly int AnimatorProperty_Speed = Animator.StringToHash("Speed");
        private static readonly int AnimatorTrigger_Move = Animator.StringToHash("Move");

        public override CitizenStateEnum CitizenStateEnum => CitizenStateEnum.Moving;

        protected override void EnableStateAction()
        {
            base.EnableStateAction();
            Animator.SetTrigger(AnimatorTrigger_Move);
            NavMeshAgent.enabled = true;
        }

        protected override void DisableStateAction()
        {
            base.DisableStateAction();
            NavMeshAgent.enabled = false;
            Animator.SetFloat(AnimatorProperty_Speed, 0f);
        }

        public void MoveTo(Vector3 destination)
        {
            NavMeshAgent.SetDestination(destination);
            NavMeshAgent.isStopped = false;
        }

        public void Tick()
        {
            if (!IsActive) return;

            var velocityMagnitude = NavMeshAgent.velocity.magnitude;
            Animator.SetFloat(AnimatorProperty_Speed, velocityMagnitude);
        }
    }
}