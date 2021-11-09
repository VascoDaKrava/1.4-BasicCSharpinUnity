using UnityEngine;

namespace Kravchuk
{
    public sealed class PickupWin : Pickup, IFly
    {
        private float _maxFlyHeight = 1f;
        private float _flySpeed = 2f;
        private int _pickupPower = 1;

        protected override void Interaction()
        {
            EventStorageLink.InvokePickupEvent(PickupTag, _pickupPower);
        }

        public void Fly(Transform transform, float maxHeightFly, float speedFly)
        {
            Vector3 newPosition;

            newPosition.x = transform.localPosition.x;
            newPosition.y = Mathf.PingPong(Time.time * speedFly, maxHeightFly);
            newPosition.z = transform.localPosition.z;

            transform.localPosition = newPosition;
        }

        protected internal override void DoItInUpdate()
        {
            Fly(TransformLink, _maxFlyHeight, _flySpeed);
        }
    }
}