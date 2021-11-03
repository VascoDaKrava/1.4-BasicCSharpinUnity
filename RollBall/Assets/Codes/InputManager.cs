using UnityEngine;

namespace Kravchuk
{
    public sealed class InputManager
    {
        private Vector3 _direction;

        /// <summary>
        /// Return normalized Vector3 of direction if pressed move-keys
        /// </summary>
        /// <returns></returns>
        public Vector3 GetDirection()
        {
            _direction.x = Input.GetAxis("Horizontal");
            _direction.y = 0;
            _direction.z = Input.GetAxis("Vertical");
                        
            return _direction.normalized;
        }
    }
}