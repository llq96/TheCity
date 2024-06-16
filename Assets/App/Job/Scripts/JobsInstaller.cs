using UnityEngine;
using Zenject;

namespace TheCity
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