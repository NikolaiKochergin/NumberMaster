namespace Source.Scripts.Services.Input
{
    public class MobileInputService : InputService
    {
        private static float _mouseSensitivity;
        
        public MobileInputService(float mouseSensitivity) => 
            _mouseSensitivity = mouseSensitivity;

        public override float OffsetX { get
            {
                _offsetX += GetMouseDeltaX() * _mouseSensitivity;
                return _offsetX;
            }
        }
    }
}