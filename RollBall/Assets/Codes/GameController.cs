using System;
using System.Collections.Generic;
using UnityEngine;

namespace Kravchuk
{
    public sealed class GameController : MonoBehaviour
    {
        private bool _needRemovePickup = false;

        private Rigidbody _playerRigidbody;
        private Camera _camera;

        private PlayerController _playerController = new PlayerController();
        private CameraController _cameraController = new CameraController();

        private List<Pickup> _pickupsList = new List<Pickup>();

        private void Awake()
        {
            
            _playerRigidbody = GameObject.FindGameObjectWithTag("Player")?.GetComponent<Rigidbody>();

            if (_playerRigidbody == null)
                throw new RollballException("Need object with tag \"Player\" and component Rigidbody");
            
            _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

            foreach (GameObject item in GameObject.FindGameObjectsWithTag("PickupWinTag"))
            {
                _pickupsList.Add(item.AddComponent<PickupWin>());
                _pickupsList[_pickupsList.Count - 1].PlayerContr = _playerController;
                _pickupsList[_pickupsList.Count - 1].PickupTransform = item.transform;
            }

            foreach (GameObject item in GameObject.FindGameObjectsWithTag("PickupSpeedTag"))
            {
                _pickupsList.Add(item.AddComponent<PickupSpeed>());
                _pickupsList[_pickupsList.Count - 1].PlayerContr = _playerController;
                _pickupsList[_pickupsList.Count - 1].PickupTransform = item.transform;
            }

            foreach (GameObject item in GameObject.FindGameObjectsWithTag("PickupHealthTag"))
            {
                _pickupsList.Add(item.AddComponent<PickupHealth>());
                _pickupsList[_pickupsList.Count - 1].PlayerContr = _playerController;
                _pickupsList[_pickupsList.Count - 1].PickupTransform = item.transform;
            }
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
    }
}
