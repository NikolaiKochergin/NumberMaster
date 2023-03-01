using System.Threading;
using Agava.YandexGames;
using Source.Scripts.LeaderboardLogic;
using Source.Scripts.Services.Leaderboard;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Scripts.UI.Windows.Leaderboard
{
    public class LeaderboardWindow : WindowBase
    {
        [SerializeField] private Button _closeButton;

        
        [SerializeField] private ChallengerView _challengerViewPrefab;
        [SerializeField] private Transform _challangerViewContainer;
        [SerializeField] private GameObject _loadingImage;

        private ILeaderboardService _leaderboardService;
        private CancellationTokenSource _cts = new CancellationTokenSource();

        public void Construct(ILeaderboardService leaderboardService) => 
            _leaderboardService = leaderboardService;
        
        private void Awake() => 
            _closeButton.onClick.AddListener(Close);

        private void Start() => 
            ShowChallengers();

        private void OnDisable() => 
            _cts.Cancel();

        public void ShowChallengers()
        {
            _loadingImage.SetActive(true);
            _leaderboardService.GetLeaderboardEntryResponses(CreateChallengersViews, _cts.Token);
        }

        private void CreateChallengersViews(LeaderboardGetEntriesResponse entries)
        {
            foreach (LeaderboardEntryResponse entry in entries.entries)
            {
                ChallengerView newChallengerView = Instantiate(_challengerViewPrefab, _challangerViewContainer);
                
                newChallengerView.SetRank(entry.rank);
                //newChallengerView.SetAvatar(entry.player.scopePermissions.avatar);
                newChallengerView.SetName(entry.player.publicName);
                newChallengerView.SetScores(entry.score);
            }
            _loadingImage.SetActive(false);
        }
    }
}