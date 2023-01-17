using System;

namespace Source.Scripts.Data
{
    [Serializable]
    public class State
    {
        public int CurrentNumber;
        public int IncomeLevel;
        public int StartNumber;

        public void ResetHP()
        {
            CurrentNumber = StartNumber;
        }
    }
}