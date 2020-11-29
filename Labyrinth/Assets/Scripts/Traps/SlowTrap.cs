using UnityEngine;

namespace Labyrinth
{

    public class SlowTrap : InteractiveObject
    {
        public float SpeedMultiplier
        {
            get
            {
                return _speedMultiplier;
            }
        }

        [SerializeField] private float _speedMultiplier = 0.5f;
    }
}
