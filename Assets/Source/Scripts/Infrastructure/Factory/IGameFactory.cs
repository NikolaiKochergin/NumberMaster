using System.Collections.Generic;
using Source.Scripts.PlayerLogic;
using Source.Scripts.Services;
using Source.Scripts.Services.PersistentProgress;

namespace Source.Scripts.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        List<ISavedProgressReader> ProgressReaders { get; }
        List<ISavedProgress> ProgressWriters { get; }
        void Cleanup();
        Player CreatePlayer();
    }
}