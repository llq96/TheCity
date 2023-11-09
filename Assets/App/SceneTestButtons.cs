using UnityEngine;
using Zenject;

namespace TheCity
{
    public class SceneTestButtons : MonoBehaviour
    {
        [Inject] private CityDataGenerator CityDataGenerator { get; }
        [Inject] private CityCreator CityCreator { get; }


        [SerializeField] private GameObject _roomPrefab;

        [ContextMenu(nameof(CreateNewCity))]
        private void CreateNewCity()
        {
            var newCity = CityDataGenerator.GenerateCityData();
            CityCreator.Create(newCity);

            TestGenerateRooms();
        }

        private void TestGenerateRooms()
        {
            for (int x = -1; x <= 1; x++)
            {
                for (int z = -1; z <= 1; z++)
                {
                    var newRoom = Instantiate(_roomPrefab, transform);
                    newRoom.transform.position = new Vector3(x * 4f, 0, z * 4f);
                }
            }
        }
    }
}