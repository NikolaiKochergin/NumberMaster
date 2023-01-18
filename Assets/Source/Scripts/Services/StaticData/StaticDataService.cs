using System.Collections.Generic;
using System.Linq;
using Source.Scripts.StaticData;
using Source.Scripts.StaticData.Windows;
using Source.Scripts.UI.Services.Windows;
using UnityEngine;

namespace Source.Scripts.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private const string GameDataPath = "StaticData/GameData";
        private const string StaticDataWindowPath = "StaticData/UI/WindowStaticData";

        private GameStaticData _gameData;
        private Dictionary<WindowId, WindowConfig> _windowConfigs;

        public void Load()
        {
            _gameData = Resources
                .Load<GameStaticData>(GameDataPath);

            _windowConfigs = Resources
                .Load<WindowStaticData>(StaticDataWindowPath)
                .Configs
                .ToDictionary(x => x.WindowId, x => x);
        }


        public float ForPlayerSpeed() => 
            _gameData.PlayerSpeed;

        public float ForMouseSensitivity() => 
            _gameData.MouseSensitivity;

        public float ForKeyboardSensitivity() => 
            _gameData.KeyboardSensitivity;

        public WindowConfig ForWindow(WindowId windowId) =>
            _windowConfigs.TryGetValue(windowId, out WindowConfig windowConfig)
                ? windowConfig
                : null;
    }
}