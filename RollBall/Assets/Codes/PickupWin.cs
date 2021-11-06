using UnityEngine;

namespace Kravchuk
{
    public sealed class PickupWin : Pickup, IFly
    {
        private float _maxFlyHeight = 1f;
        private float _flySpeed = 2f;

        protected override void Interaction()
        {
            PlayerContr.WinPoints = 1;
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
            Fly(PickupTransform, _maxFlyHeight, _flySpeed);
        }
    }
}