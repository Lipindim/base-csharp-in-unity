using UnityEngine;


namespace Labyrinth
{

    [CreateAssetMenu(fileName = "RadarSettings", menuName = "Data/RadarSettings")]
    public class RadarSettings : ScriptableObject
    {
        public float Scale;
        public float Radius;
    }
}
