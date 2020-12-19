using UnityEngine;
using UnityEngine.UI;


namespace Labyrinth
{
    public class RadarModel
    {
        public GameObject Owner { get; set; }
        public Image Ico { get; set; }
        public RadarObject Object { get; set; }
        public RectTransform Transform { get; set; }
    }
}
