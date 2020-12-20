using UnityEditor;


namespace Labyrinth.Editor
{
    public class MenuItems
    {
        [MenuItem("Лабиринт/Интерактивные объекты")]
        private static void MenuOption()
        {
            EditorWindow.GetWindow(typeof(MyWindow), false, "Интерактивные объекты");
        }
    }
}
