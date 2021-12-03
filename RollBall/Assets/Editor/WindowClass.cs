using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Kravchuk
{
    public sealed class WindowClass : EditorWindow
    {
        private Dictionary<PickupType, Object> _pickups;

        private PickupType _selectedPickupType;

        private Vector3 _pickupPosition;

        private void OnEnable()
        {
            _pickups = new Dictionary<PickupType, Object>();
            _pickups.Add(PickupType.Health, Resources.Load(StaticValues.ResourcePickupHealth));
            _pickups.Add(PickupType.Speed, Resources.Load(StaticValues.ResourcePickupSpeed));
            _pickups.Add(PickupType.Win, Resources.Load(StaticValues.ResourcePickupWin));
        }

        private void OnGUI()
        {
            EditorGUILayout.Space(20f);
            EditorGUILayout.LabelField("Select pickup type for new object.");
            EditorGUILayout.LabelField("Then input position and create.");
            EditorGUILayout.Space(20f);

            _selectedPickupType = (PickupType)EditorGUILayout.EnumPopup("Pickup type: ", _selectedPickupType);
            EditorGUILayout.Separator();

            _pickupPosition = EditorGUILayout.Vector3Field("Pickup position : ", _pickupPosition);
            EditorGUILayout.Space(20f);

            if (GUILayout.Button($"Create Pickup-{_selectedPickupType}\nin position {_pickupPosition}"))
                MakeDirty(
                    GameObject.Instantiate(
                        _pickups[_selectedPickupType],
                        _pickupPosition,
                        Quaternion.identity,
                        GameObject.Find(StaticValues.PickupParentName).transform)
                );
        }

        /// <summary>
        /// Mark scene as modified/Dirty
        /// </summary>
        /// <param name="obj"></param>
        private void MakeDirty(Object obj)
        {
            EditorUtility.SetDirty(obj);
            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        }
    }
}
