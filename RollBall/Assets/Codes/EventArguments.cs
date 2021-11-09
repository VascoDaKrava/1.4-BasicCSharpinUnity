using System;

namespace Kravchuk
{
    public sealed class EventArguments : EventArgs
    {
        /// <summary>
        /// Tag
        /// </summary>
        public GameController.PickupTags TagE { get; }

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
        /// <param name="tag"></param>
        /// <param name="power"></param>
        public EventArguments(GameController.PickupTags tag, int power)
        {
            TagE = tag;
            PowerInt = power;
        }

        /// <summary>
        /// Three EventArgs
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="power"></param>
        /// <param name="duration"></param>
        public EventArguments(GameController.PickupTags tag, float power, float duration)
        {
            TagE = tag;
            PowerFloat = power;
            Duration = duration;
        }
    }
}