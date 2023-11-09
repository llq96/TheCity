using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace TheCity
{
    public class Citizen : MonoBehaviour
    {
        [Inject] private CitizenInbornData InbornData { get; }
        [Inject] private NavMeshAgent NavMeshAgent { get; }

        private void Start()
        {
            Debug.Log($"{InbornData.FirstName} {InbornData.SecondName}");

            TryMove().Forget();
        }

        private async UniTask TryMove()
        {
            while (true)
            {
                await UniTask.Yield();

                if (!NavMeshAgent) return;
                if (!NavMeshAgent.gameObject.activeInHierarchy) continue;
                if (!NavMeshAgent.isOnNavMesh) continue;
                if (!NavMeshAgent.enabled) continue;

                var destination = new Vector3(Random.Range(-10f, 10f), 0f, Random.Range(-10f, 10f));
                NavMeshAgent.SetDestination(destination);
                NavMeshAgent.isStopped = false;
                Debug.Log($"Set Destination {destination}");
                return;
            }
        }
    }
}