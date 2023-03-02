using System;
using System.Threading.Tasks;
using Agava.YandexGames;
using UnityEngine;

namespace Source.Scripts.Services.Leaderboard
{
    public class LeaderboardService : ILeaderboardService
    {
        private const string LeaderboardName = "NumberMaster";

        public void GetPlayerInfo(Action<PlayerAccountProfileDataResponse> playerAccountProfileData) => 
            PlayerAccount.GetProfileData(playerAccountProfileData);

        public void GetLeaderboardEntryResponses(Action<LeaderboardGetEntriesResponse> result)
        {
#if YANDEX_GAMES && !UNITY_EDITOR
            Agava.YandexGames.Leaderboard.GetEntries(LeaderboardName, result);
#elif UNITY_EDITOR
            // Mockup for editor
            result?.Invoke(new LeaderboardGetEntriesResponse()
            {
                userRank = 2,
                entries = new []
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
            });
#endif
        }

        public void SetScore(int value)
        {
#if YANDEX_GAMES && !UNITY_EDITOR
            if (PlayerAccount.IsAuthorized)
            {
                Agava.YandexGames.Leaderboard.SetScore(LeaderboardName, value);
                Debug.Log($"Player scores: {value} sent to leaderboard named: {LeaderboardName}");
            }
#elif UNITY_EDITOR
            Debug.Log($"Player scores: {value} sent to leaderboard named: {LeaderboardName}");
#endif
        }
    }
}