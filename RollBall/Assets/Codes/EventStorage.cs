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
        /// Invoke event for pickup with pickup-tag and power
        /// </summary>
        /// <param name="tag">Type of collected pickup</param>
        /// <param name="power">Power of collected pickup</param>
        public void InvokePickupEvent(GameController.PickupTags tag, int power)
        {
            _pickupEvent.Invoke(new EventArguments(tag, power));
        }

        /// <summary>
        /// Invoke event for pickup with pickup-tag, power and duration
        /// </summary>
        /// <param name="tag">Type of collected pickup</param>
        /// <param name="power">Power of collected pickup</param>
        /// <param name="duration">Effect duration</param>
        public void InvokePickupEvent(GameController.PickupTags tag, float power, float duration)
        {
            _pickupEvent.Invoke(new EventArguments(tag, power, duration));
        }
    }
}