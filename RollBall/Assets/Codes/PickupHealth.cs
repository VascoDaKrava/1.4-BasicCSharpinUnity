using UnityEngine;

namespace Kravchuk
{
    public sealed class PickupHealth : Pickup, IFly, IResize, IRotate
    {
        private int _deltaPower = 99;

        private float _maxFlyHeight = 1f;
        private float _flySpeed = 2f;

        private float _rotationSpeed = 30f;

        private float _minScale = 0.5f;
        private float _maxScale = 1.5f;
        private float _scaleSpeed = 2f;

        //public PickupHealth(PlayerController playerController, Transform transform)
        //    : base(playerController, transform)
        //{ }

        protected override void Interaction()
        {
            EventStorageLink.InvokePickupEvent(PickupTag, Random.Range(-_deltaPower, _deltaPower + 1));
        }

        public void Fly(Transform transform, float maxHeight, float speed)
        {
            Vector3 newPosition;

            newPosition.x = transform.localPosition.x;
            newPosition.y = Mathf.PingPong(Time.time * speed, maxHeight);
            newPosition.z = transform.localPosition.z;

            transform.localPosition = newPosition;
        }

        public void Rotate(Transform transform, float speed)
        {
            transform.RotateAround(transform.position, Vector3.up, Time.deltaTime * speed);
        }

        public void Resize(Transform transform, float minScale, float maxScale, float speed)
        {
            Vector3 newScale;

            newScale.x =
            newScale.y =
            newScale.z = Mathf.PingPong(Time.time * speed, maxScale - minScale) + minScale;

            transform.localScale = newScale;
        }

        protected internal override void DoItInUpdate()
        {
            Fly(TransformLink, _maxFlyHeight, _flySpeed);
            Rotate(TransformLink, _rotationSpeed);
            Resize(TransformLink, _minScale, _maxScale, _scaleSpeed);
        }
    }
}