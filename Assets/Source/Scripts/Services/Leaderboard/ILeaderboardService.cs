using Agava.YandexGames;

namespace Source.Scripts.Services.Leaderboard
{
    public interface ILeaderboardService : IService
    {
        void SetScore(int value);
        void UpdateLeaderboardEntries();
        LeaderboardGetEntriesResponse LeaderboardEntries { get; }
        LeaderboardEntryResponse PlayerEntry { get; }
    }
}