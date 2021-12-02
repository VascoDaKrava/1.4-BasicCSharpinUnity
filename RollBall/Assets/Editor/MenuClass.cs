using UnityEditor;

namespace Kravchuk
{
    public sealed class MenuClass
    {
        [MenuItem("Kravchuk/Instantiate pickups")]
        private static void MenuOption()
        {
            EditorWindow.GetWindow(typeof(WindowClass), false, "Pickups");
        }
    }
}
