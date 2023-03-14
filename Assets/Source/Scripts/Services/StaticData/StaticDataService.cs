using System.Collections.Generic;
using System.Linq;
using Lean.Localization;
using Source.Scripts.Services.IAP;
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
        private const string LevelDataPath = "StaticData/LevelData";

        private GameStaticData _gameData;
        private Dictionary<WindowId, WindowConfig> _windowConfigs;
        private Dictionary<string, LevelStaticData> _levels;
        private Dictionary<PurchaseType, PurchaseConfig> _purchases;

        public void Load()
        {
            _gameData = Resources
                .Load<GameStaticData>(GameDataPath);

            _purchases = _gameData.Purchases.ToDictionary(x => x.Type, x => x);

            _windowConfigs = Resources
                .Load<WindowStaticData>(StaticDataWindowPath)
                .Configs
                .ToDictionary(x => x.WindowId, x => x);

            _levels = Resources
                .LoadAll<LevelStaticData>(LevelDataPath)
                .ToDictionary(x => x.LevelKey, x => x);
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

        public string ForSceneName(int index) =>
            index >= 0 && index < _gameData.LevelSceneNames.Count
                ? _gameData.LevelSceneNames[index]
                : null;

        public LevelStaticData ForLevel(string sceneKey) =>
            _levels.TryGetValue(sceneKey, out LevelStaticData staticData)
                ? staticData
                : null;

        public int ForRepeatLevelNumber() =>
            _gameData.RepeatLevelNumber;

        public PurchaseConfig ForPurchase(PurchaseType type) =>
            _purchases.TryGetValue(type, out PurchaseConfig purchaseConfig)
                ? purchaseConfig
                : null;

        public string ForLeaderboardName() => 
            _gameData.LeaderboardName;

        public LeanLocalization ForLocalization() =>
            _gameData.Localization;
    }
}