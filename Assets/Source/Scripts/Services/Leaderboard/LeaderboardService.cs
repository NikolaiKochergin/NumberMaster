using System;
using System.Threading;
using System.Threading.Tasks;
using Agava.YandexGames;
using UnityEngine;

namespace Source.Scripts.Services.Leaderboard
{
    public class LeaderboardService : ILeaderboardService
    {
        private const string LeaderboardName = "Number master";

        public void GetPlayerInfo(Action<PlayerAccountProfileDataResponse> playerAccountProfileData) => 
            PlayerAccount.GetProfileData(playerAccountProfileData);

        public async void GetLeaderboardEntryResponses(Action<LeaderboardGetEntriesResponse> entries, CancellationToken token)
        {
            try
            {
                await Task.Delay(1000, token);
            }
            catch (Exception e)
            {
                return;
            }
#if YANDEX_GAMES && ! UNITY_EDITOR
            Agava.YandexGames.Leaderboard.GetEntries(LeaderboardName, (e) =>
            {
                if (token.IsCancellationRequested == false)
                    entries?.Invoke(e);
            });
#elif UNITY_EDITOR
            // Mockup for editor
            entries?.Invoke(new LeaderboardGetEntriesResponse()
            {
                userRank = 2,
                entries = new []
                {
                    new LeaderboardEntryResponse()
                    {
                        score = 150,
                        rank = 1,
                        player = new PlayerAccountProfileDataResponse() {publicName = "Nick"}
                    },
                    new LeaderboardEntryResponse()
                    {
                        score = 100,
                        rank = 2,
                        player = new PlayerAccountProfileDataResponse() {publicName = "Masha"}
                    },
                    new LeaderboardEntryResponse()
                    {
                        score = 50,
                        rank = 3,
                        player = new PlayerAccountProfileDataResponse() {publicName = "Vova"}
                    }
                }
            });
#endif
        }

        public void SetScore(int value)
        {
#if YANDEX_GAMES && !UNITY_EDITOR
            Agava.YandexGames.Leaderboard.SetScore(LeaderboardName, value);
#elif UNITY_EDITOR
            Debug.Log($"Player scores: {value} sended to leaderboard named: {LeaderboardName}");
#endif
        }
    }
}