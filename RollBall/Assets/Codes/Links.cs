using System.Collections.Generic;
using UnityEngine;

namespace Kravchuk
{
    /// <summary>
    /// Class for storage links
    /// </summary>
    public sealed class Links
    {
        private string _playerTag = "Player";
        private string _cameraTag = "MainCamera";

        public Rigidbody PlayerRigidbodyLink { get; }
        public PlayerController PlayerControllerLink { get; }
        public EventStorage EventStorageLink { get; }
        public CameraController CameraControllerLink { get; }
        public List<IUpdatable> Pickups { get; }

        public Links()
        {
            PlayerRigidbodyLink = GameObject.FindGameObjectWithTag(_playerTag).GetComponent<Rigidbody>();
            CameraControllerLink = new CameraController(
                GameObject.FindGameObjectWithTag(_cameraTag).GetComponent<Camera>(),
                PlayerRigidbodyLink
                );
            EventStorageLink = new EventStorage();
            PlayerControllerLink = new PlayerController(EventStorageLink, PlayerRigidbodyLink);
            
            Pickups = new List<IUpdatable>();
            foreach (Pickup item in GameObject.FindObjectsOfType<Pickup>())
            {
                item.EventStorageLink = EventStorageLink;
                Pickups.Add((IUpdatable)item);
            }
        }
    }
}