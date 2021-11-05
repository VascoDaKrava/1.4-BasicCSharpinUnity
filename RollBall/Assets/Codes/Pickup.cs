using UnityEngine;

namespace Kravchuk
{
    public abstract class Pickup : MonoBehaviour
    {
        public PlayerController PlayerContr { get;  set; }
        public Transform PickupTransform { get;  set; }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Interaction();
                Destroy(gameObject);
            }
        }

        protected abstract void Interaction();

        /// <summary>
        /// Contains methods for running in Update
        /// </summary>
        protected internal abstract void DoItInUpdate();
    }
}