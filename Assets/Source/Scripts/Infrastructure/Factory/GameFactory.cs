using System.Collections.Generic;
using Source.Scripts.Infrastructure.AssetManagement;
using Source.Scripts.PlayerLogic;
using Source.Scripts.Services.Input;
using Source.Scripts.Services.PersistentProgress;
using Source.Scripts.Services.StaticData;
using Source.Scripts.UI.Services.Windows;
using UnityEngine;

namespace Source.Scripts.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IInputService _input;
        private readonly IAssetProvider _assets;
        private readonly IStaticDataService _staticData;
        private readonly IPersistentProgressService _persistentProgressService;
        private readonly IWindowService _windowService;

        public Player Player { get; private set; }

        public GameFactory(IInputService input, IAssetProvider assets, IStaticDataService staticData, IPersistentProgressService persistentProgressService, IWindowService windowService)
        {
            _input = input;
            _assets = assets;
            _staticData = staticData;
            _persistentProgressService = persistentProgressService;
            _windowService = windowService;
        }

        public List<ISavedProgressReader> ProgressReaders { get; } = new List<ISavedProgressReader>();
        public List<ISavedProgress> ProgressWriters { get; } = new List<ISavedProgress>();


        public Player CreatePlayer()
        {
            Player = InstantiateRegistered<Player>(AssetPath.PlayerPath);
            Player.PlayerMove.Construct(_input, _staticData);
            Player.PlayerMove.Disable();
            
            return Player;
        }

        public void Cleanup()
        {
            ProgressReaders.Clear();
            ProgressWriters.Clear();
        }

        private T InstantiateRegistered<T>(string prefabPath) where T : Object , ISavedProgressReader
        {
            T gameObject = _assets.Instantiate<T>(prefabPath);
            Register(gameObject);

            return gameObject;
        }

        private void Register(ISavedProgressReader progressReader)
        {
            if(progressReader is ISavedProgress progressWriter)
                ProgressWriters.Add(progressWriter);
            
            ProgressReaders.Add(progressReader);
        }
    }
}