using UnityEngine;

namespace Kravchuk
{
    public interface IRotatable
    {
        /// <summary>
        /// Rotate transform around themself through Y-axis with speed
        /// </summary>
        /// <param name="transform">Transform for rotation</param>
        /// <param name="speed">Rotation speed</param>
        void Rotate(Transform transform, float speed);
    }
}