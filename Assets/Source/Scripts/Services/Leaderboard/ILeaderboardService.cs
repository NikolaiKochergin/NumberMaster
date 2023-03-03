using Agava.YandexGames;

namespace Source.Scripts.Services.Leaderboard
{
    public interface ILeaderboardService : IService
    {
        void SetScore(int value);
        void UpdateEntries();
        LeaderboardGetEntriesResponse Entries { get; }
        LeaderboardEntryResponse PlayerEntry { get; }
    }
}