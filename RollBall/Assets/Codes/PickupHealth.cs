using UnityEngine;

namespace Kravchuk
{
    public sealed class PickupHealth : Pickup, IFlyable, IResizable, IRotatable, IUpdatable
    {
        private int _deltaPower = 99;

        private float _maxFlyHeight = 1f;
        private float _flySpeed = 2f;

        private float _rotationSpeed = 30f;

        private float _minScale = 0.5f;
        private float _maxScale = 1.5f;
        private float _scaleSpeed = 2f;

        protected override void Interaction()
        {
            EventStorageLink.InvokePickupEvent(GetType(), Random.Range(-_deltaPower, _deltaPower + 1));
        }

        void IFlyable.Fly(Transform transform, float maxHeight, float speed)
        {
            Vector3 newPosition;

            newPosition.x = transform.localPosition.x;
            newPosition.y = Mathf.PingPong(Time.time * speed, maxHeight);
            newPosition.z = transform.localPosition.z;

            transform.localPosition = newPosition;
        }

        void IRotatable.Rotate(Transform transform, float speed)
        {
            transform.RotateAround(transform.position, Vector3.up, Time.deltaTime * speed);
        }

        void IResizable.Resize(Transform transform, float minScale, float maxScale, float speed)
        {
            Vector3 newScale;

            newScale.x =
            newScale.y =
            newScale.z = Mathf.PingPong(Time.time * speed, maxScale - minScale) + minScale;

            transform.localScale = newScale;
        }

        void IUpdatable.DoItInUpdate()
        {
            ((IFlyable)this).Fly(transform, _maxFlyHeight, _flySpeed);
            ((IRotatable)this).Rotate(transform, _rotationSpeed);
            ((IResizable)this).Resize(transform, _minScale, _maxScale, _scaleSpeed);
        }
    }
}