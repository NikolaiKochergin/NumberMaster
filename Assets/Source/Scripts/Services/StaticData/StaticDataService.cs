using Source.Scripts.StaticData;
using UnityEngine;

namespace Source.Scripts.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private const string GameDataPath = "StaticData/GameData";

        private GameStaticData _gameData;
        
        public void Load() => 
            _gameData = Resources.Load<GameStaticData>(GameDataPath);

        public float ForPlayerSpeed() => 
            _gameData.PlayerSpeed;
    }
}