using UnityEngine;
using Zenject;

namespace TheCity
{
    public class SceneTestButtons : MonoBehaviour
    {
        [Inject] private CitizensCreator CitizensCreator { get; }

        [ContextMenu(nameof(CreateTestCitizens))]
        private void CreateTestCitizens()
        {
            for (int i = 0; i < 3; i++)
            {
                CitizensCreator.CreateNewCitizen();
            }
        }
    }
}