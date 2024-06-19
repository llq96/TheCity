using JetBrains.Annotations;
using UnityEngine.SceneManagement;
using Zenject;

namespace TheCity
{
    [UsedImplicitly]
    public class CitizensCreator
    {
        [Inject] private CitizenFactory CitizenFactory { get; }

        public Citizen Create(City city, CitizenCreationData creationData)
        {
            var citizen = CitizenFactory.Create(city, creationData);
            var inbornData = creationData.CitizenData.CitizenInbornData;

            citizen.gameObject.name = $"{inbornData.Name.FullName}";
            citizen.transform.SetParent(null);
            SceneManager.MoveGameObjectToScene(citizen.gameObject, SceneManager.GetActiveScene());

            return citizen;
        }
    }
}