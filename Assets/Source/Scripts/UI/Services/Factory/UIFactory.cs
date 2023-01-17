using Source.Scripts.Infrastructure.AssetManagement;
using Source.Scripts.Services.PersistentProgress;
using Source.Scripts.Services.StaticData;

namespace Source.Scripts.UI.Services.Factory
{
    public class UIFactory : IUIFactory
    {
        private readonly IAssetProvider _assets;
        private readonly IStaticDataService _staticData;
        private readonly IPersistentProgressService _progressService;

        public UIFactory(IAssetProvider assets, IStaticDataService staticData,
            IPersistentProgressService progressService)
        {
            _assets = assets;
            _staticData = staticData;
            _progressService = progressService;
        }

        public void CreateUpgradeMenu()
        {
            throw new System.NotImplementedException();
        }
    }
}