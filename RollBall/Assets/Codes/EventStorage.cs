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
        /// Invoke event for pickup with type and power
        /// </summary>
        /// <param name="type">Type of collected pickup</param>
        /// <param name="power">Power of collected pickup</param>
        public void InvokePickupEvent(Pickup.PickupType type, int power)
        {
            _pickupEvent.Invoke(new EventArguments(type, power));
        }

        /// <summary>
        /// Invoke event for pickup with type, power and duration
        /// </summary>
        /// <param name="type">Type of collected pickup</param>
        /// <param name="power">Power of collected pickup</param>
        /// <param name="duration">Effect duration</param>
        public void InvokePickupEvent(Pickup.PickupType type, float power, float duration)
        {
            _pickupEvent.Invoke(new EventArguments(type, power, duration));
        }
    }
}