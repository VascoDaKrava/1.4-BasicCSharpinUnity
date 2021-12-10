using System.Collections.Generic;
using UnityEngine;

namespace Kravchuk
{
    public sealed class DataSaveLoadRepo
    {
        private List<GameObject> _incomingData;
        private List<SavingData> _savingData;
        private Links _links;

        public DataSaveLoadRepo(Links links)
        {
            _incomingData = new List<GameObject>();
            _savingData = new List<SavingData>();

            _links = links;
        }

        /// <summary>
        /// Add GameObject to repository
        /// </summary>
        /// <param name="data">GameObject</param>
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

            foreach (GameObject item in _incomingData)
            {
                if (item)
                {
                    _savingData.Add(
                        new SavingData
                        {
                            InstanceID = item.GetInstanceID(),
                            PrefabName = GetPrefabName(item),
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
            _savingData = DataLoadXML.DoLoad(
                DirsAndFiles.SaveDir,
                DirsAndFiles.SaveFileNameXML);

            RestoreFromSavingDataList();
        }

        private void RestoreFromSavingDataList()
        {
            foreach (GameObject item in _incomingData)
            {
                if (!item.CompareTag(Tags.PlayerTag))
                    GameObject.Destroy(item);
            }

            foreach (SavingData objectFromSave in _savingData)
            {
                GameObject objectAtScene = GameObject.Find(objectFromSave.ObjectName);
                if (objectAtScene)
                {// Доделать проверку по поиску всех имён
                    if (objectAtScene.GetInstanceID() == objectFromSave.InstanceID)
                    {
                        objectAtScene.transform.position = new Vector3(objectFromSave.PositionX, 0.5f, objectFromSave.PositionZ);
                    }
                }
                else
                {
                    objectAtScene =
                    (GameObject)GameObject.Instantiate(
                        Resources.Load(objectFromSave.PrefabName),
                        new Vector3(objectFromSave.PositionX, 0f, objectFromSave.PositionZ),
                        Quaternion.identity);
                    // Добавить родительский объект
                    // Доделать добавление в глобал-апдейт
                    // Поправить контроль высоты
                    // Поправить создание дубликатов
                    objectAtScene.GetComponent<Pickup>().EventStorageLink = _links.EventStorageLink;
                }

                //Debug.Log(objectFromSave.ObjectName);
            }
        }

        /// <summary>
        /// Get prefab name for GameObject. Return NULL if can't find same Prefab
        /// </summary>
        /// <param name="item">GameObject</param>
        /// <returns></returns>
        private string GetPrefabName(GameObject item)
        {
            string prefabName = null;
            if (item.CompareTag(Tags.PlayerTag))
                prefabName = ResourcesPath.ResourcePlayerBall;
            else
            {
                Pickup pickup;
                if (item.TryGetComponent(out pickup))
                    switch (pickup)
                    {
                        case PickupHealth _:
                            prefabName = ResourcesPath.ResourcePickupHealth;
                            break;

                        case PickupSpeed _:
                            prefabName = ResourcesPath.ResourcePickupSpeed;
                            break;

                        case PickupWin _:
                            prefabName = ResourcesPath.ResourcePickupWin;
                            break;

                        default:
                            break;
                    }
            }

            return prefabName;
        }
    }
}
