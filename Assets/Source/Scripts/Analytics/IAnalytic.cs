namespace Source.Scripts.Analytics
{
    public interface IAnalytic
    {
        void OnLevelStart(int levelNumber);
        void OnLevelComplete(int levelNumber);
        void OnLevelFail(int levelNumber);
        void OnOffer(string rewardType);
        void OnClick(string rewardType);
        void OnResourceReceived(string resourceType, int count, string wayToGet, string receiptSource);
        void OnResourceSent(string resourceType, int count, string wayOfSpending, string spentOn);
        void OnInterstitialShown();
    }
}