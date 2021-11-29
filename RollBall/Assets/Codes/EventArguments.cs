using System;

namespace Kravchuk
{
    public sealed class EventArguments : EventArgs
    {
        /// <summary>
        /// Object
        /// </summary>
        public object Obj { get; } = null;

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
        /// One EventArgs
        /// </summary>
        /// <param name="obj"></param>
        public EventArguments(object obj)
        {
            Obj = obj;
        }

        /// <summary>
        /// Three EventArgs
        /// </summary>
        /// <param name="type"></param>
        /// <param name="obj"></param>
        /// <param name="power"></param>
        public EventArguments(Pickup.PickupType type, object obj, int power)
        {
            Obj = obj;
            TypeP = type;
            PowerInt = power;
        }

        /// <summary>
        /// Four EventArgs
        /// </summary>
        /// <param name="type"></param>
        /// <param name="obj"></param>
        /// <param name="power"></param>
        /// <param name="duration"></param>
        public EventArguments(Pickup.PickupType type, object obj, float power, float duration)
        {
            Obj = obj;
            TypeP = type;
            PowerFloat = power;
            Duration = duration;
        }
    }
}