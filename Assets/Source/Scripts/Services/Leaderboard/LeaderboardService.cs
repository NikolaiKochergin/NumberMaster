using Agava.YandexGames;
using UnityEngine;

namespace Source.Scripts.Services.Leaderboard
{
    public class LeaderboardService : ILeaderboardService
    {
        private readonly string _leaderboardName;
        public LeaderboardGetEntriesResponse LeaderboardEntries { get; private set; }

        public LeaderboardService(string leaderboardName)
        {
            _leaderboardName = leaderboardName;
            UpdateLeaderboardEntries();
        }

        public void UpdateLeaderboardEntries()
        { 
#if YANDEX_GAMES && !UNITY_EDITOR
            Agava.YandexGames.Leaderboard.GetEntries(_leaderboardName, 
                result => LeaderboardEntries = result);
#elif UNITY_EDITOR
            #region Mockup leaderboard for editor

            LeaderboardEntries = new LeaderboardGetEntriesResponse()
            {
                userRank = 2,
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
            if (PlayerAccount.IsAuthorized)
                Agava.YandexGames.Leaderboard.SetScore(_leaderboardName, value, UpdateLeaderboardEntries);
#elif UNITY_EDITOR
            Debug.Log($"Player scores: {value} sent to leaderboard named: {_leaderboardName}");
#endif
        }
    }
}