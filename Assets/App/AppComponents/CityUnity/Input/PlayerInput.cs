using UnityEngine;
using Zenject;

namespace TheCity.Unity
{
    public class PlayerInput : IInitializable
    {
        [Inject] private GameTime GameTime { get; }
        [Inject] private GameInputActions GameInputActions { get; }

        public void Initialize()
        {
            GameInputActions.Enable();
            
            GameInputActions.Time.Time_Pause.performed += (_) => { SetGameTimeType(GameTimeType.Pause); };
            GameInputActions.Time.Time_Play.performed += (_) => { SetGameTimeType(GameTimeType.Play); };
            GameInputActions.Time.Time_FastPlay.performed += (_) => { SetGameTimeType(GameTimeType.FastPlay); };
            GameInputActions.Time.Time_VeryFastPlay.performed += (_) => { SetGameTimeType(GameTimeType.VeryFastPlay); };
            
            void SetGameTimeType(GameTimeType type)
            {
                Debug.Log(type);

                GameTime.GameTimeType = type;
            }
        }
    }
}