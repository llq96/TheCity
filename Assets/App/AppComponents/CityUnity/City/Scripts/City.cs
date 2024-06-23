using System.Collections.Generic;
using System.Linq;
using TheCity.Core;
using Unity.AI.Navigation;
using UnityEngine;
using Zenject;

namespace TheCity.Unity
{
    public class City : MonoBehaviour
    {
        [Inject] private CityData CityData { get; }

        [SerializeField] private Transform _citizensParent;
        [SerializeField] private Transform _addressesParent;
        [SerializeField] private Transform _companiesParent;

        [SerializeField] private NavMeshSurface _navMeshSurface;
        [SerializeField] private List<LivingRoom> _livingRooms;
        [SerializeField] private List<WorkRoom> _workRooms;

        public Transform CitizensParent => _citizensParent;
        public Transform AddressesParent => _addressesParent;
        public Transform CompaniesParent => _companiesParent;

        public List<LivingRoom> LivingRooms => _livingRooms;
        public List<WorkRoom> WorkRooms => _workRooms;

        public readonly List<Citizen> Citizens = new();
        public readonly List<Company> Companies = new();

        private void Start()
        {
            _navMeshSurface.AddData();
            _navMeshSurface.UpdateNavMesh(_navMeshSurface.navMeshData);
        }

        public LivingRoom GetLivingRoom(int addressIndex)
        {
            return _livingRooms.First(x => x.AddressData.GlobalRoomIndex == addressIndex);
        }

        public WorkRoom GetWorkRoom(int addressIndex)
        {
            return _workRooms.First(x => x.AddressData.GlobalRoomIndex == addressIndex);
        }
    }
}