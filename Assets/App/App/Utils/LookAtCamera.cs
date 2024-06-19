using UnityEngine;

namespace TheCity
{
    public class LookAtCamera : MonoBehaviour
    {
        [SerializeField] private bool _isReverseLook;

        private Transform _cameraTransform;

        public void Update()
        {
            if (_cameraTransform == null)
            {
                TrySetCamera();
            }

            if (_cameraTransform != null)
            {
                LookAtCameraNow();
            }
        }

        private void LookAtCameraNow()
        {
            Vector3 targetPosition;
            if (!_isReverseLook)
            {
                targetPosition = new Vector3(
                    _cameraTransform.position.x,
                    transform.position.y,
                    _cameraTransform.position.z);
            }
            else
            {
                targetPosition = transform.position + (transform.position - _cameraTransform.position).normalized;
                targetPosition.y = transform.position.y;
            }

            transform.LookAt(targetPosition);
        }

        private void TrySetCamera()
        {
            var mainCamera = Camera.main;
            if (mainCamera != null)
            {
                _cameraTransform = mainCamera.transform;
            }
        }
    }
}