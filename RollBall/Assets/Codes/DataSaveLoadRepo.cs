using System.Collections.Generic;
using UnityEngine;

namespace Kravchuk
{
    public sealed class DataSaveLoadRepo
    {
        private List<GameObject> _incomingData;
        private List<SavingData> _savingData;

        public DataSaveLoadRepo()
        {
            _incomingData = new List<GameObject>();
            _savingData = new List<SavingData>();
        }

        /// <summary>
        /// Add data to repository
        /// </summary>
        /// <param name="data"></param>
        public void AddDataToSaveRepo(GameObject data)
        {
            _incomingData.Add(data);
        }

        /// <summary>
        /// Do save operation
        /// </summary>
        public void Save()
        {
            _savingData.Clear();
            string prefabName = "";

            foreach (GameObject item in _incomingData)
            {
                if (item)
                {
                    if (item.CompareTag(Tags.PlayerTag))
                        prefabName = ResourcesPath.ResourcePlayerBall;
                    else
                        switch (item?.GetComponent<Pickup>())
                        {
                            case PickupHealth temp:
                                prefabName = ResourcesPath.ResourcePickupHealth;
                                break;

                            case PickupSpeed temp:
                                prefabName = ResourcesPath.ResourcePickupSpeed;
                                break;

                            case PickupWin temp:
                                prefabName = ResourcesPath.ResourcePickupWin;
                                break;

                            default:
                                break;
                        }

                    _savingData.Add(
                        new SavingData
                        {
                            InstanceID = item.GetInstanceID(),
                            PrefabName = prefabName,
                            ObjectName = item.name,
                            PositionX = item.transform.position.x,
                            PositionZ = item.transform.position.z
                        }
                        );
                }
            }

            DataSaveXML.DoSave(
                _savingData,
                DirsAndFiles.SaveDir,
                DirsAndFiles.SaveFileNameXML);
        }

        /// <summary>
        /// Do load operation
        /// </summary>
        public void Load()
        {
            Debug.Log("Do Load");
        }
    }
}
