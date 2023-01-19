using System;

namespace Source.Scripts.Data
{
    [Serializable]
    public class Soft
    {
        public int Collected = 10000;

        public event Action Changed;

        public void Add(int value)
        {
            Collected += value;
            Changed?.Invoke();
        }
    }
}