using Source.Scripts.Services;
using UnityEngine;

namespace Source.Scripts.Infrastructure.AssetManagement
{
    public interface IAssetProvider : IService
    {
        GameObject Instantiate(string path, Vector3 at);
        GameObject Instantiate(string path);
        T Instantiate<T>(string path) where T : Object;
    }
}