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

        [SerializeField] private float _speedMultiplier = 2.0f;
    }
}
