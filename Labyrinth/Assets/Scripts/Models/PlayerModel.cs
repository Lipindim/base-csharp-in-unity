namespace Labyrinth
{

    public class PlayerModel
    {

        #region Fields

        private float _speed;
        private float _initialSpeed;
        private bool _isInvulnerability;

        #endregion


        #region Properties

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

        #endregion


        #region ClassLifeCycles

        public PlayerModel(PlayerData playerData)
        {
            _speed = playerData.Speed;
            _initialSpeed = _speed;
        }

        #endregion


        #region Methods

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

        #endregion

    }
}
