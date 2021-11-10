using static UnityEngine.Debug;
using UnityEngine;
using System.Collections;

namespace Kravchuk
{
    public sealed class PlayerController
    {
        private bool _needChangeSpeed = false;
        private int _health = 100;
        private int _maxHealth = 100;
        private int _winPoints = 0;
        private float _originSpeed = 5f;
        private float _changedSpeed = 0f;
        private float _durationSpeedChange = 0f;
        private float _durationSpeedChangeCurrent = 0f;
        private Vector3 _moveDirection;
        private InputManager _inputManager = new InputManager();

        #region Properties

        /// <summary>
        /// Link to rigidbody
        /// </summary>
        public Rigidbody PlayerRigidbody { get; set; }

        /// <summary>
        /// Change quantity of points by value to win
        /// </summary>
        public int WinPoints
        {
            //get => _winPoints;

            set
            {
                _winPoints += value;
                Log("Current win-points : " + _winPoints);
            }
        }

        /// <summary>
        /// Change player health by value. Die if it less 0
        /// </summary>
        public int Health
        {
            //get => _health;

            set
            {
                Log($"Changing health by {value}");
                _health += value;

                if (_health > _maxHealth)
                    _health = _maxHealth;
                else
                if (_health <= 0)
                    Die();

                Log($"Current health = {_health}");
            }
        }

        /// <summary>
        /// Current speed
        /// </summary>
        public float Speed { get; set; }

        #endregion

        public PlayerController()
        {
            Speed = _originSpeed;
        }

        /// <summary>
        /// Change speed to deltaSpeed due duration
        /// </summary>
        /// <param name="deltaSpeed"></param>
        /// <param name="duration"></param>
        public void ChangeSpeedTemporary(float deltaSpeed, float duration)
        {
            Log($"Changing speed by {deltaSpeed:F2}. Duration = {duration:F2}");
            _changedSpeed = Speed + deltaSpeed;
            Speed += deltaSpeed;
            _durationSpeedChange = duration;
            _durationSpeedChangeCurrent = 0f;
            _needChangeSpeed = true;
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

            if (_needChangeSpeed)
            {
                if (_durationSpeedChangeCurrent >= _durationSpeedChange)
                {
                    _needChangeSpeed = false;
                    Speed = _originSpeed;
                    Log($"Now speed = {Speed:F2}");
                }
                else
                {
                    Speed = Mathf.Lerp(_changedSpeed, _originSpeed, _durationSpeedChangeCurrent / _durationSpeedChange);
                    _durationSpeedChangeCurrent += Time.deltaTime;
                    //Log($"New speed = {Speed:F2}");
                }
            }
        }

        private void Die()
        {
            Log("Now DIE !");
        }
    }
}