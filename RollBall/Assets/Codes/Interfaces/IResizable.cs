using UnityEngine;

namespace Kravchuk
{
    public interface IResizable
    {
        /// <summary>
        /// Change transform scale from minScale to maxScale with speed
        /// </summary>
        /// <param name="transform">Transform for scaling</param>
        /// <param name="minScale">From this scale factor</param>
        /// <param name="maxScale">To this scale factor</param>
        /// <param name="speed">Scaling speed</param>
        void Resize(Transform transform, float minScale, float maxScale, float speed);
    }
}