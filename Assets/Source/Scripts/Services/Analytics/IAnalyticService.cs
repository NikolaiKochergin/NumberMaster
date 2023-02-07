using Source.Scripts.Analytics;

namespace Source.Scripts.Services.Analytics
{
    public interface IAnalyticService : IService
    {
        void AddAnalytic(IAnalytic analytic);
        void SendEventOnLevelStart(int levelNumber);
        void SendEventOnLevelComplete(int levelNumber);
        void SendEventOnFail(int levelNumber);
        void SendEventOnOffer(string rewardType);
        void SendEventOnClick(string rewardType);
        void SendEventOnResourceReceived(string resourceType, int count, string wayToGet, string receiptSource);
        void SendEventOnResourceSent(string resourceType, int count, string wayOfSpending, string spentOn);
        void SendEventOnInterstitialShown();
    }
}