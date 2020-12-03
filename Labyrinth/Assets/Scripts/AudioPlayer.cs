using UnityEngine;


namespace Labyrinth
{
    public class AudioPlayer : MonoBehaviour
    {
        [SerializeField] private AudioSource _speedBostAudio;
        [SerializeField] private AudioSource _invulnerabilityBostAudio;
        [SerializeField] private AudioSource _keyAudio;
        [SerializeField] private AudioSource _slowTrapAudio;
        [SerializeField] private AudioSource _deathTrapAudio;

        private Player _player;

        private void Start()
        {
            if (_speedBostAudio == null)
                throw new PrefabNotFoundException(nameof(_speedBostAudio));
            if (_invulnerabilityBostAudio == null)
                throw new PrefabNotFoundException(nameof(_invulnerabilityBostAudio));
            if (_keyAudio == null)
                throw new PrefabNotFoundException(nameof(_keyAudio));
            if (_slowTrapAudio == null)
                throw new PrefabNotFoundException(nameof(_slowTrapAudio));
            if (_deathTrapAudio == null)
                throw new PrefabNotFoundException(nameof(_deathTrapAudio));

            var interactiveObjects = FindObjectsOfType<InteractiveObject>();
            foreach (var interactiveObject in interactiveObjects)
                interactiveObject.OnInteraction += InteractiveObjectOnInteraction;

            _player = FindObjectOfType<Player>();
            if (_player == null)
                throw new PlayerNotFoundException();
        }

        private void InteractiveObjectOnInteraction(InteractiveObject interactiveObject)
        {
            if (interactiveObject is SpeedBost speedBost)
            {
                _speedBostAudio.Play();
            }
            if (interactiveObject is InvulnerabilityBost invulnerabilityBost)
            {
                _invulnerabilityBostAudio.Play();
            }
            if (interactiveObject is RequiredKey requiredKey)
            {
                _keyAudio.Play();
            }

            if (!_player.IsInvulnerability)
            {
                if (interactiveObject is SlowTrap slowTrap)
                {
                    _slowTrapAudio.Play();
                }
                if (interactiveObject is DeathTrap deathTrap)
                {
                    _deathTrapAudio.Play();
                }
            }
        }
    }
}