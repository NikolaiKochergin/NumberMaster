namespace Source.Scripts.Services.Localization
{
    public interface ILocalizationService : IService
    {
        LanguageType CurrentLocalization { get; }
        void SetLocalization(LanguageType languageType);
    }
}