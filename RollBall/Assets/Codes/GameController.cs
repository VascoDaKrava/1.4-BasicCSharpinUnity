//using System;
//using System.Collections.Generic;
using UnityEngine;

namespace Kravchuk
{
    public sealed class GameController : MonoBehaviour
    {
        private Rigidbody _playerRigidbody;
        private Camera _camera;

        private PlayerController _playerController = new PlayerController();
        private CameraController _cameraController = new CameraController();

        //private List<PickupWin> _listPickupWin = new List<PickupWin>();
        //private List<PickupSpeed> _listPickupSpeed = new List<PickupSpeed>();
        //private List<PickupHealth> _listPickupHealth = new List<PickupHealth>();

        private void Awake()
        {
            _playerRigidbody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
            _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

            foreach (GameObject item in GameObject.FindGameObjectsWithTag("PickupWinTag"))
            {
                item.AddComponent<PickupWin>().PlayerContr = _playerController;
                //_listPickupWin.Add(item.AddComponent<PickupWin>());
                //_listPickupWin[_listPickupWin.Count - 1].PlayerContr = _playerController;
            }

            foreach (GameObject item in GameObject.FindGameObjectsWithTag("PickupSpeedTag"))
            {
                item.AddComponent<PickupSpeed>().PlayerContr = _playerController;
                //_listPickupSpeed.Add(item.AddComponent<PickupSpeed>());
            }

            foreach (GameObject item in GameObject.FindGameObjectsWithTag("PickupHealthTag"))
            {
                item.AddComponent<PickupHealth>().PlayerContr = _playerController;
                //_listPickupHealth.Add(item.AddComponent<PickupHealth>());
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
        }

        private void LateUpdate()
        {
            _cameraController.LetMove(_playerRigidbody.position);
        }
    }

}
