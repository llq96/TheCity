using UnityEngine;
using Zenject;

namespace TheCity.UI
{
    public class MainCanvasInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _mainCanvasPrefab;

        public override void InstallBindings()
        {
            var canvasOnScene = FindObjectOfType<MainCanvas>();

            if (canvasOnScene)
            {
                Container.Bind(typeof(MainCanvas))
                    .To<MainCanvas>()
                    .FromInstance(canvasOnScene)
                    .AsSingle()
                    .NonLazy();
            }
            else
            {
                Container.Bind(typeof(MainCanvas))
                    .To<MainCanvas>()
                    .FromComponentInNewPrefab(_mainCanvasPrefab)
                    .AsSingle()
                    .NonLazy();
            }
        }
    }
}