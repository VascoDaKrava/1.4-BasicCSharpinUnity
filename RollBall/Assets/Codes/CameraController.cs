using UnityEngine;

namespace Kravchuk
{
    public sealed class CameraController
    {
        private float _speed = 5f;
        private Vector3 _offset = new Vector3(0f, 6f, -4f);

        public Camera MainCamera { get; set; }

        /// <summary>
        /// Move camera to playerPosition
        /// </summary>
        /// <param name="playerPosition"></param>
        public void LetMove(Vector3 playerPosition)
        {
            MainCamera.transform.position = Vector3.MoveTowards(MainCamera.transform.position, playerPosition + _offset, _speed * Time.deltaTime);
        }
    }
}