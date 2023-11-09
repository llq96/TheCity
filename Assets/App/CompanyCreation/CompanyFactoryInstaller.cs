using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace TheCity
{
    public class CompanyFactoryInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _companyPrefab;

        public override void InstallBindings()
        {
            InstallFactory();

            Container.BindInterfacesAndSelfTo<CompaniesCreator>().AsSingle().NonLazy();
        }

        private void InstallFactory()
        {
            Container.BindFactory<City, CompanyData, Company, CompanyFactory>()
                .FromSubContainerResolve()
                .ByNewPrefabMethod(_companyPrefab, InstallCompany);
        }

        private void InstallCompany(DiContainer subContainer, City city, CompanyData companyData)
        {
            subContainer.Bind<City>().FromInstance(city);
            subContainer.Bind<CompanyData>().FromInstance(companyData);
            CompanyInstaller.Install(subContainer);
        }
    }

    [UsedImplicitly]
    public class CompanyFactory : PlaceholderFactory<City, CompanyData, Company>
    {
    }
}