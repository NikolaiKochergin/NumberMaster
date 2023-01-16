using UnityEngine;

namespace Source.Scripts.Services.Input
{
    public class MobileInputService : InputService
    {
        public override Vector2 Axis => MousAxis();
    }
}