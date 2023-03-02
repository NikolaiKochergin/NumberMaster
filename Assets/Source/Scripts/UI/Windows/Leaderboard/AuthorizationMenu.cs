using System;
using Agava.YandexGames;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Scripts.UI.Windows.Leaderboard
{
    public class AuthorizationMenu : MonoBehaviour
    {
        [SerializeField] private Button _authorizationButton;

        public event Action PlayerAuthorized;

        private void Awake() => 
            Hide();

        private void OnEnable() => 
            _authorizationButton.onClick.AddListener(Authorize);

        private void OnDisable() => 
            _authorizationButton.onClick.RemoveListener(Authorize);

        private void Authorize()
        {
#if YANDEX_GAMES && !UNITY_EDITOR
            PlayerAccount.Authorize(()=>
                PlayerAccount.RequestPersonalProfileDataPermission(
                    PlayerAuthorized,
                    (_)=> PlayerAuthorized?.Invoke()));
#elif UNITY_EDITOR
            PlayerAuthorized?.Invoke();
#endif
        }

        public void Show() => 
            gameObject.SetActive(true);

        public void Hide() =>
            gameObject.SetActive(false);
    }
}
