using UnityEngine;

namespace Kravchuk
{
    /// <summary>
    /// Pickup type
    /// </summary>
    public enum PickupType
    {
        Health,
        Speed,
        Win
    }

    public abstract class Pickup : MonoBehaviour
    {
        /// <summary>
        /// Link to EventStorage
        /// </summary>
        public EventStorage EventStorageLink { get; set; }

        /// <summary>
        /// Do action, when Player enter in trigger
        /// </summary>
        protected abstract void Interaction();

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(StaticValues.PlayerTag))
            {
                Interaction();
                Destroy(gameObject);
            }
        }
    }
}