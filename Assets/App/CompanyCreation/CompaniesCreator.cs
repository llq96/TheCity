using JetBrains.Annotations;
using UnityEngine.SceneManagement;
using Zenject;

namespace TheCity
{
    [UsedImplicitly]
    public class CompaniesCreator
    {
        [Inject] private CompanyFactory CompanyFactory { get; }

        public Company Create(City city, CompanyData companyData)
        {
            var company = CompanyFactory.Create(city, companyData);

            company.gameObject.name = $"{companyData.CompanyName.Name}";
            company.transform.SetParent(null);
            SceneManager.MoveGameObjectToScene(company.gameObject, SceneManager.GetActiveScene());

            return company;
        }
    }
}