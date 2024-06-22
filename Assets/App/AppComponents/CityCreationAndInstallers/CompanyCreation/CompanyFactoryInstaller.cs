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
                .ByNewPrefabInstaller<CompanyInstaller>(_companyPrefab);
        }
    }

    [UsedImplicitly]
    public class CompanyFactory : PlaceholderFactory<City, CompanyData, Company>
    {
    }
}