using TheCity.AI;
using Zenject;

namespace TheCity.Installers
{
    public class AIInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ThinkGenerator>().AsSingle().NonLazy();
        }
    }
}