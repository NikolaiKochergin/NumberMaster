using Agava.YandexGames;
using Lean.Localization;
using Source.Scripts.Services.PersistentProgress;
using Source.Scripts.Services.StaticData;
using Object = UnityEngine.Object;

namespace Source.Scripts.Services.Localization
{
    public class LocalizationService : ILocalizationService
    {
        private readonly IPersistentProgressService _progressService;
        private readonly LeanLocalization _localization;

        public LanguageType CurrentLocalization => _progressService.Progress.GameSettings.Localization;

        public LocalizationService(IPersistentProgressService progressService, IStaticDataService staticData)
        {
            _progressService = progressService;
            _localization = Object.Instantiate(staticData.ForLocalization());
            Object.DontDestroyOnLoad(_localization);
        }

        public void SetLocalization(LanguageType languageType)
        {
            if (languageType == LanguageType.None) 
                languageType = GetEnvironmentLocalization();

            _localization.CurrentLanguage = GetLocalizationName(languageType);
            _progressService.Progress.GameSettings.Localization = languageType;
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
        private LanguageType GetEnvironmentLocalization() =>
                YandexGamesSdk.Environment.i18n.lang switch
                {
                    LocalizationNames.RussianTranslationCode => LanguageType.Russian,
                    LocalizationNames.EnglishTranslationCode => LanguageType.English,
                    LocalizationNames.TurkishTranslationCode => LanguageType.Turkish,
                    _ => LanguageType.English
                    
                };
#elif UNITY_EDITOR
        private LanguageType GetEnvironmentLocalization() =>
            LanguageType.Russian;
#endif
    }
}