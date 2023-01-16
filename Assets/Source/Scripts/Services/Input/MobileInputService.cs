using UnityEngine;

namespace Source.Service.Input
{
    public class MobileInputService : InputService
    {
        public override Vector2 Axis => MousAxis();
    }
}