using UnityEngine;


namespace Labyrinth
{
    [CreateAssetMenu(fileName = "CameraSettings", menuName = "Data/CameraSettings")]
    public class CameraSettings : ScriptableObject
    {
        public Vector3 CameraOffset;
    }
}
