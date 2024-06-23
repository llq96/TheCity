using JetBrains.Annotations;
using TheCity.Core;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace TheCity.Unity
{
    [UsedImplicitly]
    public class CitizenState_Moving : CitizenState, ITickable
    {
        [Inject] private NavMeshAgent NavMeshAgent { get; }
        [Inject] private CitizenAnimator CitizenAnimator { get; }

        public override CitizenStateEnum CitizenStateEnum => CitizenStateEnum.Moving;

        protected override void EnableStateAction()
        {
            base.EnableStateAction();
            CitizenAnimator.PlayAnimation_Move();
            NavMeshAgent.enabled = true;
        }

        protected override void DisableStateAction()
        {
            base.DisableStateAction();
            NavMeshAgent.enabled = false;
            CitizenAnimator.SetMoveSpeed(0);
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
            CitizenAnimator.SetMoveSpeed(velocityMagnitude);
        }
    }
}