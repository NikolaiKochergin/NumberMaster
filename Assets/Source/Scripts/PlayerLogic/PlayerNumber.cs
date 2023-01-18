using System;
using Source.Scripts.Data;
using Source.Scripts.Services.PersistentProgress;
using UnityEngine;

namespace Source.Scripts.PlayerLogic
{
    public class PlayerNumber : MonoBehaviour , ISavedProgress
    {
        private State _state;

        public event Action NumberChanged;
        
        

        public int Current
        {
            get => _state.CurrentNumber;
            set
            {
                if (value != _state.CurrentNumber)
                {
                    _state.CurrentNumber = value;
                    
                    NumberChanged?.Invoke();
                }
            }
        }

        public void LoadProgress(PlayerProgress progress)
        {
            _state = progress.PlayerState;
            NumberChanged?.Invoke();
        }

        public void UpdateProgress(PlayerProgress progress) => 
            progress.PlayerState.CurrentNumber = Current;

        public void TakeNumber(int value)
        {
            if(Current <= 0)
                return;

            Current += value;
        }
    }
}
