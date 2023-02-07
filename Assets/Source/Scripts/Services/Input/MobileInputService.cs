namespace Source.Scripts.Services.Input
{
    public class MobileInputService : InputService
    {
        private static float _mouseSensitivity;
        
        public MobileInputService(float mouseSensitivity) => 
            _mouseSensitivity = mouseSensitivity;

        public override float DeltaX { get
            {
                _deltaX = GetMouseDeltaX() * _mouseSensitivity;
                return _deltaX;
            }
        }
    }
}