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

        public float TrapDuration
        {
            get
            {
                return _trapDuration;
            }
        }


        [SerializeField] private float _speedMultiplier = 0.5f;
        [SerializeField] private float _trapDuration = 5.0f;

    }
}
