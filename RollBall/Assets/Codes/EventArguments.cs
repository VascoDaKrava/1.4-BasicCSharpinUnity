using System;

namespace Kravchuk
{
    public sealed class EventArguments : EventArgs
    {
        /// <summary>
        /// Pickup type
        /// </summary>
        public Pickup.PickupType TypeP { get; }

        /// <summary>
        /// Power integer
        /// </summary>
        public int PowerInt { get; } = 0;

        /// <summary>
        /// Power float
        /// </summary>
        public float PowerFloat { get; } = 0f;

        /// <summary>
        /// Duration
        /// </summary>
        public float Duration { get; } = 0f;

        /// <summary>
        /// Two EventArgs
        /// </summary>
        /// <param name="type"></param>
        /// <param name="power"></param>
        public EventArguments(Pickup.PickupType type, int power)
        {
            TypeP = type;
            PowerInt = power;
        }

        /// <summary>
        /// Three EventArgs
        /// </summary>
        /// <param name="type"></param>
        /// <param name="power"></param>
        /// <param name="duration"></param>
        public EventArguments(Pickup.PickupType type, float power, float duration)
        {
            TypeP = type;
            PowerFloat = power;
            Duration = duration;
        }
    }
}