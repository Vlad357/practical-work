using UnityEngine;

namespace Platformer
{
    public class AudioObject : MonoBehaviour
    {
        private AudioSource _audioSource;
        private AudioSettings _audioSettings;

        public void SetVolume(float volume)
        {
            _audioSource.volume = volume;
        }

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            _audioSettings = FindObjectOfType<AudioSettings>();

            if (gameObject.CompareTag("music"))
            {
                _audioSource.volume = _audioSettings.musicVolume;
            }
            else if (gameObject.CompareTag("sound"))
            {
                _audioSource.volume = _audioSettings.soundVolume;
            }
        }
    }
}