using System.Collections.Generic;
using UnityEngine;

namespace Kravchuk
{
    /// <summary>
    /// Class for storage links
    /// </summary>
    public sealed class Links
    {
        private UIElems _elementsUILink;
        private GameWin _gameWinLink;
        private GameLose _gameLoseLink;
        private InputManager _inputManager;
        private DataSaveLoadRepo _dataSaveLoadRepo;

        public Rigidbody PlayerRigidbodyLink { get; }
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
            _dataSaveLoadRepo = new DataSaveLoadRepo();
            EventStorageLink = new EventStorage();
            Pickups = new List<IUpdatable>();

            MenuPause = new MenuPauseController(_inputManager, _elementsUILink);

            PlayerRigidbodyLink = GameObject.FindGameObjectWithTag(Tags.PlayerTag).GetComponent<Rigidbody>();

            _buttonsClickHandler = GameObject.FindGameObjectWithTag(Tags.GameControllerTag).GetComponent<UIButtonsClickHandler>();
            _buttonsClickHandler.ElemsUI = _elementsUILink;
            _buttonsClickHandler.DataSaveLoadLink = _dataSaveLoadRepo;

            CameraControllerLink = new CameraController(
                GameObject.FindGameObjectWithTag(Tags.CameraTag).GetComponent<Camera>(),
                PlayerRigidbodyLink
                );

            _gameLoseLink = new GameLose(_elementsUILink);
            _gameWinLink = new GameWin(EventStorageLink, _elementsUILink);

            PlayerControllerLink = new PlayerController(
                EventStorageLink,
                PlayerRigidbodyLink,
                _elementsUILink,
                _gameLoseLink,
                _inputManager,
                _dataSaveLoadRepo);

            _dataSaveLoadRepo.AddDataToSaveRepo(PlayerRigidbodyLink.gameObject);

            foreach (Pickup item in GameObject.FindObjectsOfType<Pickup>())
            {
                item.EventStorageLink = EventStorageLink;
                _dataSaveLoadRepo.AddDataToSaveRepo(item.gameObject);
                Pickups.Add((IUpdatable)item);
            }
        }
    }
}