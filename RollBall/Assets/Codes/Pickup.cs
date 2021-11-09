using UnityEngine;

namespace Kravchuk
{
    public abstract class Pickup : MonoBehaviour
    {
        /// <summary>
        /// Link to PlayerController
        /// </summary>
        public PlayerController PlayerControllerLink { get;  set; }

        /// <summary>
        /// Link to Transform of Pickup
        /// </summary>
        public Transform TransformLink { get;  set; }

        /// <summary>
        /// Link to EventStorage
        /// </summary>
        public EventStorage EventStorageLink { get;  set; }
        
        /// <summary>
        /// Tag of pickup
        /// </summary>
        public GameController.PickupTags PickupTag { get; set; }

        //public Pickup(PlayerController playerController, Transform transform)
        //{
        //    PlayerContr = playerController;
        //    PickupTransform = transform;
        //}

        /// <summary>
        /// Do some action
        /// </summary>
        protected abstract void Interaction();

        /// <summary>
        /// Contains methods for running in Update
        /// </summary>
        protected internal abstract void DoItInUpdate();

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Interaction();
                Destroy(gameObject);
            }
        }
    }
}