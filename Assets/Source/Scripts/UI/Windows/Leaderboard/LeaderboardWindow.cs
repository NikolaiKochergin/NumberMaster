using Agava.YandexGames;
using Source.Scripts.Services.Authorization;
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

        private ILeaderboardService _leaderboard;
        private IAuthorizationService _authorization;
        
        public void Construct(ILeaderboardService leaderboard, IAuthorizationService authorization)
        {
            _leaderboard = leaderboard;
            _authorization = authorization;
        }

        protected override void Initialize()
        {
            if (_authorization.IsPlayerAuthorized)
                ShowChallengers();
            else
                ShowAuthorizationMenu();
        }

        private void ShowAuthorizationMenu()
        {
            _authorizationMenu.Show();
            _authorizationMenu.AuthorizationButton.onClick.AddListener(OnAuthorizationButtonClicked);
        }

        protected override void SubscribeUpdates() => 
            _closeButton.onClick.AddListener(Close);

        private void ShowChallengers()
        {
            LeaderboardGetEntriesResponse entries = _leaderboard.Entries;
            if (entries != null) 
                CreateChallengersViews(entries);
        }

        private void OnAuthorizationButtonClicked()
        {
            _authorization.Authorize(() =>
            {
                _authorizationMenu.AuthorizationButton.onClick.RemoveListener(OnAuthorizationButtonClicked);
                _authorizationMenu.Hide();
                ShowChallengers();
            });
        }

        private void CreateChallengersViews(LeaderboardGetEntriesResponse result)
        {
            foreach (LeaderboardEntryResponse entry in result.entries)
            {
                ChallengerView newChallengerView = Instantiate(_challengerViewPrefab, _challengerViewContainer);
                
                newChallengerView.SetRank(entry.rank);
                newChallengerView.SetName(entry.player.publicName);
                newChallengerView.SetScores(entry.score);
                Debug.Log(entry.avatarUrl +" <------------------- Avatar Url");
                newChallengerView.SetAvatar(entry.avatarUrl);
                if(entry.rank == result.userRank)
                    newChallengerView.MakeHighlight();
            }
        }
    }
}