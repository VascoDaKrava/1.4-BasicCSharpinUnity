using UnityEngine;

namespace Kravchuk
{
    public sealed class PlayerController
    {
        private int _health = 100;
        private int _maxHealth = 100;
        private int _winPoints = 0;
        private float _originSpeed = 5f;
        private float _currentSpeed = 0f;
        private Vector3 _moveDirection;
        private InputManager _inputManager = new InputManager();

        #region Properties

        public Rigidbody PlayerRigidbody { get; set; }

        public int WinPoints
        {
            get => _winPoints;

            set
            {
                _winPoints += value;
                Debug.Log("WP = " + _winPoints);
            }
        }

        public int Health
        {
            get => _health;

            set
            {
                // Change player health by value. Die if it less 0
                _health += value;

                if (_health > _maxHealth)
                    _health = _maxHealth;
                else
                if (_health <= 0)
                    Die();
            }
        }

        public float Speed
        {
            get => _currentSpeed;

            set { _currentSpeed = value; }
        }

        #endregion

        public PlayerController()
        {
            Speed = _originSpeed;
        }

        /// <summary>
        /// Move player
        /// </summary>
        public void LetMove()
        {
            if (_inputManager.IsStop)
            {
                PlayerRigidbody.velocity = Vector3.zero;
                return;
            }

            _moveDirection = _inputManager.GetDirection();

            if (_moveDirection != Vector3.zero)
                PlayerRigidbody.velocity = _moveDirection * Speed;
        }

        private void Die()
        {

        }
    }
}