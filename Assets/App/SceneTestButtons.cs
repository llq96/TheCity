using UnityEngine;
using Zenject;

namespace TheCity
{
    public class SceneTestButtons : MonoBehaviour
    {
        [Inject] private CityDataGenerator CityDataGenerator { get; }
        [Inject] private CityCreator CityCreator { get; }

        [SerializeField] private bool _isTestOnStart = true;


        private void Start()
        {
            if (_isTestOnStart)
            {
                CreateNewCity();
            }
        }

        [ContextMenu(nameof(CreateNewCity))]
        private void CreateNewCity()
        {
            var newCity = CityDataGenerator.GenerateCityData();
            CityCreator.Create(newCity);
        }
    }
}