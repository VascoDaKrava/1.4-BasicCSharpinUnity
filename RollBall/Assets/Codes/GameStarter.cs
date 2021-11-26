using System;
using System.Collections.Generic;
using UnityEngine;

namespace Kravchuk
{
    public sealed class GameStarter : MonoBehaviour, IDisposable
    {
        private int _winPoints = 5;

        private List<IUpdatable> _updatables;
        private List<ILateupdatable> _lateUpdatables;

        private Links _links;

        private void Awake()
        {
            _links = new Links();

            _updatables = new List<IUpdatable>();
            _lateUpdatables = new List<ILateupdatable>();

            _lateUpdatables.Add(_links.CameraControllerLink);

            #region Lesson5

            _updatables.Add(new L5());

            #endregion

            _updatables.Add(_links.PlayerControllerLink);
            _updatables.AddRange(_links.Pickups);

            // Subscribe event for detect collecting winpoint
            _links.EventStorageLink.PickupEvent += PickupCollected;
        }

        private void Update()
        {
            foreach (IUpdatable item in _updatables)
            {
                item.DoItInUpdate();
            }
        }

        private void LateUpdate()
        {
            foreach (ILateupdatable item in _lateUpdatables)
            {
                item.DoItInLateupdate();
            }
        }

        /// <summary>
        /// Event handler
        /// </summary>
        /// <param name="eventData">Data that was received from event</param>
        private void PickupCollected(EventArguments eventData)
        {
            _updatables.Remove((IUpdatable)eventData.Obj);

            if (eventData.TypeP == Pickup.PickupType.Win)
            {
                _winPoints -= eventData.PowerInt;
                if (_winPoints > 0)
                    Debug.Log($"Collected win-point! {_winPoints} left to win");
                else
                    Win();
            }
        }

        /// <summary>
        /// Execute when win
        /// </summary>
        private void Win()
        {
            Debug.Log("Now you win!");
        }

        #region Interfaces

        public void Dispose()
        {
            _links.EventStorageLink.PickupEvent -= PickupCollected;
        }

        #endregion
    }
}
