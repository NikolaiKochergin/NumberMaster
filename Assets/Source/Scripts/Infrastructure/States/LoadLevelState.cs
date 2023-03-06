using Source.Scripts.CameraLogic;
using Source.Scripts.Infrastructure.Factory;
using Source.Scripts.InteractiveObjects.Number;
using Source.Scripts.PlayerLogic;
using Source.Scripts.Services.Ads;
using Source.Scripts.Services.Analytics;
using Source.Scripts.Services.PersistentProgress;
using Source.Scripts.Services.Sound;
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
        private readonly IAdsService _ads;
        private readonly IAnalyticService _analytic;
        private readonly IStaticDataService _staticData;

        public LoadLevelState(GameStateMachine stateMachine, 
            SceneLoader sceneLoader, 
            IGameFactory gameFactory, 
            IPersistentProgressService progressService, 
            IStaticDataService staticData, 
            IUIFactory uiFactory,
            IAdsService ads,
            IAnalyticService analytic)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
            _progressService = progressService;
            _staticData = staticData;
            _uiFactory = uiFactory;
            _ads = ads;
            _analytic = analytic;
        }
        
        public void Enter(string sceneName)
        {
            _gameFactory.Cleanup();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit()
        {
            _ads.ShowInterstitial(_analytic.SendEventOnInterstitialShown);
            _analytic.SendEventOnLevelStart(_progressService.Progress.World.DisplayedLevel);
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
            player.PlayerMove.Disable();
            CameraFollow(player.transform);
            CameraShake(player);
            InitEnemies();

            Resources.UnloadUnusedAssets();
        }

        private void InitEnemies()
        {
            string sceneKey = SceneManager.GetActiveScene().name;
            LevelStaticData levelData = _staticData.ForLevel(sceneKey);

            foreach (EnemyNumbersStaticData enemyNumberData in levelData.EnemyNumbers)
            {
                EnemyNumber number = _gameFactory.CreateEnemyNumber(enemyNumberData.Position, enemyNumberData.Rotation);
                number.Initialize(enemyNumberData.NumberValue);
            }
        }

        private void CameraFollow(Transform player) => 
            Camera.main.GetComponentInParent<CameraFollow>().Follow(player);

        private void CameraShake(Player player) => 
            player.ActorCameraShake.Initialize(Camera.main.GetComponentInParent<CameraShake>());
    }
}