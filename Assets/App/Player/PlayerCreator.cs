using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace TheCity
{
    public class PlayerCreator
    {
        [Inject] private PlayerFactoryInstaller.PlayerFactory PlayerFactory { get; }

        public Player Create(Transform spawnPoint)
        {
            var player = PlayerFactory.Create();

            player.gameObject.name = "===Player===";
            player.transform.SetParent(null);
            SceneManager.MoveGameObjectToScene(player.gameObject, SceneManager.GetActiveScene());

            player.transform.position = spawnPoint.position;
            player.transform.rotation = spawnPoint.rotation;

            return player;
        }
    }
}