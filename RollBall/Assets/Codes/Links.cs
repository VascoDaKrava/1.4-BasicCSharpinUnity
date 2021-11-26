using System.Collections.Generic;
using UnityEngine;

namespace Kravchuk
{
    /// <summary>
    /// Class for storage links
    /// </summary>
    public sealed class Links
    {
        public Rigidbody PlayerRigidbodyLink { get; }
        public PlayerController PlayerControllerLink { get; }
        public EventStorage EventStorageLink { get; }
        public CameraController CameraControllerLink { get; }
        public List<IUpdatable> Pickups { get; }
        public UIElements UIElementsLink { get; }

        public Links()
        {
            UIElementsLink = new UIElements();
            PlayerRigidbodyLink = GameObject.FindGameObjectWithTag(StaticValues.PlayerTag).GetComponent<Rigidbody>();
            
            CameraControllerLink = new CameraController(
                GameObject.FindGameObjectWithTag(StaticValues.CameraTag).GetComponent<Camera>(),
                PlayerRigidbodyLink
                );

            EventStorageLink = new EventStorage();
            PlayerControllerLink = new PlayerController(EventStorageLink, PlayerRigidbodyLink, UIElementsLink);
            
            Pickups = new List<IUpdatable>();
            foreach (Pickup item in GameObject.FindObjectsOfType<Pickup>())
            {
                item.EventStorageLink = EventStorageLink;
                Pickups.Add((IUpdatable)item);
            }
        }
    }
}