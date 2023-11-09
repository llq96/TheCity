using Unity.AI.Navigation;
using UnityEngine;

namespace TheCity
{
    public class City : MonoBehaviour
    {
        [SerializeField] private Transform _citizensParent;
        [SerializeField] private NavMeshSurface _navMeshSurface;

        public Transform CitizensParent => _citizensParent;

        private void Start()
        {
            _navMeshSurface.AddData();
            _navMeshSurface.UpdateNavMesh(_navMeshSurface.navMeshData);
        }
    }
}