using Source.Scripts.Services;
using UnityEngine;

namespace Source.Scripts.Infrastructure.AssetManagement
{
    public interface IAssetProvider : IService
    {
        T Instantiate<T>(string path) where T : Object;
        T Instantiate<T>(string path, Vector3 at, Quaternion rotation) where T : Object;
    }
}