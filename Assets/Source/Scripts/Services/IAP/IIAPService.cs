namespace Source.Scripts.Services.IAP
{
    public interface IIAPService : IService
    {
        void Buy(PurchaseType purchaseType);
        PurchaseConfig GetConfigOf(PurchaseType type);
        int GetPriceOf(PurchaseType type);
    }
}