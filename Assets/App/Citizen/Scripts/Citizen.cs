using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace TheCity
{
    public class Citizen : MonoBehaviour
    {
        [Inject] private CitizenInbornData InbornData { get; }
        [Inject] private CitizenData CitizenData { get; }
        [Inject] private NavMeshAgent NavMeshAgent { get; }
        [Inject] private Room HomeRoom { get; }
        [Inject] private Company Company { get; }
        [Inject] private JobPost JobPost { get; }

        private void Start()
        {
            Debug.Log($"I live in {HomeRoom}");
            Debug.Log($"I work in {Company}");
            Debug.Log($"I work as {JobPost.JobTitle}");
            var destinations = new List<Vector3>()
            {
                HomeRoom.transform.position,
                Company.Room.transform.position
            };
            TestTryMove(destinations).Forget();
        }

        private async UniTask TestTryMove(List<Vector3> destinations)
        {
            while (true)
            {
                foreach (var destination in destinations)
                {
                    while (true)
                    {
                        await UniTask.Yield();

                        if (!NavMeshAgent) return;
                        if (!NavMeshAgent.gameObject.activeInHierarchy) continue;
                        if (!NavMeshAgent.isOnNavMesh) continue;
                        if (!NavMeshAgent.enabled) continue;

                        NavMeshAgent.SetDestination(destination);
                        NavMeshAgent.isStopped = false;
                        // Debug.Log($"Set Destination {destination}");
                        break;
                    }

                    await UniTask.Delay(7 * 1000);
                }
            }
        }
    }
}