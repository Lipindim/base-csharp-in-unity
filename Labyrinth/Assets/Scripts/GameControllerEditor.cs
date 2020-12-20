using UnityEditor;


namespace Labyrinth
{
    [CustomEditor(typeof(GameController))]
    public class GameControllerEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            GameController testTarget = (GameController)target;

            testTarget.count = EditorGUILayout.IntSlider(testTarget.count, 10, 50);
        }

    }
}
