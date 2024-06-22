using TheCity.InGameTime;
using UnityEngine;
using Zenject;

namespace TheCity
{
    public class NightLamp : MonoBehaviour
    {
        [Inject] private GameTime GameTime { get; }

        [SerializeField] private Light _light;

        private bool _isLightActive;

        private int _hourToEnableLight;
        private int _hourToDisableLight;

        private void Start()
        {
            _isLightActive = _light.enabled;

            _hourToEnableLight = UnityEngine.Random.Range(18, 23);
            _hourToDisableLight = UnityEngine.Random.Range(4, 8);
        }

        private void Update()
        {
            var dateTime = GameTime.GameDateTime;
            var hour = dateTime.Hour;


            if (!_isLightActive && hour == _hourToEnableLight)
            {
                SetActiveLight(true);
            }

            if (_isLightActive && hour == _hourToDisableLight)
            {
                SetActiveLight(false);
            }
        }

        private void SetActiveLight(bool isActive)
        {
            _isLightActive = isActive;
            _light.enabled = _isLightActive;
        }
    }
}