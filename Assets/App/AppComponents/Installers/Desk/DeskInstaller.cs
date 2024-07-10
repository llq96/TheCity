using DeskCore;
using Zenject;

namespace TheCity.Installers
{
    public class DeskInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Desk>().AsSingle().NonLazy();
        }
    }
}