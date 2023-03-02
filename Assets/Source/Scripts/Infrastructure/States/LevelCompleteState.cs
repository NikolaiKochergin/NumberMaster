using Source.Scripts.Analytics;
using Source.Scripts.Infrastructure.Factory;
using Source.Scripts.Services.Analytics;
using Source.Scripts.Services.Leaderboard;
using Source.Scripts.Services.PersistentProgress;
using Source.Scripts.Services.SaveLoad;
using Source.Scripts.Services.StaticData;
using UnityEngine;

namespace Source.Scripts.Infrastructure.States
{
    public class LevelCompleteState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IPersistentProgressService _progressService;
        private readonly IStaticDataService _staticDataService;
        private readonly ISaveLoadService _saveLoadService;
        private readonly IGameFactory _factory;
        private readonly IAnalyticService _analytic;
        private readonly ILeaderboardService _leaderboardService;

        public LevelCompleteState(GameStateMachine stateMachine, 
            IPersistentProgressService progressService, 
            IStaticDataService staticDataService,
            ISaveLoadService saveLoadService,
            IGameFactory factory,
            IAnalyticService analytic,
            ILeaderboardService leaderboardService)
        {
            _stateMachine = stateMachine;
            _progressService = progressService;
            _staticDataService = staticDataService;
            _saveLoadService = saveLoadService;
            _factory = factory;
            _analytic = analytic;
            _leaderboardService = leaderboardService;
        }

        public void Enter()
        {
            int collected = Mathf.FloorToInt(CalculateCollected());
            _progressService.Progress.Soft.Collected += collected;
            _leaderboardService.SetScore(_progressService.Progress.World.DisplayedLevel);
            
            SendAnalytics(collected);
            SetNextLevelIndex();
            _saveLoadService.SaveProgress();
            _stateMachine.Enter<LoadLevelState, string>(_staticDataService.ForSceneName(_progressService.Progress.World.CurrentLevel));
        }

        public void Exit()
        {
        }

        private float CalculateCollected() => 
            _factory.Player.PlayerNumber.Current * _progressService.Progress.PlayerStats.Income;

        private void SendAnalytics(float collected)
        {
            _analytic.SendEventOnResourceReceived(
                AnalyticNames.Soft,
                (int) collected,
                AnalyticNames.RewardAd,
                AnalyticNames.LevelComplete);

            _analytic.SendEventOnLevelComplete(_progressService.Progress.World.CurrentLevel);
        }

        private void SetNextLevelIndex()
        {
            _progressService.Progress.World.DisplayedLevel += 1;
            if (_staticDataService.ForSceneName(_progressService.Progress.World.CurrentLevel + 1) == null)
                _progressService.Progress.World.CurrentLevel = _staticDataService.ForRepeatLevelNumber();
            else
                _progressService.Progress.World.CurrentLevel += 1;
        }
    }
}