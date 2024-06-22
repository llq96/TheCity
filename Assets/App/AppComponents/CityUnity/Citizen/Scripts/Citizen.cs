using TheCity.Core;
using UnityEngine;
using Zenject;

namespace TheCity.Unity
{
    public class Citizen : MonoBehaviour
    {
        [Inject] public CitizenData CitizenData { get; }
        [Inject] public CitizenInbornData InbornData { get; }

        [Inject] public LivingRoom HomeRoom { get; }

        [Inject] public Company Company { get; }
        [Inject] public JobPost JobPost { get; }

        [Inject] private CitizenActivityScheduler CitizenActivityScheduler { get; }

        [Inject] private CitizenStatesSwitcher StatesSwitcher { get; }


        [ContextMenu(nameof(PrintSelf))]
        private void PrintSelf()
        {
            this.PrintFormattedInfo();
        }

        [ContextMenu(nameof(PrintScheduler))]
        private void PrintScheduler()
        {
            CitizenActivityScheduler.PrintFormattedInfo();
        }

        public override string ToString() => InbornData.Name.ToString();
    }
}