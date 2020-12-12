

using UnityEngine;

namespace Labyrinth
{

    public class PlayerModel
    {
        public float InitialSpeed
        {
            get
            {
                return _initialSpeed;
            }
        }

        public float CurrentSpeed
        {
            get
            {
                return _speed;
            }
        }

        public bool IsInvulnerability
        {
            get
            {
                return _isInvulnerability;
            }
        }

        private float _speed;
        private float _initialSpeed;
        private bool _isInvulnerability;


        public PlayerModel(PlayerData playerData)
        {
            _speed = playerData.Speed;
            _initialSpeed = _speed;
            Debug.Log(_initialSpeed);
        }

        public void SetSpeed(float speed, float time)
        {
            _speed = speed;
        }

        public void SetInvulnerability()
        {
            _isInvulnerability = true;
        }

        public void ResetSpeed()
        {
            _speed = _initialSpeed;
        }

        public void ResetInvulnerability()
        {
            _isInvulnerability = false;
        }
    }
}
