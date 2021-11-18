using System;
using System.Collections.Generic;
using UnityEngine;

namespace Kravchuk
{
    public sealed class GameStarter : MonoBehaviour, IDisposable
    {
        private bool _needRemoveFromUpdate = false;

        private int _winPoints = 5;

        private Rigidbody _playerRigidbody;
        private Camera _camera;

        private PlayerController _playerController;
        private CameraController _cameraController;

        private List<Pickup> _pickupsList;

        private List<IUpdatable> _updatables;

        private EventStorage _eventStorage;

        private void Awake()
        {
            #region Searching Player and Camera

            _playerRigidbody = GameObject.FindGameObjectWithTag("Player")?.GetComponent<Rigidbody>();

            if (_playerRigidbody == null)
                throw new RollballException("Need object with tag \"Player\" and component Rigidbody");

            _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

            #endregion

            _pickupsList = new List<Pickup>();
            _updatables = new List<IUpdatable>();
            _cameraController = new CameraController();
            _eventStorage = new EventStorage();
            _playerController = new PlayerController(_eventStorage, _playerRigidbody);
            _updatables.Add(_playerController);

            _eventStorage.PickupEvent += PickupCollected;

            #region Searching and configuring objects with pickups types

            foreach (Pickup item in GameObject.FindObjectsOfType<Pickup>())
            {
                item.EventStorageLink = _eventStorage;
                _pickupsList.Add(item);
                _updatables.Add((IUpdatable)item);
            }

            #endregion
        }


        private void Start()
        {
            _cameraController.MainCamera = _camera;
        }

        private void Update()
        {
            foreach (IUpdatable item in _updatables)
            {
                if (item.Equals(null))
                    _needRemoveFromUpdate = true;
                else
                    item.DoItInUpdate();
            }

            if (_needRemoveFromUpdate)
            {
                _updatables.Remove(null);
                _needRemoveFromUpdate = false;
            }
        }

        private void LateUpdate()
        {
            _cameraController.LetMove(_playerRigidbody.position);
        }

        /// <summary>
        /// Event hendler
        /// </summary>
        /// <param name="eventData">Data that was received from event</param>
        private void PickupCollected(EventArguments eventData)
        {
            if (eventData.TypeE == typeof(PickupWin))
            {
                _winPoints -= eventData.PowerInt;
                if (_winPoints > 0)
                    Debug.Log($"Collected win-point! {_winPoints} left to win");
                else
                    Win();
            }
        }

        /// <summary>
        /// Execute when win
        /// </summary>
        private void Win()
        {
            Debug.Log("Now you win!");
        }

        public void Dispose()
        {
            _eventStorage.PickupEvent -= PickupCollected;
        }
    }
}
