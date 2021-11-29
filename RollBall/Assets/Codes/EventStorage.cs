using System;

namespace Kravchuk
{
    public sealed class EventStorage
    {
        private event Action<EventArguments> _pickupEvent;

        public event Action<EventArguments> PickupEvent
        {
            add { _pickupEvent += value; }
            remove { _pickupEvent -= value; }
        }

        /// <summary>
        /// Invoke event from object obj
        /// </summary>
        /// <param name="obj">Link to object</param>
        public void InvokePickupEvent(object obj)
        {
            _pickupEvent.Invoke(new EventArguments(obj));
        }

        /// <summary>
        /// Invoke event for pickup with type and power
        /// </summary>
        /// <param name="type">Type of collected pickup</param>
        /// <param name="obj">Link to pickup-object</param>
        /// <param name="power">Power of collected pickup</param>
        public void InvokePickupEvent(Pickup.PickupType type, object obj, int power)
        {
            _pickupEvent.Invoke(new EventArguments(type, obj, power));
        }

        /// <summary>
        /// Invoke event for pickup with type, power and duration
        /// </summary>
        /// <param name="type">Type of collected pickup</param>
        /// <param name="obj">Link to pickup-object</param>
        /// <param name="power">Power of collected pickup</param>
        /// <param name="duration">Effect duration</param>
        public void InvokePickupEvent(Pickup.PickupType type, object obj, float power, float duration)
        {
            _pickupEvent.Invoke(new EventArguments(type, obj, power, duration));
        }
    }
}