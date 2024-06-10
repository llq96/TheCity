using UnityEngine;
using Zenject;

namespace TheCity
{
    public class JobsInstaller : MonoInstaller
    {
        [SerializeField] private PossibleJobTitles _possibleJobTitles;

        public override void InstallBindings()
        {
            Container.Bind<PossibleJobTitles>().FromInstance(_possibleJobTitles).AsSingle().NonLazy();
        }
    }
}