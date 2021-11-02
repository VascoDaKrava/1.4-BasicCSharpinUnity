using UnityEngine;

namespace Kravchuk
{
    public class PlayerController
    {
        private float _maxSpeed = 5f;
        private Vector3 _moveDirection;
        private InputManager _inputManager = new InputManager();

        public Rigidbody PlayerRigidBody { get; set; }

        public void LetMove()
        {
            _moveDirection = _inputManager.GetDirection();

            if (_moveDirection != Vector3.zero)
                PlayerRigidBody.velocity = _moveDirection * _maxSpeed;
        }
    }
}