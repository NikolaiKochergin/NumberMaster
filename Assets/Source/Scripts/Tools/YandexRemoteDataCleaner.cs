using Agava.YandexGames;
using UnityEngine;

namespace Source.Scripts.Tools
{
    public class YandexRemoteDataCleaner : MonoBehaviour
    {
        public void ClearData()
        {
#if YANDEX_GAMES && !UNITY_EDITOR
            PlayerAccount.SetPlayerData("");
            Debug.Log("Remote Data Cleared");
#endif
        }
    }
}
