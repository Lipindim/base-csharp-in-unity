using UnityEngine;


namespace Labyrinth
{
    public class SpeedBost : InteractiveObject
    {

        #region Fields

        [SerializeField] private float _speedMultiplier = 2.0f;
        [SerializeField] private float _bostDuration = 5.0f;

        #endregion


        #region Properties

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

        public override InteractiveObjectEnum Type => InteractiveObjectEnum.SpeedBost;

        #endregion

    }
}
