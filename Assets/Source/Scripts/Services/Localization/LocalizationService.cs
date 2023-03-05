using Agava.YandexGames;
using Lean.Localization;
using Source.Scripts.Services.StaticData;
using Object = UnityEngine.Object;

namespace Source.Scripts.Services.Localization
{
    public class LocalizationService : ILocalizationService
    {
        private readonly LeanLocalization _localization;
        
        public LanguageType CurrentLocalization { get; private set; }

        public LocalizationService(IStaticDataService staticData)
        {
            _localization = Object.Instantiate(staticData.ForLocalization());
            Object.DontDestroyOnLoad(_localization);
            
            SetLocalization(GetEnvironmentLocalization());
        }

        public void SetLocalization(LanguageType languageType)
        {
            CurrentLocalization = languageType;
            _localization.CurrentLanguage = GetLocalizationName(languageType);
        }

        private static string GetLocalizationName(LanguageType languageType) =>
            languageType switch
            {
                LanguageType.Russian => LocalizationNames.Russian,
                LanguageType.English => LocalizationNames.English,
                LanguageType.Turkish => LocalizationNames.Turkish,
                _ => LocalizationNames.English
            };
        
#if YANDEX_GAMES && !UNITY_EDITOR
        private static LanguageType GetEnvironmentLocalization() =>
            YandexGamesSdk.Environment.i18n.lang switch
            {
                LocalizationNames.RussianTranslationCode => LanguageType.Russian,
                LocalizationNames.EnglishTranslationCode => LanguageType.English,
                LocalizationNames.TurkishTranslationCode => LanguageType.Turkish,
                _ => LanguageType.English
            };
#elif UNITY_EDITOR
        private static LanguageType GetEnvironmentLocalization() =>
            LanguageType.Russian;
#endif
    }
}