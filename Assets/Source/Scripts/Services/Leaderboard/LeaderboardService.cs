using System;
using System.Threading;
using System.Threading.Tasks;
using Agava.YandexGames;

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
            
            Agava.YandexGames.Leaderboard.GetEntries(LeaderboardName, (e) =>
            {
                if (token.IsCancellationRequested == false)
                    entries?.Invoke(e);
            });
        }

        public void SetScore(int value) => 
            Agava.YandexGames.Leaderboard.SetScore(LeaderboardName, value);
    }
}