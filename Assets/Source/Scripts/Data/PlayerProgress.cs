using System;

namespace Source.Scripts.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public State PlayerState;
        public Stats PlayerStats;

        public PlayerProgress()
        {
            PlayerState = new State();
            PlayerStats = new Stats();
        }
    }
}