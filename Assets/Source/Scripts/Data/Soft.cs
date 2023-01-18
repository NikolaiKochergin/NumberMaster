using System;

namespace Source.Scripts.Data
{
    [Serializable]
    public class Soft
    {
        public int Collected;

        public event Action Changed;

        public Soft() => 
            Collected = 0;

        public void Add(int value)
        {
            Collected += value;
            Changed?.Invoke();
        }
    }
}