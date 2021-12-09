using System;

namespace Kravchuk
{
    /// <summary>
    /// Class for serialize data for saving
    /// </summary>
    [Serializable]
    public sealed class SavingData
    {
        public int InstanceID;

        public string PrefabName;

        public string ObjectName;

        public float PositionX;

        public float PositionZ;
    }
}
