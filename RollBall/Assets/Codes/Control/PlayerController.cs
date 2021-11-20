using System;
using UnityEngine;

namespace Kravchuk
{
    public sealed class PlayerController : IDisposable, IUpdatable
    {
        private Vector3 _moveDirection;
        private InputManager _inputManager;
        private EventStorage _eventStorage;
        private PlayerModel _playerModel;

        /// <summary>
        /// Create PlayerController
        /// </summary>
        /// <param name="eventStorage">Link to EventStorage</param>
        /// <param name="rigidbody">Link to Rigidbody</param>
        public PlayerController(EventStorage eventStorage, Rigidbody rigidbody)
        {
            _eventStorage = eventStorage;
            _eventStorage.PickupEvent += PickupCollected;

            _inputManager = new InputManager();

            _playerModel = new PlayerModel(rigidbody);
        }

        /// <summary>
        /// Event hendler
        /// </summary>
        /// <param name="eventData"></param>
        private void PickupCollected(EventArguments eventData)
        {
            if (eventData.TypeE == typeof(PickupHealth))
            {
                _playerModel.Health = eventData.PowerInt;
                
                if (_playerModel.Health == 0)
                    Die();
            }
            else
                if (eventData.TypeE == typeof(PickupSpeed))
                _playerModel.ChangeSpeed(eventData.PowerFloat, eventData.Duration);
        }

        /// <summary>
        /// Execute when die
        /// </summary>
        private void Die()
        {
            Debug.LogWarning("Now DIE !");
        }

        /// <summary>
        /// Move player
        /// </summary>
        private void LetMove()
        {
            if (_inputManager.IsStop)
            {
                _playerModel.ChangeSpeed(0f, 0f);
                return;
            }

            _moveDirection = _inputManager.GetDirection();

            if (_moveDirection != Vector3.zero)
                _playerModel.LetMove(_moveDirection);
        }

        #region Interfaces

        public void Dispose()
        {
            _eventStorage.PickupEvent -= PickupCollected;
        }

        public void DoItInUpdate()
        {
            LetMove();
        }

        #endregion
    }
}