using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace TheCity
{
    [UsedImplicitly]
    public class CitizenMover
    {
        [Inject] private NavMeshAgent NavMeshAgent { get; }

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
    }
}