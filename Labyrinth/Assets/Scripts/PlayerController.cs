using UnityEngine;


namespace Labyrinth
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _effectDuration = 5.0f;

        private Player _player;

        void Start()
        {
            _player = FindObjectOfType<Player>();

            var interactiveObjects = FindObjectsOfType<InteractiveObject>();
            foreach (var interactiveObject in interactiveObjects)
                interactiveObject.OnInteraction += InteractiveObject_OnInteraction1;
        }

        private void InteractiveObject_OnInteraction1(InteractiveObject interactiveObject)
        {
            if (interactiveObject is SpeedBost speedBost)
            {
                Debug.Log("Ускорен!");
                float newSpeed = _player.InitialSpeed * speedBost.SpeedMultiplier;
                _player.SetTemporarySpeed(newSpeed, _effectDuration);
            }
            if (interactiveObject is InvulnerabilityBost invulnerabilityBost)
            {
                Debug.Log("Неуязвим!");
                _player.SetTemporaryInvulnerability(_effectDuration);
            }

            if (!_player.IsInvulnerability)
            {
                if (interactiveObject is SlowTrap slowTrap)
                {
                    Debug.Log("Замедлен!");
                    float newSpeed = _player.InitialSpeed * slowTrap.SpeedMultiplier;
                    _player.SetTemporarySpeed(newSpeed, _effectDuration);
                }
                if (interactiveObject is DeathTrap deathTrap)
                {
                    //конец игры
                    Debug.Log("Смерть!");
                }
            }
        }
    }
}
