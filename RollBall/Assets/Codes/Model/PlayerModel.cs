using UnityEngine;

namespace Kravchuk
{
    public sealed class PlayerModel
    {
        private int _health = 100;
        private int _minHealth = 0;
        private int _maxHealth = 100;

        private bool _needChangeSpeed = false;
        private float _originSpeed = 5f;
        private float _changedSpeed = 0f;
        private float _durationSpeedChange = 0f;
        private float _durationSpeedChangeCurrent = 0f;

        private Rigidbody _playerRigidbody;

        #region Properties

        /// <summary>
        /// Current health
        /// </summary>
        public int Health
        {
            get => _health;

            set
            {
                _health = Mathf.Clamp(_health + value, _minHealth, _maxHealth);
            }
        }

        /// <summary>
        /// Current speed
        /// </summary>
        public float CurrentSpeed { get; set; }

        #endregion

        public PlayerModel(Rigidbody rigidbody)
        {
            _playerRigidbody = rigidbody;
            CurrentSpeed = _originSpeed;
        }

        /// <summary>
        /// Change speed from origin speed to deltaSpeed due duration
        /// </summary>
        /// <param name="deltaSpeed"></param>
        /// <param name="duration"></param>
        public void ChangeSpeed(float deltaSpeed, float duration)
        {
            if (deltaSpeed == 0 && duration == 0)
            {
                _playerRigidbody.velocity = Vector3.zero;
                return;
            }

            _changedSpeed = CurrentSpeed + deltaSpeed;
            CurrentSpeed += deltaSpeed;
            _durationSpeedChange = duration;
            _durationSpeedChangeCurrent = 0f;
            _needChangeSpeed = true;
        }

        /// <summary>
        /// Move model by direction
        /// </summary>
        /// <param name="direction"></param>
        public void LetMove(Vector3 direction)
        {
            _playerRigidbody.velocity = direction * CurrentSpeed;

            CalculateSpeed();
        }

        private void CalculateSpeed()
        {
            if (_needChangeSpeed)
            {
                if (_durationSpeedChangeCurrent >= _durationSpeedChange)
                {
                    _needChangeSpeed = false;
                    CurrentSpeed = _originSpeed;
                }
                else
                {
                    CurrentSpeed = Mathf.Lerp(_changedSpeed, _originSpeed, _durationSpeedChangeCurrent / _durationSpeedChange);
                    _durationSpeedChangeCurrent += Time.deltaTime;
                }
            }
        }
    }
}