using System;
using System.Collections.Generic;
using System.Linq;

namespace TheCity
{
    public class BaseCitizenStatesSwitcher
    {
        public CitizenState CurrentState { get; set; }
        public CitizenStateEnum CurrentStateEnum => CurrentState?.CitizenStateEnum ?? CitizenStateEnum.Moving;

        public event Action<CitizenState> OnStateChanged;

        protected readonly List<CitizenState> States = new();

        protected CitizenState GetState(CitizenStateEnum citizenStateEnum) =>
            States.FirstOrDefault(x => x.CitizenStateEnum == citizenStateEnum);

        // protected CitizenState GetState<TCitizenState>() => States.FirstOrDefault(x => x is TCitizenState);

        public bool IsCanSwitchTo(CitizenStateEnum citizenStateEnum)
        {
            if (!GetState(citizenStateEnum).IsCanSwitchToThisFrom(CurrentState?.CitizenStateEnum)) return false;
            if (CurrentState != null && !CurrentState.IsCanSwitchTo(citizenStateEnum)) return false;
            return true;
        }

        protected bool SetState(CitizenState newState, bool isIgnoreChecks = false)
        {
            CitizenStateEnum newStateEnum = newState.CitizenStateEnum;

            if (!isIgnoreChecks)
            {
                if (!IsCanSwitchTo(newStateEnum)) return false;
            }

            // Debug.Log($"{nameof(BaseCitizenStatesSwitcher)}: SetState: {newStateEnum}");

            if (CurrentState != null) CurrentState.DisableState();
            CurrentState = newState;
            CurrentState.EnableState();

            OnStateChanged?.Invoke(CurrentState);

            return true;
        }
    }
}