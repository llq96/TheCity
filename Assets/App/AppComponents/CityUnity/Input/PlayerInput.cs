using JetBrains.Annotations;
using Zenject;

namespace TheCity.Unity
{
    [UsedImplicitly]
    public class PlayerInput : IInitializable
    {
        [Inject] private GameTime GameTime { get; }
        [Inject] private PlayerInputActions PlayerInputActions { get; }

        public void Initialize()
        {
            PlayerInputActions.Enable();

            PlayerInputActions.Time.Time_Pause.performed += _ => { SetGameTimeType(GameTimeType.Pause); };
            PlayerInputActions.Time.Time_Play.performed += _ => { SetGameTimeType(GameTimeType.Play); };
            PlayerInputActions.Time.Time_FastPlay.performed += _ => { SetGameTimeType(GameTimeType.FastPlay); };
            PlayerInputActions.Time.Time_VeryFastPlay.performed += _ => { SetGameTimeType(GameTimeType.VeryFastPlay); };

            return;

            void SetGameTimeType(GameTimeType type)
            {
                GameTime.GameTimeType.Value = type;
            }
        }
    }
}