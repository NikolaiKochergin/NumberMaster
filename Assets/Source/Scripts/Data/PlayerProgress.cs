using System;

namespace Source.Scripts.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public State PlayerState;
        public Stats PlayerStats;
        public Soft Soft;
        public World World;
        public GameSettings GameSettings;

        public PlayerProgress()
        {
            PlayerState = new State();
            PlayerStats = new Stats();
            Soft = new Soft();
            World = new World();
        }
    }
}