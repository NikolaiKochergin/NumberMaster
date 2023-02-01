using Agava.WebUtility;
using UnityEngine;

namespace Source.Scripts.Services.Pause
{
    public class GamePause : IGamePauseService
    {
        public bool IsGameOnPause { get; private set; }
        
        public GamePause() => 
            WebApplication.InBackgroundChangeEvent += OnInBackgroundChange;

        public void On()
        {
            IsGameOnPause = true;
            Time.timeScale = 0.0f;
        }

        public void Off()
        {
            IsGameOnPause = false;
            Time.timeScale = 1.0f;
        }

        private void OnInBackgroundChange(bool inBackground)
        {
            if(!IsGameOnPause)
                Time.timeScale = inBackground ? 0.0f : 1.0f;
        }
    }
}