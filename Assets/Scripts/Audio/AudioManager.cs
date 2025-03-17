// Assets/Scripts/Audio/AudioManager.cs
using UnityEngine;

namespace Bomb_Roulette.Audio
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance;
        public AudioSource bgmSource;
        public AudioSource sfxSource;

        public AudioClip[] bgmClips;
        public AudioClip[] sfxClips;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void PlayBGM(int index)
        {
            if (index >= 0 && index < bgmClips.Length)
            {
                bgmSource.clip = bgmClips[index];
                bgmSource.Play();
            }
        }

        public void PlaySFX(int index)
        {
            if (index >= 0 && index < sfxClips.Length)
            {
                sfxSource.PlayOneShot(sfxClips[index]);
            }
        }
    }
}
