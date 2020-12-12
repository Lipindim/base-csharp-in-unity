using UnityEngine;


namespace Labyrinth
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Data/PlayerData")]
    public class PlayerData : ScriptableObject
    {
        public GameObject Prefab;
        public float Speed;
        public Vector3 StartPosition;
    }
}
