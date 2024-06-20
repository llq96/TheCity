using JetBrains.Annotations;
using UnityEngine;

namespace TheCity
{
    [UsedImplicitly]
    public class CitizenState_Sleeping : CitizenState
    {
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