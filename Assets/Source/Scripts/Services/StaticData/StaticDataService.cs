using UnityEngine;

namespace Source.Scripts.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        public void Load()
        {
            Debug.Log("Загрузка статик даты");
        }
    }
}