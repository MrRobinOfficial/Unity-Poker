using UnityEngine;
using UnityEngine.Audio;

namespace UnityPoker.Framework.Managers
{
    /// <summary>
    /// <see cref="AudioManager"/> is responsible to handle audio system.
    /// </summary>
    [AddComponentMenu("Framework/Managers/Audio [Manager]")]
    [RequireComponent(typeof(AppManager))]
    public class AudioManager : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] AudioMixer m_Mixer = null;
        [SerializeField] AudioMixerGroup m_SFXGroup = null;
        [SerializeField] AudioMixerGroup m_MusicGroup = null;
        [SerializeField] AudioClip[] m_Songs = null;

        [SerializeField, Range(0.0f, 1.0f)]
        private float m_MasterVolume = 1.0f;

        [SerializeField, Range(0.0f, 1.0f)]
        private float m_MusicVolume = 0.7f;

        [SerializeField, Range(0.0f, 1.0f)]
        private float m_SFXVolume = 0.9f;

        public float MasterVolume
        {
            get => m_MasterVolume;
            set => m_MasterVolume = Mathf.Clamp01(value);
        }

        public float MusicVolume
        {
            get => m_MusicVolume;
            set => m_MusicVolume = Mathf.Clamp01(value);
        }

        public float SFXVolume
        {
            get => m_SFXVolume;
            set => m_SFXVolume = Mathf.Clamp01(value);
        }

        private AudioSource m_MusicSource;
        private AudioSource m_SFXSource;
        private bool m_IsPlayingMusic = false;

        private void Start()
        {
            m_MusicSource = gameObject.AddComponent<AudioSource>();
            m_MusicSource.outputAudioMixerGroup = m_MusicGroup;

            m_SFXSource = gameObject.AddComponent<AudioSource>();
            m_SFXSource.outputAudioMixerGroup = m_SFXGroup;

            PlayMusic();
        }

        [ContextMenu(itemName: "Music/Play",
            isValidateFunction: false, priority: 10000100)]
        public void PlayMusic()
        {
            if (m_IsPlayingMusic)
                return;

            AudioClip selectedSong = null;

            do
            {
                var index = Random.Range(0, m_Songs.Length);
                selectedSong = m_Songs[index];
            } while (selectedSong == null || selectedSong == m_MusicSource.clip);

            var pauseTime = Random.Range(0.5f, 1.5f);
            Invoke(nameof(PlayMusic), selectedSong.length + pauseTime);

            m_MusicSource.clip = selectedSong;
            m_MusicSource.Play();
            m_IsPlayingMusic = true;
        }

        [ContextMenu(itemName: "Music/Stp",
            isValidateFunction: false, priority: 10000100)]
        public void StopMusic()
        {
            if (!m_IsPlayingMusic)
                return;

            m_MusicSource.Stop();
            m_IsPlayingMusic = false;
        }
    }
}