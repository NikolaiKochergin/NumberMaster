namespace Source.Scripts.Services.StaticData
{
    public interface IStaticDataService : IService
    {
        void Load();
        float ForPlayerSpeed();
    }
}