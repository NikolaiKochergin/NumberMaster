using System.Collections.Generic;
using Source.Scripts.Infrastructure.AssetManagement;
using Source.Scripts.Infrastructure.States;
using Source.Scripts.InteractiveObjects.Number;
using Source.Scripts.PlayerLogic;
using Source.Scripts.Services.Input;
using Source.Scripts.Services.PersistentProgress;
using Source.Scripts.Services.StaticData;
using UnityEngine;

namespace Source.Scripts.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly IInputService _input;
        private readonly IAssetProvider _assets;
        private readonly IStaticDataService _staticData;

        public Player Player { get; private set; }

        public GameFactory(IGameStateMachine stateMachine, IInputService input, IAssetProvider assets, IStaticDataService staticData)
        {
            _stateMachine = stateMachine;
            _input = input;
            _assets = assets;
            _staticData = staticData;
        }

        public List<ISavedProgressReader> ProgressReaders { get; } = new List<ISavedProgressReader>();
        public List<ISavedProgress> ProgressWriters { get; } = new List<ISavedProgress>();

        public Player CreatePlayer()
        {
            Player = InstantiateRegistered<Player>(AssetPath.PlayerPath);
            Player.PlayerMove.Construct(_input, _staticData);
            Player.ActorFail.Construct(_stateMachine);
            Player.ActorFall.Construct(_stateMachine);
            Player.ActorEndLevel.Construct(_stateMachine);
            Player.PlayerMove.Disable();
            
            return Player;
        }

        public void CreateEnemyNumber(int numberValue, Vector3 position, Quaternion rotation)
        {
            EnemyNumber number = _assets.Instantiate<EnemyNumber>(AssetPath.EnemyNumberPath, position, rotation);
            
            
            number.Construct(Player.PlayerNumber);
            number.Initialize(numberValue);
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