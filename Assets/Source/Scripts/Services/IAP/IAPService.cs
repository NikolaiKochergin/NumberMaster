using System;
using Source.Scripts.Analytics;
using Source.Scripts.Services.Analytics;
using Source.Scripts.Services.PersistentProgress;
using Source.Scripts.Services.StaticData;
using UnityEngine;

namespace Source.Scripts.Services.IAP
{
    public class IAPService : IIAPService
    {
        private readonly IStaticDataService _staticData;
        private readonly IPersistentProgressService _progressService;
        private readonly IAnalyticService _analytic;

        public IAPService(IStaticDataService staticData, IPersistentProgressService progressService, IAnalyticService analytic)
        {
            _staticData = staticData;
            _progressService = progressService;
            _analytic = analytic;
        }

        public void Buy(PurchaseType purchaseType)
        {
            int price = GetPriceOf(purchaseType);
            if(_progressService.Progress.Soft.Collected < price)
                return;
            
            PurchaseConfig purchase = _staticData.ForPurchase(purchaseType);
            _progressService.Progress.Soft.Collected -= price;
            
            switch (purchaseType)
            {
                case PurchaseType.None:
                    break;
                case PurchaseType.StartLevel:
                    _progressService.Progress.PlayerStats.StartNumber += (int)purchase.SalableValue;
                    _progressService.Progress.PurchaseData.StartNumberCount++;
                    _analytic.SendEventOnResourceSent(
                        AnalyticNames.Soft, 
                        price, 
                        AnalyticNames.Shop, 
                        AnalyticNames.StartNumber);
                    break;
                case PurchaseType.Incoming:
                    _progressService.Progress.PlayerStats.Income += purchase.SalableValue;
                    _progressService.Progress.PurchaseData.IncomeLevelCount++;
                    _analytic.SendEventOnResourceSent(
                        AnalyticNames.Soft, 
                        price, 
                        AnalyticNames.Shop, 
                        AnalyticNames.Incoming);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(purchaseType), purchaseType, null);
            }
        }

        public PurchaseConfig GetConfigOf(PurchaseType type) => 
            _staticData.ForPurchase(type);

        public int GetPriceOf(PurchaseType type)
        {
            PurchaseConfig purchase = _staticData.ForPurchase(type);

            return type switch
            {
                PurchaseType.None => 0,
                PurchaseType.StartLevel => purchase.BasePrice * (1 +_progressService.Progress.PurchaseData.StartNumberCount),
                PurchaseType.Incoming => purchase.BasePrice * (1 + _progressService.Progress.PurchaseData.IncomeLevelCount),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}