using System;

namespace Source.Scripts.Data
{
    [Serializable]
    public class Soft
    {
        public int Collected = 0;

        public event Action Changed;

        public void Add(int value)
        {
            Collected += value;
            Changed?.Invoke();
        }
    }
}