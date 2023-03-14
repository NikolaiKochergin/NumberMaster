using System;
using Agava.YandexGames;

namespace Source.Scripts.Services.Authorization
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly bool _isNeedPersonalProfileDataPermission;
#if YANDEX_GAMES && !UNITY_EDITOR
        public bool IsPlayerAuthorized => PlayerAccount.IsAuthorized;
#else
        public bool IsPlayerAuthorized { get; private set; }
#endif
        public AuthorizationService(bool isNeedPersonalProfileDataPermission = true) => 
            _isNeedPersonalProfileDataPermission = isNeedPersonalProfileDataPermission;

        public void Authorize(Action onAuthorizationCallback)
        {
#if UNITY_EDITOR
             IsPlayerAuthorized = true;
             onAuthorizationCallback?.Invoke();
#elif YANDEX_GAMES
            if (IsPlayerAuthorized)
                onAuthorizationCallback?.Invoke();
            else
                PlayerAccount.Authorize(_isNeedPersonalProfileDataPermission
                    ? RequestPersonalProfileDataPermission
                    : onAuthorizationCallback);

            void RequestPersonalProfileDataPermission()
            {
                if(IsPlayerAuthorized && !PlayerAccount.HasPersonalProfileDataPermission)
                    PlayerAccount.RequestPersonalProfileDataPermission(onAuthorizationCallback,
                        (_) => onAuthorizationCallback?.Invoke());
            }
#endif
        }
    }
}