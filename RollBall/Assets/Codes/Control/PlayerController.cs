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
        private PlayerView _playerView;

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
            _playerView = new PlayerView();
        }

        /// <summary>
        /// Event hendler
        /// </summary>
        /// <param name="eventData"></param>
        private void PickupCollected(EventArguments eventData)
        {
            switch (eventData.TypeP)
            {
                case Pickup.PickupType.Health:
                    _playerView.ServiceMessage($"Changing health by {eventData.PowerInt}");
                    _playerModel.Health = eventData.PowerInt;
                    _playerView.ChangeHealth(_playerModel.Health);

                    if (_playerModel.Health == 0)
                        Die();
                    
                    break;
                
                case Pickup.PickupType.Speed:
                    _playerModel.ChangeSpeed(eventData.PowerFloat, eventData.Duration);
                    _playerView.ChangeSpeed(eventData.PowerFloat, eventData.Duration);

                    break;
                
                default:
                    break;
            }
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
                _playerView.ServiceMessage("Now stop!");
                return;
            }

            _moveDirection = _inputManager.GetDirection();

            if (_moveDirection != Vector3.zero)
            {
                _playerModel.LetMove(_moveDirection);
            }
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