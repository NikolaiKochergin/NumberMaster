#if YANDEX_METRICA
using System;
using Agava.YandexGames;
using Source.Scripts.Data;
using Source.Scripts.Infrastructure.Factory;
using Source.Scripts.Services.PersistentProgress;

namespace Source.Scripts.Services.SaveLoad
{
    public class YandexSaveLoadService : ISaveLoadService
    {
        private readonly IPersistentProgressService _progressService;
        private readonly IGameFactory _gameFactory;

        public YandexSaveLoadService(IPersistentProgressService progressService, IGameFactory gameFactory)
        {
            _progressService = progressService;
            _gameFactory = gameFactory;
        }
        
        public void SaveProgress(Action onSuccessCallback = null)
        {
            foreach (ISavedProgress progressWriter in _gameFactory.ProgressWriters)
                progressWriter.UpdateProgress(_progressService.Progress);
      
            PlayerAccount.SetCloudSaveData(_progressService.Progress.ToJson(), onSuccessCallback);
        }

        public void LoadProgress(Action<PlayerProgress> onSuccessCallback)
        {
            PlayerAccount.GetCloudSaveData(data=> 
                onSuccessCallback.Invoke(data.ToDeserialized<PlayerProgress>()),
                _ => onSuccessCallback.Invoke(null));
        }
    }
}
#endif