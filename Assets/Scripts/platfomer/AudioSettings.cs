using UnityEngine;

namespace Platformer
{
    public class AudioSettings : MonoBehaviour
    {
        private const float _maxVolume = 1.0f;

        public float musicVolume
        {
            get
            {
                return PlayerPrefs.GetFloat("musicVolume", _maxVolume);
            }
            set
            {
                PlayerPrefs.SetFloat("musicVolume", value);
                SetMusicVolume(value);
            }
        }

        public float soundVolume
        {
            get
            {
                return PlayerPrefs.GetFloat("soundVolume", _maxVolume);
            }
            set
            {
                PlayerPrefs.SetFloat("soundVolume", value);
                SetSoundsVolume(value);
            }
        }

        public void SetMusicVolume(float volume)
        {
            FindAudioObjectsAndSetVolume("music", volume);
        }

        public void SetSoundsVolume(float volume)
        {
            FindAudioObjectsAndSetVolume("sound", volume);
        }

        private void FindAudioObjectsAndSetVolume(string tag, float volume)
        {
            AudioObject[] audios = FindObjectsOfType<AudioObject>();

            foreach (AudioObject audio in audios)
            {
                if (audio.gameObject.CompareTag(tag))
                {
                    audio.SetVolume(volume);
                }
            }
        }
    }
}