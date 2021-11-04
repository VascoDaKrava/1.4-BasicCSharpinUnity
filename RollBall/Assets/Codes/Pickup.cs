using UnityEngine;

namespace Kravchuk
{
    public abstract class Pickup : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Interaction();
                Destroy(gameObject);
            }
        }

        public PlayerController PlayerContr { get;  set; }

        protected abstract void Interaction();
    }
}