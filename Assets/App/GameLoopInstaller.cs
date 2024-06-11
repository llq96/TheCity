using UnityEngine;
using Zenject;

namespace TheCity
{
    public class GameLoopInstaller : MonoInstaller
    {
        [Inject] private CityDataGenerator CityDataGenerator { get; }
        [Inject] private CityCreator CityCreator { get; }
        [Inject] private PlayerCreator PlayerCreator { get; }

        [SerializeField] private Transform _playerSpawnPoint;

        public override void InstallBindings()
        {
        }

        public override void Start()
        {
            CreateNewCity();
            CreatePlayer();
        }

        private void CreateNewCity()
        {
            var newCity = CityDataGenerator.GenerateCityData();
            CityCreator.Create(newCity);
        }

        private void CreatePlayer()
        {
            var player = PlayerCreator.Create(_playerSpawnPoint);
        }
    }
}