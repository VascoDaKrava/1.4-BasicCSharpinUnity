namespace Kravchuk
{
    public sealed class GameLose
    {
        private UIElems _elementsUI;

        public GameLose(UIElems elementsUI)
        {
            _elementsUI = elementsUI;
        }

        /// <summary>
        /// Do this, when user die
        /// </summary>
        public void PlayerDie()
        {
            _elementsUI.MenuText = "Wasted!\nYou lose...";
            _elementsUI.ChangeButtonVisible(ButtonsName.Load, true);
            _elementsUI.ChangeButtonVisible(ButtonsName.Restart, true);
            _elementsUI.MenuVisible = true;
        }
    }
}