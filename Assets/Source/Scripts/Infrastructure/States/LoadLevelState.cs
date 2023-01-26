using Source.Scripts.CameraLogic;
using Source.Scripts.Infrastructure.Factory;
using Source.Scripts.PlayerLogic;
using Source.Scripts.Services.PersistentProgress;
using Source.Scripts.Services.StaticData;
using Source.Scripts.StaticData;
using Source.Scripts.UI.Services.Factory;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Source.Scripts.Infrastructure.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly IGameFactory _gameFactory;
        private readonly IPersistentProgressService _progressService;
        private readonly IUIFactory _uiFactory;
        private readonly IStaticDataService _staticData;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, IGameFactory gameFactory, IPersistentProgressService progressService, IStaticDataService staticData, IUIFactory uiFactory)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
            _progressService = progressService;
            _staticData = staticData;
            _uiFactory = uiFactory;
        }
        
        public void Enter(string sceneName)
        {
            _gameFactory.Cleanup();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit()
        {
        }

        private void OnLoaded()
        {
            InitUIRoot();
            InitGameWorld();
            InformProgressReaders();
            
            _stateMachine.Enter<ShopState>();
        }

        private void InitUIRoot()
        {
            _uiFactory.InitUIRoot();
            _uiFactory.CreateGameLoopWindow();
        }

        private void InformProgressReaders()
        {
            foreach (ISavedProgressReader progressReader in _gameFactory.ProgressReaders)
                progressReader.LoadProgress(_progressService.Progress);
        }

        private void InitGameWorld()
        {
            Player player = _gameFactory.CreatePlayer();
            CameraFollow(player.transform);
            CameraShake(player);
            InitEnemies();
        }

        private void InitEnemies()
        {
            string sceneKey = SceneManager.GetActiveScene().name;
            LevelStaticData levelData = _staticData.ForLevel(sceneKey);

            foreach (EnemyNumbersStaticData enemyNumberData in levelData.EnemyNumbers)
                _gameFactory.CreateEnemyNumber(enemyNumberData.NumberValue, enemyNumberData.Position, enemyNumberData.Rotation);
        }

        private void CameraFollow(Transform player) => 
            Camera.main.GetComponentInParent<CameraFollow>().Follow(player);

        private void CameraShake(Player player) => 
            player.ActorCameraShake.Initialize(Camera.main.GetComponentInParent<CameraShake>());
    }
}