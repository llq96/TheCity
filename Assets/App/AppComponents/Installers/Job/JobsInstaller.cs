using TheCity.CityDataGeneration;
using UnityEngine;
using Zenject;

namespace TheCity.Installers
{
    public class JobsInstaller : MonoInstaller
    {
        [SerializeField] private PossibleJobTitles _possibleJobTitles;

        public override void InstallBindings()
        {
            Container.Bind<IPossibleJobTitles>().FromInstance(_possibleJobTitles).AsSingle().NonLazy();
        }
    }
}