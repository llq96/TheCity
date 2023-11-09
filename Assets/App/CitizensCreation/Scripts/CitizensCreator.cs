using JetBrains.Annotations;
using UnityEngine.SceneManagement;
using Zenject;

namespace TheCity
{
    [UsedImplicitly]
    public class CitizensCreator
    {
        [Inject] private CitizenFactory CitizenFactory { get; }

        public Citizen Create(CitizenCreationData creationData)
        {
            var citizen = CitizenFactory.Create(creationData);
            var inbornData = creationData.CitizenData.CitizenInbornData;

            citizen.gameObject.name = $"{inbornData.FirstName} {inbornData.SecondName}";
            citizen.transform.SetParent(null);
            SceneManager.MoveGameObjectToScene(citizen.gameObject, SceneManager.GetActiveScene());

            return citizen;
        }
    }
}