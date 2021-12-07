using System.Collections.Generic;
using UnityEngine;

namespace Kravchuk
{
    public sealed class GameStarter : MonoBehaviour
    {

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
            _updatables.Add(_links.MenuPause);
            _updatables.AddRange(_links.Pickups);

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

        private void PickupCollected(EventArguments eventData)
        {
            _updatables.Remove((IUpdatable)eventData.Obj);
        }
    }
}
