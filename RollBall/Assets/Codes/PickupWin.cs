namespace Kravchuk
{
    public sealed class PickupWin : Pickup, IFly, IResize
    {
        protected override void Interaction()
        {
            PlayerContr.WinPoints = 1;
        }

        public void Fly()
        {

        }

        public void Resize()
        {

        }

        protected internal override void DoItInUpdate()
        {
            Fly();
            Resize();
        }
    }
}