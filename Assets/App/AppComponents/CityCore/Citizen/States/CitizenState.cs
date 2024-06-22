namespace TheCity.Core
{
    public abstract class CitizenState
    {
        public abstract CitizenStateEnum CitizenStateEnum { get; }

        public bool IsActive { get; private set; }

        public void EnableState()
        {
            IsActive = true;
            EnableStateAction();
        }

        protected virtual void EnableStateAction()
        {
        }

        public void DisableState()
        {
            IsActive = false;
            DisableStateAction();
        }

        protected virtual void DisableStateAction()
        {
        }

        public bool IsCanSwitchToThisFrom(CitizenStateEnum? currentStateCitizenStateEnum)
        {
            return true;
        }

        public bool IsCanSwitchTo(CitizenStateEnum citizenStateEnum)
        {
            return true;
        }
    }

    public enum CitizenStateEnum
    {
        Moving,
        Sleeping,
        Working
    }
}