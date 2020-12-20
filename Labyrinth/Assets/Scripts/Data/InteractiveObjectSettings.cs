using UnityEngine;


namespace Labyrinth
{
    [CreateAssetMenu(fileName = "InteractiveObjects", menuName = "Data/InteractiveObjects")]
    public class InteractiveObjectSettings : ScriptableObject
    {
        public InteractiveObjectModel[] Objects;
        public GameObject SlowTrapPrefab;
        public GameObject DeathTrapPrefab;
        public GameObject SpeedBoostPrefab;
        public GameObject RequiredKeyPrefab;
        public GameObject InvulnerabilityBostPrefab;
    }
}
