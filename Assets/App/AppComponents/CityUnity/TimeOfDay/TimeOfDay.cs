using UnityEngine;
using Zenject;

namespace TheCity.Unity
{
    public class TimeOfDay : MonoBehaviour
    {
        [Inject] private GameTime GameTime { get; }

        [Header("Components:")]
        [SerializeField] private Light _light;

        [Header("Light Power Settings:")]
        [SerializeField] private float _lightPowerMultiplier = 1f;
        [SerializeField] private AnimationCurve _curve_progressToLightPower;

        [Header("Light Angle Settings:")]
        [SerializeField] private AnimationCurve _curve_progressToAngle;

        [Header("Ambient Color Settings:")]
        [SerializeField] private Gradient _gradient_ambientColor;

        private void Update()
        {
            var progress = CalculateProgress();

            SetLightRotation(progress);
            SetLightPower(progress);
            SetAmbientColor(progress);
        }

        private float CalculateProgress()
        {
            var dateTime = GameTime.GameDateTime;

            var minutesFromMidNight = dateTime.Hour * 60 + dateTime.Minute;
            var progress = minutesFromMidNight / (float)(24 * 60);
            return progress;
        }

        private void SetLightPower(float progress)
        {
            var lightPower = _curve_progressToLightPower.Evaluate(progress) * _lightPowerMultiplier;
            _light.intensity = lightPower;
        }

        private void SetLightRotation(float progress)
        {
            Vector3 rotationVector = Vector3.zero;
            rotationVector.x = _curve_progressToAngle.Evaluate(progress) * 180f;
            var rotation = Quaternion.Euler(rotationVector);
            _light.transform.rotation = rotation;
        }

        private void SetAmbientColor(float progress)
        {
            var color = _gradient_ambientColor.Evaluate(progress);
            RenderSettings.ambientLight = color; //Не нравится это.
        }
    }
}