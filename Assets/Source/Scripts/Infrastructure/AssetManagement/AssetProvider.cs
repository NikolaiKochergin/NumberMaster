using UnityEngine;

namespace Source.Scripts.Infrastructure.AssetManagement
{
    public class AssetProvider : IAssetProvider
    {
        public T Instantiate<T>(string path) where T : Object
        {
            T prefab = Resources.Load<T>(path);
            return Object.Instantiate(prefab);
        }
        
        public T Instantiate<T>(string path, Vector3 at, Quaternion rotation) where T : Object
        {
            T prefab = Resources.Load<T>(path);
            return Object.Instantiate(prefab, at, rotation);
        }

        public GameObject Instantiate(string path, Vector3 at)
        {
            GameObject prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab, at, Quaternion.identity);
        }

        public GameObject Instantiate(string path)
        {
            GameObject prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab);
        }
    }
}