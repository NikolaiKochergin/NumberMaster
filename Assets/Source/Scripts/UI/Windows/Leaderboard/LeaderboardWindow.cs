using Agava.YandexGames;
using Source.Scripts.Services.Leaderboard;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Scripts.UI.Windows.Leaderboard
{
    public class LeaderboardWindow : WindowBase
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private ChallengerView _challengerViewPrefab;
        [SerializeField] private Transform _challengerViewContainer;
        [SerializeField] private AuthorizationMenu _authorizationMenu;

        private ILeaderboardService _leaderboardService;
        
        public void Construct(ILeaderboardService leaderboardService) => 
            _leaderboardService = leaderboardService;

        protected override void Initialize()
        {
#if YANDEX_GAMES && !UNITY_EDITOR
            if (PlayerAccount.IsAuthorized)
                ShowChallengers();
            else
#endif
                ShowAuthorizationMenu();
        }

        private void ShowAuthorizationMenu()
        {
            _authorizationMenu.Show();
            _authorizationMenu.PlayerAuthorized += PlayerAuthorized;
        }

        protected override void SubscribeUpdates()
        {
            _closeButton.onClick.AddListener(Close);
        }

        private void ShowChallengers()
        {
            LeaderboardGetEntriesResponse entries = _leaderboardService.LeaderboardEntries;
            if (entries != null) 
                CreateChallengersViews(entries);
        }

        private void PlayerAuthorized()
        {
            _authorizationMenu.PlayerAuthorized -= PlayerAuthorized;
            _authorizationMenu.Hide();
            ShowChallengers();
        }

        private void CreateChallengersViews(LeaderboardGetEntriesResponse result)
        {
            foreach (LeaderboardEntryResponse entry in result.entries)
            {
                ChallengerView newChallengerView = Instantiate(_challengerViewPrefab, _challengerViewContainer);
                
                newChallengerView.SetRank(entry.rank);
                newChallengerView.SetAvatar(entry.extraData);
                newChallengerView.SetName(entry.player.publicName);
                newChallengerView.SetScores(entry.score);
                if(entry.rank == result.userRank)
                    newChallengerView.MakeHighlight();
            }
        }
    }
}