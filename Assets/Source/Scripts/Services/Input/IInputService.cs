using UnityEngine;

namespace Source.Scripts.Services.Input
{
    public interface IInputService : IService
    {
        float PositionX { get; }
        bool IsAttackButtonUp();
    }
}