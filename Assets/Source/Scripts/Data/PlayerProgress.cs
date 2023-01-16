using System;

namespace Source.Scripts.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public State PlayerState;

        public PlayerProgress(string initialLevel)
        {
            PlayerState = new State();
        }
    }
}