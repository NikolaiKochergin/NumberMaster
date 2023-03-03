using System;

namespace Source.Scripts.Services.Authorization
{
    public interface IAuthorizationService : IService
    {
        bool IsPlayerAuthorized { get; }
        void Authorize(Action onAuthorizationCallback);
    }
}