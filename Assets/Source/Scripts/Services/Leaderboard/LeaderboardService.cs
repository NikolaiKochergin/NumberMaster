using Agava.YandexGames;
using Source.Scripts.Services.Authorization;
using UnityEngine;

namespace Source.Scripts.Services.Leaderboard
{
    public class LeaderboardService : ILeaderboardService
    {
        private readonly string _leaderboardName;
        private readonly IAuthorizationService _authorization;

        public LeaderboardGetEntriesResponse LeaderboardEntries { get; private set; }
        public LeaderboardEntryResponse PlayerEntry { get; private set; }

        public LeaderboardService(string leaderboardName, IAuthorizationService authorization)
        {
            _leaderboardName = leaderboardName;
            _authorization = authorization;
            UpdateLeaderboardEntries();
        }

        public void UpdateLeaderboardEntries()
        {
#if YANDEX_GAMES && !UNITY_EDITOR
            Agava.YandexGames.Leaderboard.GetPlayerEntry(_leaderboardName, 
                result => PlayerEntry = result);
            
            Agava.YandexGames.Leaderboard.GetEntries(_leaderboardName, 
                result => LeaderboardEntries = result);
#elif UNITY_EDITOR
            #region Leaderboard Mockup for editor

            PlayerEntry = new LeaderboardEntryResponse();
            
            LeaderboardEntries = new LeaderboardGetEntriesResponse()
            {
                //userRank = 2,
                entries = new[]
                {
                    new LeaderboardEntryResponse()
                    {
                        score = 150,
                        rank = 1,
                        player = new PlayerAccountProfileDataResponse()
                        {
                            publicName = "Nick",
                            scopePermissions = new PlayerAccountProfileDataResponse.ScopePermissions()
                            {
                                avatar = "AvatarUrl"
                            }
                        }
                    },
                    new LeaderboardEntryResponse()
                    {
                        score = 100,
                        rank = 2,
                        player = new PlayerAccountProfileDataResponse()
                        {
                            publicName = "Masha",
                            scopePermissions = new PlayerAccountProfileDataResponse.ScopePermissions()
                            {
                                avatar = "AvatarUrl"
                            }
                        }
                    },
                    new LeaderboardEntryResponse()
                    {
                        score = 50,
                        rank = 3,
                        player = new PlayerAccountProfileDataResponse()
                        {
                            publicName = "Vova",
                            scopePermissions = new PlayerAccountProfileDataResponse.ScopePermissions()
                            {
                                avatar = "AvatarUrl"
                            }
                        }
                    },
                    new LeaderboardEntryResponse()
                    {
                        score = 10,
                        rank = 4,
                        player = new PlayerAccountProfileDataResponse()
                        {
                            scopePermissions = new PlayerAccountProfileDataResponse.ScopePermissions()
                        }
                    }
                }
            };

            #endregion
#endif
        }
        
        public void SetScore(int value)
        {
#if YANDEX_GAMES && !UNITY_EDITOR
            if (_authorization.IsPlayerAuthorized)
                Agava.YandexGames.Leaderboard.SetScore(_leaderboardName, value, UpdateLeaderboardEntries);
#elif UNITY_EDITOR
            Debug.Log($"Player scores: {value} sent to leaderboard named: {_leaderboardName}");
#endif
        }
    }
}