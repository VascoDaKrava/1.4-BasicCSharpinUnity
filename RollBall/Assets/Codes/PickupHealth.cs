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

        private Vector3 _newPosition;
        private Vector3 _newScale;

        protected override void Interaction()
        {
            PlayerContr.Health = Random.Range(-_deltaPower, _deltaPower + 1);
        }

        /// <summary>
        /// Move pickup from 0 to _maxHeightFly through Y-axis with _speedFly
        /// </summary>
        public void Fly()
        {
            _newPosition.x = PickupTransform.localPosition.x;
            _newPosition.y = Mathf.PingPong(Time.time * _flySpeed, _maxFlyHeight);
            _newPosition.z = PickupTransform.localPosition.z;

            PickupTransform.localPosition = _newPosition;
        }

        /// <summary>
        /// Rotate pickup around themself through Y-axis with _speedRotation
        /// </summary>
        public void Rotate()
        {
            PickupTransform.RotateAround(PickupTransform.position, Vector3.up, Time.deltaTime * _rotationSpeed);
        }

        /// <summary>
        /// Change pickup scale from _minScale to _maxScale with _scaleSpeed
        /// </summary>
        public void Resize()
        {
            _newScale.x = 
            _newScale.y = 
            _newScale.z = Mathf.PingPong(Time.time * _scaleSpeed, _maxScale - _minScale) + _minScale;
            PickupTransform.localScale = _newScale;
        }

        protected internal override void DoItInUpdate()
        {
            Fly();
            Rotate();
            Resize();
        }
    }
}