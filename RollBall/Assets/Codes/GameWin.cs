namespace Kravchuk
{
    public sealed class GameWin
    {
        private int _pointsToWin = 5;
        private int _currentWinPoints = 0;

        private EventStorage _eventStorage;

        private UIElems _elementsUI;

        public GameWin(EventStorage eventStorage, UIElems elementsUI)
        {
            _elementsUI = elementsUI;
            _eventStorage = eventStorage;

            // Subscribe event for detect collecting winpoint
            _eventStorage.PickupEvent += PickupCollected;

            ChangePoints(_currentWinPoints);
        }

        /// <summary>
        /// Event handler
        /// </summary>
        /// <param name="eventData">Data that was received from event</param>
        private void PickupCollected(EventArguments eventData)
        {
            if (eventData.TypeP == PickupType.Win)
                ChangePoints(eventData.PowerInt);
        }

        /// <summary>
        /// Change win-poins by value
        /// </summary>
        /// <param name="point">How many points for change</param>
        private void ChangePoints(int point)
        {
                _currentWinPoints += point;
                _elementsUI.WinTextValue = $"{_currentWinPoints} / {_pointsToWin}";
                
                if (_currentWinPoints >= _pointsToWin)
                    Win();
        }

        /// <summary>
        /// Execute when win
        /// </summary>
        private void Win()
        {
            _elementsUI.MenuText = "Congratulations!\nYou win!";
            _elementsUI.ChangeButtonVisible(ButtonsName.Load, true);
            _elementsUI.ChangeButtonVisible(ButtonsName.Restart, true);
            _elementsUI.MenuVisible = true;
        }

        ~GameWin()
        {
            _eventStorage.PickupEvent -= PickupCollected;
        }
    }
}
