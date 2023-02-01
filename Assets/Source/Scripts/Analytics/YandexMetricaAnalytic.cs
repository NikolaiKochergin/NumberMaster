#if YANDEX_METRICA
using Agava.YandexMetrica;

namespace Source.Scripts.Analytics
{
    public class YandexMetricaAnalytic : IAnalytic
    {
        public void OnLevelStart(int levelNumber) => 
            YandexMetrica.Send($"level{levelNumber}Start");

        public void OnLevelComplete(int levelNumber) => 
            YandexMetrica.Send($"level{levelNumber}Complete");

        public void OnLevelFail(int levelNumber) => 
            YandexMetrica.Send($"level{levelNumber}Fail");

        public void OnOffer(string rewardType) => 
            YandexMetrica.Send($"{rewardType}AddOffer");

        public void OnClick(string rewardType) => 
            YandexMetrica.Send($"{rewardType}OnClick");

        public void OnResourceReceived(string resourceType, int count, string wayToGet, string receiptSource) => 
            YandexMetrica.Send($"{resourceType}Received");

        public void OnResourceSent(string resourceType, int count, string wayOfSpending, string spentOn) => 
            YandexMetrica.Send($"{resourceType}Sent");

        public void OnInterstitialShown() => 
            YandexMetrica.Send("interstitialAd");
    }
}
#endif