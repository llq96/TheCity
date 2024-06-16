using UnityEngine;
using Zenject;

namespace TheCity
{
    [TestsInfo(100)]
    public class JobsInstaller : MonoInstaller
    {
        [SerializeField] private PossibleJobTitles _possibleJobTitles;

        public override void InstallBindings()
        {
            Container.Bind<IPossibleJobTitles>().FromInstance(_possibleJobTitles).AsSingle().NonLazy();
        }
    }
}