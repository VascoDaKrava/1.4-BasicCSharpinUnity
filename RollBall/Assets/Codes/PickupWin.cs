using UnityEngine;
using static UnityEngine.Debug;

namespace Kravchuk
{
    public sealed class PickupWin : Pickup
    {
        protected override void Interaction()
        {
            PlayerContr.WinPoints = 1;
            //Debug
            //Log
        }
    }
}