using System.Collections.Generic;
using Source.Scripts.InteractiveObjects.Number;
using Source.Scripts.PlayerLogic;
using Source.Scripts.Services;
using Source.Scripts.Services.PersistentProgress;
using UnityEngine;

namespace Source.Scripts.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        List<ISavedProgressReader> ProgressReaders { get; }
        List<ISavedProgress> ProgressWriters { get; }
        Player Player { get; }
        void Cleanup();
        Player CreatePlayer();
        EnemyNumber CreateEnemyNumber(Vector3 position, Quaternion rotation);
        Sounds CreateSounds();
    }
}