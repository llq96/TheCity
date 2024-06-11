using TheCity.InGameTime;
using UnityEngine;
using Zenject;

namespace TheCity
{
    public class TimeOfDay : MonoBehaviour
    {
        [Inject] private GameTime GameTime { get; }
        [SerializeField] private Light _light;

        // [SerializeField] private float _angleOffset;

        [SerializeField] private AnimationCurve _curve_progressToLightPower;
        [SerializeField] private AnimationCurve _curve_progressToAngle;

        private void Update()
        {
            var dateTime = GameTime.GameDateTime;

            var minutesFromMidNight = dateTime.Hour * 60 + dateTime.Minute;
            var progress = minutesFromMidNight / (float)(24 * 60);

            Vector3 rotationVector = Vector3.zero;
            rotationVector.x = _curve_progressToAngle.Evaluate(progress) * 180f;
            var rotation = Quaternion.Euler(rotationVector);
            _light.transform.rotation = rotation;

            var lightPower = _curve_progressToLightPower.Evaluate(progress);
            _light.intensity = lightPower;
        }
    }
}