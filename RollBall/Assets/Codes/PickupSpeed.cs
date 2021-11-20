using UnityEngine;

namespace Kravchuk
{
    public sealed class PickupSpeed : Pickup, IRotatable, IUpdatable
    {
        private PickupType _ownType = PickupType.Speed;

        private float _rotationSpeed = 30f;
        private float _deltaSpeed = 4f;
        private float _minDuration = 1f;
        private float _maxDuration = 10f;

        protected override void Interaction()
        {
            EventStorageLink.InvokePickupEvent(
                _ownType,
                Random.Range(-_deltaSpeed, _deltaSpeed),
                Random.Range(_minDuration, _maxDuration)
                );
        }

        #region Interfaces

        public void Rotate(Transform transform, float speed)
        {
            transform.RotateAround(transform.position, Vector3.up, Time.deltaTime * speed);
        }

        public void DoItInUpdate()
        {
            Rotate(transform, _rotationSpeed);
        }

        #endregion
    }
}