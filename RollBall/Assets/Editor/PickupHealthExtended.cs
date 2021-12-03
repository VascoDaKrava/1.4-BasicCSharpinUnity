using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Kravchuk
{
    [CustomEditor(typeof(PickupHealth))]
    public sealed class PickupHealthExtended : Editor
    {
        private Vector3 _position;
        private Vector3 _scale;

        private PickupHealth _pickupHealth;

        private void OnEnable()
        {
            _pickupHealth = (PickupHealth)target;
            _position = _pickupHealth.transform.position;
            _scale = _pickupHealth.transform.localScale;
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            EditorGUILayout.Space(20f);
            if (GUILayout.Button($"Simulate Update"))
            {
                _pickupHealth.DoItInUpdate();

                // Mark scene as modified/Dirty
                EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
            }

            EditorGUILayout.Separator();

            if (GUILayout.Button($"Restore"))
            {
                _pickupHealth.transform.position = _position;
                _pickupHealth.transform.localScale = _scale;
                _pickupHealth.transform.rotation = Quaternion.identity;
            }
            EditorGUILayout.Space(20f);
        }
    }
}
