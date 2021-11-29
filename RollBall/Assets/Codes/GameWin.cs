using UnityEngine;

namespace Kravchuk
{
    public sealed class GameWin
    {
        private int _pointsToWin = 5;
        private int _currentWinPoints = 0;

        private EventStorage _eventStorage;

        private UIElements _elementsUI;

        public GameWin(EventStorage eventStorage, UIElements elementsUI)
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
            if (eventData.TypeP == Pickup.PickupType.Win)
                ChangePoints(eventData.PowerInt);
        }

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
            Debug.Log("Now you win!");
        }

        ~GameWin()
        {
            _eventStorage.PickupEvent -= PickupCollected;
        }
    }
}
