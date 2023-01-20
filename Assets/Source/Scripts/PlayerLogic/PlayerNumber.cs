using System;
using Source.Scripts.Data;
using Source.Scripts.Services.PersistentProgress;
using UnityEngine;

namespace Source.Scripts.PlayerLogic
{
    public class PlayerNumber : MonoBehaviour , ISavedProgress
    {
        private State _state;
        private bool _isFail;

        public event Action NumberChanged;
        public event Action FailHappened;

        public int Current
        {
            get => _state.CurrentNumber;
            private set
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
            Current = progress.PlayerStats.StartNumber;
            NumberChanged?.Invoke();
        }

        public void UpdateProgress(PlayerProgress progress) => 
            progress.PlayerState.CurrentNumber = Current;

        public void TakeNumber(int value)
        {
            if(_isFail)
                return;

            if (Current + value < 0 || Current < value)
            {
                SetFail();
                return;
            }

            Current += value;
        }

        private void SetFail()
        {
            _isFail = true;
            FailHappened?.Invoke();
        }
    }
}
