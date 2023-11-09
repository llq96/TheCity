using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace TheCity
{
    [UsedImplicitly]
    public class CityCreator
    {
        [Inject] private CityFactory CityFactory { get; }
        [Inject] private CitizensCreator CitizensCreator { get; }

        public void Create(CityData cityData)
        {
            var city = CityFactory.Create(cityData);

            city.gameObject.name = $"City {cityData.CityName}";
            city.transform.SetParent(null);
            SceneManager.MoveGameObjectToScene(city.gameObject, SceneManager.GetActiveScene());


            foreach (var citizenData in cityData.CitizensDataList)
            {
                var citizen = CitizensCreator.Create(new CitizenCreationData(citizenData));
                citizen.transform.parent = city.CitizensParent;
            }

            foreach (var companyData in cityData.CompaniesDataList)
            {
                Debug.Log(companyData.CompanyName.FullName);
            }
        }
    }
}