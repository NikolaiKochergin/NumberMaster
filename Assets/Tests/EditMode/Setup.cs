using NSubstitute;
using Source.Scripts.Infrastructure.Factory;
using Source.Scripts.PlayerLogic;
using Source.Scripts.Services.Analytics;
using Source.Scripts.Services.IAP;
using Source.Scripts.Services.PersistentProgress;
using Source.Scripts.Services.StaticData;
using Source.Scripts.StaticData;
using UnityEngine;

namespace Tests.EditMode
{
    public abstract class Setup
    {
        public static IPersistentProgressService IAPService(out IAPService iapService, PurchaseType purchaseType)
        {
            IPersistentProgressService progressService = Create.ProgressService();
            progressService.Progress = Create.PlayerProgress();

            IStaticDataService staticData = Substitute.For<IStaticDataService>();
            IGameFactory factory = Substitute.For<IGameFactory>();
            IAnalyticService analytic = Substitute.For<IAnalyticService>();
            Player playerPrefab = Resources.Load<Player>("Player/Player");
            Player player = Object.Instantiate(playerPrefab);
            player.LoadProgress(progressService.Progress);
            factory.Player.Returns(player);
            PurchaseConfig purchaseConfig = Resources.Load<GameStaticData>("StaticData/GameData")
                .Purchases.Find(x => x.Type == purchaseType);
            staticData.ForPurchase(purchaseType).Returns(purchaseConfig);

            iapService = new IAPService(staticData, progressService, factory, analytic);
            return progressService;
        }
    }
}