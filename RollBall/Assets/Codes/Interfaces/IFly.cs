using UnityEngine;

namespace Kravchuk
{
    public interface IFly
    {
        /// <summary>
        /// Move transform from 0 to maxHeight through Y-axis with speed
        /// </summary>
        /// <param name="transform">Transform for moving</param>
        /// <param name="maxHeight">Max height for moving</param>
        /// <param name="speed">Moving speed</param>
        void Fly(Transform transform, float maxHeight, float speed);
    }
}