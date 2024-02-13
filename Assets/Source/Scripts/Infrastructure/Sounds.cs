using Agava.WebUtility;
using UnityEngine;

namespace Source.Scripts.Infrastructure
{
    public class Sounds : MonoBehaviour
    {
        [SerializeField] private AudioSource _musicSource;

        private bool _isMuted;

        private void Awake()
        {
            _musicSource.Play();
            _musicSource.Pause();
            DontDestroyOnLoad(this);
        }

        private void OnEnable() => 
            WebApplication.InBackgroundChangeEvent += OnInBackgroundChange;

        private void OnDisable() => 
            WebApplication.InBackgroundChangeEvent -= OnInBackgroundChange;

        public void On()
        {
            _isMuted = false;
            UnPause();
        }

        public void Off()
        {
            _isMuted = true;
            Pause();
        }

        private void OnInBackgroundChange(bool inBackground)
        {
            if (_isMuted) 
                return;

            if(inBackground)
                Pause();
            else
                UnPause();
        }

        private void UnPause()
        {
            _musicSource.UnPause();
            AudioListener.pause = false;
            AudioListener.volume = 1f;
        }

        private void Pause()
        {
            _musicSource.Pause();
            AudioListener.pause = true;
            AudioListener.volume = 0f;
        }

        public void SetVolume(float value)
        {
            _musicSource.volume = value;
        }
    }
}