using System;
using System.Collections.Generic;
using UnityEngine;


namespace Labyrinth
{
    public class AudioPlayer
    {

        #region Fields

        private PlayerModel _playerModel;
        private AudioData _audioData;
        private AudioSource _audioSource;

        #endregion


        #region ClassLifeCycles

        public AudioPlayer(AudioData audioData, IEnumerable<InteractiveObject> interactiveObjects, PlayerModel playerModel, AudioSource audioSource)
        {
            if (audioData == null)
                throw new ArgumentNullException(nameof(audioData));
            if (interactiveObjects == null)
                throw new ArgumentNullException(nameof(interactiveObjects));
            if (playerModel == null)
                throw new ArgumentNullException(nameof(playerModel));
            if (audioSource == null)
                throw new ArgumentNullException(nameof(audioSource));

            if (audioData.SpeedBostAudio == null)
                throw new PrefabNotFoundException(nameof(audioData.SpeedBostAudio));
            if (audioData.InvulnerabilityBostAudio == null)
                throw new PrefabNotFoundException(nameof(audioData.InvulnerabilityBostAudio));
            if (audioData.KeyAudio == null)
                throw new PrefabNotFoundException(nameof(audioData.KeyAudio));
            if (audioData.SlowTrapAudio == null)
                throw new PrefabNotFoundException(nameof(audioData.SlowTrapAudio));
            if (audioData.DeathTrapAudio == null)
                throw new PrefabNotFoundException(nameof(audioData.DeathTrapAudio));

            _audioData = audioData;
            _playerModel = playerModel;
            _audioSource = audioSource;
            foreach (var interactiveObject in interactiveObjects)
                interactiveObject.OnInteraction += InteractiveObjectOnInteraction;
        }

        #endregion


        #region Methods
        private void InteractiveObjectOnInteraction(InteractiveObject interactiveObject)
        {
            if (interactiveObject is SpeedBost speedBost)
            {
                _audioSource.PlayOneShot(_audioData.SpeedBostAudio);
            }
            if (interactiveObject is InvulnerabilityBost invulnerabilityBost)
            {
                _audioSource.PlayOneShot(_audioData.InvulnerabilityBostAudio);
            }
            if (interactiveObject is RequiredKey requiredKey)
            {
                _audioSource.PlayOneShot(_audioData.KeyAudio);
            }

            if (!_playerModel.IsInvulnerability)
            {
                if (interactiveObject is SlowTrap slowTrap)
                {
                    _audioSource.PlayOneShot(_audioData.SlowTrapAudio);
                }
                if (interactiveObject is DeathTrap deathTrap)
                {
                    _audioSource.PlayOneShot(_audioData.DeathTrapAudio);
                }
            }
        }
        #endregion

    }
}