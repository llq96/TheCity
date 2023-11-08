using UnityEngine;
using Zenject;

namespace TheCity
{
    public class NamesGeneratorInstaller : MonoInstaller
    {
        [SerializeField] private NamesGeneratorSettings _namesGeneratorSettings;

        public override void InstallBindings()
        {
            Container.Bind<NamesGeneratorSettings>().FromInstance(_namesGeneratorSettings).AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<NamesGenerator>().AsSingle().NonLazy();
        }
    }
}