#if GAME_ANALYTICS
using GameAnalyticsSDK;

namespace Source.Scripts.Analytics
{
    public class GameAnalyticsAnalytic : IAnalytic
    {
        public void OnLevelStart(int levelNumber) => 
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, AnalyticNames.Level + levelNumber);

        public void OnLevelComplete(int levelNumber) => 
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, AnalyticNames.Level + levelNumber);

        public void OnLevelFail(int levelNumber) => 
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, AnalyticNames.Level + levelNumber);

        public void OnOffer(string rewardType) => 
            GameAnalytics.NewDesignEvent(rewardType + AnalyticNames.AdOffer);

        public void OnClick(string rewardType) => 
            GameAnalytics.NewDesignEvent(rewardType + AnalyticNames.AdClick);

        public void OnResourceReceived(string resourceType, int count, string wayToGet, string receiptSource) => 
            GameAnalytics.NewResourceEvent(GAResourceFlowType.Source, resourceType, count, wayToGet, receiptSource);

        public void OnResourceSent(string resourceType, int count, string wayOfSpending, string spentOn) => 
            GameAnalytics.NewResourceEvent(GAResourceFlowType.Sink, resourceType, count, wayOfSpending, spentOn);

        public void OnInterstitialShown() => 
            GameAnalytics.NewDesignEvent(AnalyticNames.InterstitialAdd);
    }
}
#endif
