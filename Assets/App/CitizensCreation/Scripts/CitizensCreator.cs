using JetBrains.Annotations;
using UnityEngine.SceneManagement;
using Zenject;

namespace TheCity
{
    [UsedImplicitly]
    public class CitizensCreator
    {
        [Inject] private CitizenFactory CitizenFactory { get; }
        [Inject] private NamesGenerator NamesGenerator { get; }

        public void CreateNewCitizen()
        {
            NamesGenerator.GenerateRandomName(out var firstName, out var secondName);
            var inbornData = new CitizenInbornData(firstName, secondName);
            var creationData = new CitizenCreationData(inbornData);
            Create(creationData);
        }

        public void Create(CitizenCreationData creationData)
        {
            var citizen = CitizenFactory.Create(creationData);

            var inbornData = creationData.CitizenInbornData;

            citizen.gameObject.name = $"{inbornData.FirstName} {inbornData.SecondName}";
            citizen.transform.SetParent(null);
            SceneManager.MoveGameObjectToScene(citizen.gameObject, SceneManager.GetActiveScene());
        }
    }
}