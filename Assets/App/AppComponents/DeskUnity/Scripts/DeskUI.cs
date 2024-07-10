using DeskCore;
using UnityEngine;
using Zenject;

namespace DeskUnity
{
    public class DeskUI : MonoBehaviour
    {
        [Inject] private Desk Desk { get; }

        //TODO Перенести в инсталлер, сделать фабрику, сделать пул
        [SerializeField] private CitizenDeskCardUI _citizenCardPrefab;
        [SerializeField] private Transform _cardsParent;

        private void OnEnable()
        {
            Debug_VisualizeDesk();
        }

        private void Debug_VisualizeDesk()
        {
            Debug.Log(Desk.Graph.Elements.Count);
            foreach (var elem in Desk.Graph)
            {
                if (elem is CitizenCard citizenCard)
                {
                    var cardUI = Instantiate(_citizenCardPrefab, _cardsParent);
                    cardUI.SetCitizenData(citizenCard.CitizenData);
                }
            }
        }
    }
}