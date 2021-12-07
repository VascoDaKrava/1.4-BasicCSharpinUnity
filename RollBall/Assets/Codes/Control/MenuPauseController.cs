namespace Kravchuk
{
    public sealed class MenuPauseController : IUpdatable
    {
        private InputManager _inputManager;
        private UIElems _elementsUI;

        public MenuPauseController(InputManager inputManager, UIElems elems)
        {
            _inputManager = inputManager;
            _elementsUI = elems;
        }

        public void DoItInUpdate()
        {
            if (_inputManager.IsPausePress)
                _elementsUI.MenuVisible = !_elementsUI.MenuVisible;
        }
    }
}
