using UnityEngine;


namespace Labyrinth
{

    [CreateAssetMenu(fileName = "AudioData", menuName = "Data/AudioData")]
    public class AudioData : ScriptableObject
    {
        public AudioClip SpeedBostAudio;
        public AudioClip InvulnerabilityBostAudio;
        public AudioClip KeyAudio;
        public AudioClip SlowTrapAudio;
        public AudioClip DeathTrapAudio;
    }

}
