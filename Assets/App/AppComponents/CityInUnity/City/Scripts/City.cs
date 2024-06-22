using System;
using System.Collections.Generic;
using System.Linq;
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
        [SerializeField] private List<LivingRoom> _livingRooms;
        [SerializeField] private List<WorkRoom> _workRooms;

        public Transform CitizensParent => _citizensParent;
        public Transform AddressesParent => _addressesParent;
        public Transform CompaniesParent => _companiesParent;

        public readonly List<Citizen> Citizens = new();
        public readonly List<Company> Companies = new();

        private void Start()
        {
            _navMeshSurface.AddData();
            _navMeshSurface.UpdateNavMesh(_navMeshSurface.navMeshData);
        }

        [Inject]
        private void Construct() //TODO Чем быстрее сделаю генерацию города, тем меньше проблем со связыванием будет.
        {
            var livingRooms = new List<LivingRoom>(_livingRooms);
            var workRooms = new List<WorkRoom>(_workRooms);

            for (int i = 0; i < CityData.AddressesDataList.Count; i++)
            {
                var addressData = CityData.AddressesDataList[i];
                switch (addressData.AddressType)
                {
                    case AddressType.Living:
                        var livingRoom = livingRooms.First();
                        livingRoom.Construct(addressData);
                        livingRooms.Remove(livingRoom);
                        break;
                    case AddressType.Working:
                        var workRoom = workRooms.First();
                        workRoom.Construct(addressData);
                        workRooms.Remove(workRoom);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
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