namespace Source.Scripts.Services.Input
{
    public class MobileInputService : InputService
    {
        public override float OffsetX { get
            {
                _offsetX += GetMouseDeltaX();
                return _offsetX;
            }
        }
    }
}