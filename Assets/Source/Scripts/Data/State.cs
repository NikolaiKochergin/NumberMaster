using System;

namespace Source.Scripts.Data
{
    [Serializable]
    public class State
    {
        public int CurrentHP;
        public int StartHP;

        public void ResetHP()
        {
            CurrentHP = StartHP;
        }
    }
}