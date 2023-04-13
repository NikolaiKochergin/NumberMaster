using Agava.YandexGames;
using UnityEngine;

namespace Source.Scripts.Tools
{
    public class YandexRemoteDataCleaner : MonoBehaviour
    {
        public void ClearData()
        {
#if YANDEX_GAMES && !UNITY_EDITOR
            PlayerAccount.SetCloudSaveData("");
            Debug.Log("Remote Data Cleared");
#endif
        }
    }
}
