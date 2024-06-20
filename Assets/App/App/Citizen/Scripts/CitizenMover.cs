using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace TheCity
{
    [UsedImplicitly]
    public class CitizenMover : ITickable
    {
        private static readonly int AnimatorProperty_Speed = Animator.StringToHash("Speed");

        [Inject] private NavMeshAgent NavMeshAgent { get; }
        [Inject] private Animator Animator { get; }

        public void MoveTo(Vector3 destination)
        {
            if (!NavMeshAgent) return;
            if (!NavMeshAgent.gameObject.activeInHierarchy) return;
            if (!NavMeshAgent.isOnNavMesh) return;
            if (!NavMeshAgent.enabled) return;

            // Debug.Log($"Set Destination {destination}");

            NavMeshAgent.SetDestination(destination);
            NavMeshAgent.isStopped = false;
        }

        public void Tick()
        {
            var velocityMagnitude = NavMeshAgent.velocity.magnitude;
            Animator.SetFloat(AnimatorProperty_Speed, velocityMagnitude);
        }
    }
}