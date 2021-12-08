using System.Collections.Generic;
using UnityEngine;

namespace Kravchuk
{
    /// <summary>
    /// Class for storage links
    /// </summary>
    public sealed class Links
    {
        private Rigidbody _playerRigidbodyLink;
        private UIElems _elementsUILink;
        private GameWin _gameWinLink;
        private GameLose _gameLoseLink;
        private InputManager _inputManager;

        public PlayerController PlayerControllerLink { get; }
        public EventStorage EventStorageLink { get; }
        public CameraController CameraControllerLink { get; }
        public List<IUpdatable> Pickups { get; }
        public MenuPauseController MenuPause { get; }

        private UIButtonsClickHandler _buttonsClickHandler;

        public Links()
        {
            _inputManager = new InputManager();
            _elementsUILink = new UIElems();
            EventStorageLink = new EventStorage();
            Pickups = new List<IUpdatable>();

            MenuPause = new MenuPauseController(_inputManager, _elementsUILink);

            _playerRigidbodyLink = GameObject.FindGameObjectWithTag(Tags.PlayerTag).GetComponent<Rigidbody>();

            _buttonsClickHandler = GameObject.FindGameObjectWithTag(Tags.GameControllerTag).GetComponent<UIButtonsClickHandler>();
            _buttonsClickHandler.ElemsUI = _elementsUILink;

            CameraControllerLink = new CameraController(
                GameObject.FindGameObjectWithTag(Tags.CameraTag).GetComponent<Camera>(),
                _playerRigidbodyLink
                );

            _gameLoseLink = new GameLose(_elementsUILink);
            _gameWinLink = new GameWin(EventStorageLink, _elementsUILink);

            PlayerControllerLink = new PlayerController(
                EventStorageLink,
                _playerRigidbodyLink,
                _elementsUILink,
                _gameLoseLink,
                _inputManager);

            foreach (Pickup item in GameObject.FindObjectsOfType<Pickup>())
            {
                item.EventStorageLink = EventStorageLink;
                Pickups.Add((IUpdatable)item);
            }
        }
    }
}