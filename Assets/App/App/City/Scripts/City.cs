using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using Zenject;

namespace TheCity
{
    public class City : MonoBehaviour
    {
        [Inject] private CityData CityData { get; }

        [SerializeField] private Transform _citizensParent;
        [SerializeField] private Transform _addressesParent;
        [SerializeField] private Transform _companiesParent;

        [SerializeField] private NavMeshSurface _navMeshSurface;
        [SerializeField] private List<Room> _rooms;

        public Transform CitizensParent => _citizensParent;
        public Transform AddressesParent => _addressesParent;
        public Transform CompaniesParent => _companiesParent;

        public List<Room> Rooms => _rooms;

        public readonly List<Citizen> Citizens = new();
        public readonly List<Company> Companies = new();

        private void Start()
        {
            _navMeshSurface.AddData();
            _navMeshSurface.UpdateNavMesh(_navMeshSurface.navMeshData);
        }

        [Inject]
        private void Construct()
        {
            for (int i = 0; i < Rooms.Count; i++)
            {
                Rooms[i].Construct(CityData.AddressesDataList[i]);
            }
        }
    }
}