using UnityEngine;

namespace Kravchuk
{
    public sealed class PickupWin : Pickup
    {
        protected override void Interaction()
        {
            PlayerContr.WinPoints = 1;
        }
    }
}