using Agava.WebUtility;
using UnityEngine;

namespace Source.Scripts.Infrastructure
{
    public class Sounds : MonoBehaviour
    {
        [SerializeField] private AudioSource _musicSource;

        public bool IsOn { get; private set; }

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
            IsOn = true;
            _musicSource.UnPause();
            AudioListener.pause = false;
            AudioListener.volume = 1f;
        }

        public void Off()
        {
            IsOn = false;
            _musicSource.Pause();
            AudioListener.pause = true;
            AudioListener.volume = 0f;
        }

        private void OnInBackgroundChange(bool inBackground)
        {
            if (!IsOn) return;

            if(inBackground)
                Off();
            else
                On();
        }
    }
}