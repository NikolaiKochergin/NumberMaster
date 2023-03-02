using System.Threading;
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
        [SerializeField] private GameObject _loadingImage;
        [SerializeField] private AuthorizationMenu _authorizationMenu;

        private readonly CancellationTokenSource _cts = new CancellationTokenSource();
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

        protected override void Cleanup() => 
            _cts.Cancel();

        private void ShowChallengers()
        {
            _loadingImage.SetActive(true);
            _leaderboardService.GetLeaderboardEntryResponses(CreateChallengersViews, _cts.Token);
        }

        private void PlayerAuthorized()
        {
            _authorizationMenu.PlayerAuthorized -= PlayerAuthorized;
            _authorizationMenu.Hide();
            ShowChallengers();
        }

        private void CreateChallengersViews(LeaderboardGetEntriesResponse result)
        {
            Debug.Log("-------------IN BEGINNING OF CREATING CHALENGERS VIEWS");
            Debug.Log($"RESULT INFO   Length: {result.entries.Length}  {result}  " );
            
            if(this == null)
                return;
            
            foreach (LeaderboardEntryResponse entry in result.entries)
            {
                ChallengerView newChallengerView = Instantiate(_challengerViewPrefab, _challengerViewContainer);
                
                newChallengerView.SetRank(entry.rank);
                newChallengerView.SetAvatar(entry.player.scopePermissions.avatar);
                newChallengerView.SetName(entry.player.publicName);
                newChallengerView.SetScores(entry.score);
                if(entry.rank == result.userRank)
                    newChallengerView.MakeHighlight();
            }
            _loadingImage.SetActive(false);
        }
    }
}