using UnityEngine;

namespace Source.Scripts.Services.Input
{
    public interface IInputService : IService
    {
        float OffsetX { get; }
        bool IsAttackButtonUp();
    }
}