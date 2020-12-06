using UnityEngine;

namespace Labyrinth
{
    public class SpeedBost : InteractiveObject
    {
        public float SpeedMultiplier
        {
            get
            {
                return _speedMultiplier;
            }
        }

        public float BostDuration
        {
            get
            {
                return _bostDuration;
            }
        }

        [SerializeField] private float _speedMultiplier = 2.0f;
        [SerializeField] private float _bostDuration = 5.0f;
    }
}
