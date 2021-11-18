using UnityEngine;

namespace Kravchuk
{
    public abstract class Pickup : MonoBehaviour
    {
        /// <summary>
        /// Link to EventStorage
        /// </summary>
        public EventStorage EventStorageLink { get;  set; }
        
        /// <summary>
        /// Do action, when Player enter in trigger
        /// </summary>
        protected abstract void Interaction();

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