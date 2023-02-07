using System.Collections.Generic;
using Source.Scripts.Analytics;
using UnityEngine;

namespace Source.Scripts.Services.Analytics
{
    public class AnalyticService : IAnalyticService
    {
        private readonly List<IAnalytic> _analytics = new();
        
        public AnalyticService(IReadOnlyList<IAnalytic> analytics = null)
        {
            if (analytics == null)
            {
                Debug.LogWarning("AnalyticManager doesn't contain any analytica");
                return;
            }
            _analytics.AddRange(analytics);
        }

        public void AddAnalytic(IAnalytic analytic) => 
            _analytics.Add(analytic);

        public void SendEventOnLevelStart(int levelNumber)
        {
            foreach (IAnalytic analytic in _analytics) 
                analytic.OnLevelStart(levelNumber);
        }

        public void SendEventOnLevelComplete(int levelNumber)
        {
            foreach (IAnalytic analytic in _analytics) 
                analytic.OnLevelComplete(levelNumber);
        }

        public void SendEventOnFail(int levelNumber)
        {
            foreach (IAnalytic analytic in _analytics) 
                analytic.OnLevelFail(levelNumber);
        }

        public void SendEventOnOffer(string rewardType)
        {
            foreach (IAnalytic analytic in _analytics) 
                analytic.OnOffer(rewardType);
        }

        public void SendEventOnClick(string rewardType)
        {
            foreach (IAnalytic analytic in _analytics) 
                analytic.OnClick(rewardType);
        }

        public void SendEventOnResourceReceived(string resourceType, int count, string wayToGet, string receiptSource)
        {
            foreach (IAnalytic analytic in _analytics)
                analytic.OnResourceReceived(resourceType, count, wayToGet, receiptSource);
        }

        public void SendEventOnResourceSent(string resourceType, int count, string wayOfSpending, string spentOn)
        {
            foreach (IAnalytic analytic in _analytics)
                analytic.OnResourceSent(resourceType, count, wayOfSpending, spentOn);
        }

        public void SendEventOnInterstitialShown()
        {
            foreach (IAnalytic analytic in _analytics) 
                analytic.OnInterstitialShown();
        }
    }
}