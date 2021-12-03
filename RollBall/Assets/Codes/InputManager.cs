using UnityEngine;

namespace Kravchuk
{
    public sealed class InputManager
    {
        private Vector3 _direction;

        public bool IsStop
        {
            get { return Input.GetButton(InputKeysAndAxis.ButtonStop); }
        }

        /// <summary>
        /// Return normalized Vector3 of direction if pressed move-keys
        /// </summary>
        /// <returns></returns>
        public Vector3 GetDirection()
        {
            _direction.x = Input.GetAxis(InputKeysAndAxis.AxisHorizontal);
            _direction.y = 0;
            _direction.z = Input.GetAxis(InputKeysAndAxis.AxisVertical);

            return _direction.normalized;
        }

        public bool IsFivePress
        {
            get { return Input.GetKeyDown(InputKeysAndAxis.ButtonFive); }
        }
    }
}