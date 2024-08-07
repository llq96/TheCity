using JetBrains.Annotations;
using TheCity.Core;
using UnityEngine.SceneManagement;
using Zenject;

namespace TheCity.Installers
{
    [UsedImplicitly]
    public class CityCreator
    {
        [Inject] private CityFactory CityFactory { get; }
        [Inject] private CitizensCreator CitizensCreator { get; }
        [Inject] private CompaniesCreator CompaniesCreator { get; }

        public void Create(CityData cityData)
        {
            var city = CityFactory.Create(cityData);

            city.gameObject.name = $"City {cityData.CityName}";
            city.transform.SetParent(null);
            SceneManager.MoveGameObjectToScene(city.gameObject, SceneManager.GetActiveScene());

            foreach (var companyData in cityData.CompaniesData)
            {
                var company = CompaniesCreator.Create(city, companyData);
                company.transform.parent = city.CompaniesParent;
                city.Companies.Add(company);
            }

            foreach (var citizenData in cityData.CitizensData)
            {
                var companyData = citizenData.CitizenInbornData.JobPost.CompanyData;
                var citizen = CitizensCreator.Create(city, new CitizenCreationData(citizenData, companyData));
                citizen.transform.parent = city.CitizensParent;
                city.Citizens.Add(citizen);
            }
        }
    }
}