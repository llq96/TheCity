using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace TheCity
{
    [UsedImplicitly]
    public class CitizenStatesSwitcher : BaseCitizenStatesSwitcher, IInitializable
    {
        [Inject] protected CitizenState_Moving State_Moving { get; }
        [Inject] protected CitizenState_Sleeping State_Sleeping { get; }

        public void Initialize()
        {
            States.Add(State_Moving);
            States.Add(State_Sleeping);
        }

        public void SetState_Moving(Vector3 destination)
        {
            if (SetState(State_Moving))
            {
                State_Moving.MoveTo(destination);
            }
        }

        public void SetState_Sleeping()
        {
            SetState(State_Sleeping);
        }
    }
}