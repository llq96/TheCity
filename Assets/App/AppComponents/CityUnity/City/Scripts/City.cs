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
        [Inject] private List<LivingRoom> LivingRooms { get; }
        [Inject] private List<WorkRoom> WorkRooms { get; }

        [SerializeField] private Transform _citizensParent;
        [SerializeField] private Transform _housesParent;
        [SerializeField] private Transform _companiesParent;

        [SerializeField] private NavMeshSurface _navMeshSurface;

        [SerializeField] private List<Transform> _housesSpawnPoints;


        public Transform CitizensParent => _citizensParent;
        public Transform HousesParent => _housesParent;
        public Transform CompaniesParent => _companiesParent;
        public List<Transform> HousesSpawnPoints => _housesSpawnPoints;


        public readonly List<Citizen> Citizens = new(); //TODO Inject
        public readonly List<Company> Companies = new(); //TODO Inject

        private void Start()
        {
            _navMeshSurface.AddData();
            _navMeshSurface.UpdateNavMesh(_navMeshSurface.navMeshData);
        }

        public LivingRoom GetLivingRoom(LivingAddressData livingAddressData)
        {
            return LivingRooms.First(x => x.AddressData == livingAddressData);
        }

        public WorkRoom GetWorkRoom(WorkAddressData workAddressData)
        {
            return WorkRooms.First(x => x.AddressData == workAddressData);
        }

        public Company GetCompany(CompanyData companyData)
        {
            return Companies.First(x => x.CompanyData == companyData);
        }
    }
}