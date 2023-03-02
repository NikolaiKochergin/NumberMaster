using System;
using System.Threading;
using Agava.YandexGames;

namespace Source.Scripts.Services.Leaderboard
{
    public interface ILeaderboardService : IService
    {
        void GetPlayerInfo(Action<PlayerAccountProfileDataResponse> playerAccountProfileData);
        void SetScore(int value);
        void GetLeaderboardEntryResponses(Action<LeaderboardGetEntriesResponse> result, CancellationToken token);
    }
}