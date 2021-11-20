using UnityEngine;

namespace Kravchuk
{
    public sealed class PickupWin : Pickup, IFlyable, IUpdatable
    {
        private PickupType _ownType = PickupType.Win;

        private float _maxFlyHeight = 1f;
        private float _flySpeed = 2f;
        private int _pickupPower = 1;

        protected override void Interaction()
        {
            EventStorageLink.InvokePickupEvent(_ownType, _pickupPower);
        }

        #region Interfaces

        public void Fly(Transform transform, float maxHeightFly, float speedFly)
        {
            Vector3 newPosition;

            newPosition.x = transform.localPosition.x;
            newPosition.y = Mathf.PingPong(Time.time * speedFly, maxHeightFly);
            newPosition.z = transform.localPosition.z;

            transform.localPosition = newPosition;
        }

        public void DoItInUpdate()
        {
            Fly(transform, _maxFlyHeight, _flySpeed);
        }

        #endregion
    }
}