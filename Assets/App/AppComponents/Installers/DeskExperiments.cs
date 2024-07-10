using DeskCore;
using TheCity.Unity;
using UnityEngine;
using Zenject;

namespace TheCity.Installers
{
    public class DeskExperiments : MonoBehaviour //TODO Remove class
    {
        [Inject] private City City { get; }
        [Inject] private Desk Desk { get; }

        private void Start()
        {
            var card = new CitizenCard(City.Citizens[0].CitizenData);
            var card2 = new CitizenCard(City.Citizens[1].CitizenData);

            Desk.Graph.AddElement(card);
            Desk.Graph.AddElement(card2);
            Desk.Graph.AddEdge(card, card2);
        }
    }
}