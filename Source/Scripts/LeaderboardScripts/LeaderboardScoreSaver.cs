using Agava.YandexGames;
using Source.Scripts.Services;
using Source.Scripts.Services.PersistentProgress;
using UnityEngine;

namespace Source.Scripts.LeaderboardScripts
{
    public class LeaderboardScoreSaver : MonoBehaviour
    {
        [SerializeField] private float _timeBetweenSaves;

        private int _totalScore;
        private int _lastSavedScore;
        private IPersistentProgressService _progressService;

        private void Awake()
        {
            _progressService = AllServices.Container.Single<IPersistentProgressService>();
        }

        public void Load()
        {
            _totalScore = _progressService.Progress.World.DisplayedLevel;

            _lastSavedScore = _totalScore;
        }

        public void StashScore(int score)
        {
            _totalScore = _progressService.Progress.World.DisplayedLevel;
            Save();
        }

        private void OnCompleted()
        {
            Save();
        }

        private void Save()
        {
        if (PlayerAccount.IsAuthorized && _lastSavedScore != _totalScore)
        {
            Leaderboard.SetScore(LeaderboardName.Name, _totalScore);
            _lastSavedScore = _totalScore;
        }
#if !UNITY_EDITOR && UNITY_WEBGL
#endif
        }
    }
}