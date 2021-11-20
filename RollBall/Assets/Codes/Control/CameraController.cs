using UnityEngine;

namespace Kravchuk
{
    public sealed class CameraController : ILateupdatable
    {
        private float _speed = 5f;
        private float _speedUpMultiplier = 3f;
        private float _speedMultiplier = 1f;
        private float _distanceToSpeedChange = 10f;
        private Vector3 _offset = new Vector3(0f, 6f, -4f);
        private Camera _mainCamera;
        private Rigidbody _playerRigidbody;

        public CameraController(Camera camera, Rigidbody playerRigidbody)
        {
            _mainCamera = camera;
            _playerRigidbody = playerRigidbody;
        }

        /// <summary>
        /// Move camera to playerPosition
        /// </summary>
        /// <param name="playerPosition"></param>
        public void LetMove(Vector3 playerPosition)
        {
            if (Vector3.Magnitude(playerPosition - _mainCamera.transform.position) < _distanceToSpeedChange)
                _speedMultiplier = 1;
            else
                _speedMultiplier = _speedUpMultiplier;

            _mainCamera.transform.position = Vector3.MoveTowards(_mainCamera.transform.position, playerPosition + _offset, _speed * _speedMultiplier * Time.deltaTime);
        }

        #region Interfaces

        public void DoItInLateupdate()
        {
            LetMove(_playerRigidbody.position);
        }

        #endregion
    }
}