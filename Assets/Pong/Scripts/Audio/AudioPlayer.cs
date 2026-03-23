using System.Collections.Generic;
using UnityEngine;

namespace Pong.Audio
{
    public class AudioPlayer : MonoBehaviour
    {
        [SerializeField, Range(0f, 1f)] private float _initialVolume = 1f;

        [SerializeField] private AudioSource _sfxAudioSource;
        [SerializeField] private AudioSource _backgroundAudioSource;        
        
        [SerializeField] private SFXEntry[] _sfxEntries;
        private Dictionary<SFXType, AudioClip> _clipsDictionary;

        private static AudioPlayer _instance;

        private static float _currentVolume;
        public static float CurrentVolume => _currentVolume;

        private void Awake()
        {
            if(_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
                return;
            }

            _instance = this;
            DontDestroyOnLoad(this.gameObject);

            CreateDictionary();                                   
        }

        private void CreateDictionary()
        {
            _clipsDictionary = new Dictionary<SFXType, AudioClip>();

            foreach (var entry in _sfxEntries)
            {
                if (_clipsDictionary.ContainsKey(entry.Type))
                {
                    Debug.LogWarning($"Duplicate SFXType: {entry.Type}");
                    continue;
                }

                _clipsDictionary.Add(entry.Type, entry.Clip);
            }
        }

        private void OnEnable()
        {
            AudioEvents.PlaySFX += PlaySFXClip;
            AudioEvents.ChangeVolume += ChangeVolume;
        }

        private void OnDisable()
        {
            AudioEvents.PlaySFX -= PlaySFXClip;
            AudioEvents.ChangeVolume -= ChangeVolume;
        }

        private void Start()
        {
            _currentVolume = _initialVolume;
            UpdateAudioSourcesVolume();
            
        }

        private void PlaySFXClip(SFXType SFX_type)
        {
            if (!_clipsDictionary.TryGetValue(SFX_type, out AudioClip clip))
            {
                Debug.LogWarning($"No clip for {SFX_type}");
                return;
            }

            _sfxAudioSource.PlayOneShot(clip);
        }

        private void ChangeVolume(float volumeMod)
        {
            _currentVolume += volumeMod;
            _currentVolume = Mathf.Clamp01(_currentVolume);
            UpdateAudioSourcesVolume();
        }

        private void UpdateAudioSourcesVolume()
        {
            _sfxAudioSource.volume = _currentVolume;
            _backgroundAudioSource.volume = _currentVolume;
        }

    }
}

