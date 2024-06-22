using JetBrains.Annotations;
using TheCity.Core;
using UnityEngine;
using Zenject;

namespace TheCity.Unity
{
    [UsedImplicitly]
    public class CitizenState_Sleeping : CitizenState
    {
        [Inject] public Citizen Citizen { get; }

        public override CitizenStateEnum CitizenStateEnum => CitizenStateEnum.Sleeping;

        protected override void EnableStateAction()
        {
            base.EnableStateAction();
            Citizen.transform.localScale = Vector3.one * 0.5f; //TODO
        }

        protected override void DisableStateAction()
        {
            base.DisableStateAction();
            Citizen.transform.localScale = Vector3.one; //TODO
        }
    }
}