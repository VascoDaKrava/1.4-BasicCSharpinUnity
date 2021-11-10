using System;
using System.Collections.Generic;
using UnityEngine;

namespace Kravchuk
{
    public sealed class GameController : MonoBehaviour, IDisposable
    {
        public enum PickupTags
        {
            PickupWinTag,
            PickupSpeedTag,
            PickupHealthTag
        }

        private bool _needRemovePickup = false;

        private int _winPoints = 5;

        private Rigidbody _playerRigidbody;
        private Camera _camera;

        private PlayerController _playerController;
        private CameraController _cameraController;

        private List<Pickup> _pickupsList;

        private EventStorage _eventStorage;

        private void Awake()
        {
            _pickupsList = new List<Pickup>();
            _cameraController = new CameraController();
            _eventStorage = new EventStorage();
            _playerController = new PlayerController(_eventStorage);

            _eventStorage.PickupEvent += PickupCollected;

            #region Searching Player and Camera

            _playerRigidbody = GameObject.FindGameObjectWithTag("Player")?.GetComponent<Rigidbody>();

            if (_playerRigidbody == null)
                throw new RollballException("Need object with tag \"Player\" and component Rigidbody");

            _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

            #endregion

            #region Searching and configuring objects with pickups tags

            foreach (GameObject item in GameObject.FindGameObjectsWithTag(PickupTags.PickupWinTag.ToString()))
            {
                //item.AddComponent<PickupWin>();
                //_pickupsList.Add(item.AddComponent<PickupWin>(_playerController, transform));
                _pickupsList.Add(item.AddComponent<PickupWin>());
                SetPickupParameters(_pickupsList[_pickupsList.Count - 1], _playerController, item.transform, _eventStorage, PickupTags.PickupWinTag);
            }

            foreach (GameObject item in GameObject.FindGameObjectsWithTag(PickupTags.PickupSpeedTag.ToString()))
            {
                _pickupsList.Add(item.AddComponent<PickupSpeed>());
                SetPickupParameters(_pickupsList[_pickupsList.Count - 1], _playerController, item.transform, _eventStorage, PickupTags.PickupSpeedTag);
            }

            foreach (GameObject item in GameObject.FindGameObjectsWithTag(PickupTags.PickupHealthTag.ToString()))
            {
                //PickupHealth asd = new PickupHealth(_playerController, transform);
                //item.AddComponent<PickupHealth>();
                //_pickupsList.Add(asd);

                _pickupsList.Add(item.AddComponent<PickupHealth>());
                SetPickupParameters(_pickupsList[_pickupsList.Count - 1], _playerController, item.transform, _eventStorage, PickupTags.PickupHealthTag);
            }

            #endregion
        }


        private void Start()
        {
            _playerController.PlayerRigidbody = _playerRigidbody;
            _cameraController.MainCamera = _camera;
        }

        private void Update()
        {
            _playerController.LetMove();

            foreach (Pickup item in _pickupsList)
            {
                if (item == null)
                    _needRemovePickup = true;
                else
                    item.DoItInUpdate();
            }
        }

        private void LateUpdate()
        {
            if (_needRemovePickup)
            {
                _pickupsList.Remove(null);
                _needRemovePickup = false;
            }

            _cameraController.LetMove(_playerRigidbody.position);
        }

        /// <summary>
        /// Set parameters for pickup object
        /// </summary>
        /// <param name="pickup">Link to pickup</param>
        /// <param name="playerController">Link to PlayerController for use in Pickup</param>
        /// <param name="transform">Link to Transform of this Pickup</param>
        /// <param name="eventStorage">Link to EventStorage for use in Pickup</param>
        /// <param name="pickupTag">Tag of this Pickup</param>
        private void SetPickupParameters(
            Pickup pickup,
            PlayerController playerController,
            Transform transform,
            EventStorage eventStorage,
            PickupTags pickupTag)
        {
            pickup.PlayerControllerLink = playerController;
            pickup.TransformLink = transform;
            pickup.EventStorageLink = eventStorage;
            pickup.PickupTag = pickupTag;
        }

        /// <summary>
        /// Event hendler
        /// </summary>
        /// <param name="eventData">Data that was received from event</param>
        private void PickupCollected(EventArguments eventData)
        {
            if (eventData.TagE == PickupTags.PickupWinTag)
                _winPoints -= eventData.PowerInt;

            if (_winPoints > 0)
                Debug.Log($"Collected win-point! {_winPoints} left to win");
            else
                Win();
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
