using UnityEngine;

namespace Kravchuk
{
    public sealed class CameraController
    {
        private float _speed = 5f;
        private float _speedUpMultiplier = 3f;
        private float _speedMultiplier = 1f;
        private float _distanceToSpeedChange = 10f;
        private Vector3 _offset = new Vector3(0f, 6f, -4f);

        public Camera MainCamera { get; set; }

        /// <summary>
        /// Move camera to playerPosition
        /// </summary>
        /// <param name="playerPosition"></param>
        public void LetMove(Vector3 playerPosition)
        {
            if (Vector3.Magnitude(playerPosition - MainCamera.transform.position) < _distanceToSpeedChange)
                _speedMultiplier = 1;
            else
                _speedMultiplier = _speedUpMultiplier;

            MainCamera.transform.position = Vector3.MoveTowards(MainCamera.transform.position, playerPosition + _offset, _speed * _speedMultiplier * Time.deltaTime);
        }
    }
}