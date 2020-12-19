using UnityEngine;


namespace Labyrinth
{
    public class MinimapInitializer
    {
        public static GameObject Initialize(MiniMapSettings minimapSettings, GameObject canvas)
        {
            GameObject newMinimap = GameObject.Instantiate(minimapSettings.Minimap);
            newMinimap.transform.parent = canvas.transform;
            var rectTransform = newMinimap.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = minimapSettings.Position;
            return newMinimap;
        }
    }
}
