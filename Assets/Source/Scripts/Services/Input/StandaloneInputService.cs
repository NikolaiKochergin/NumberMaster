namespace Source.Scripts.Services.Input
{
    public class StandaloneInputService : InputService
    {
        private static float _mouseSensitivity;
        private static float _keyboardSensitivity;
        
        public StandaloneInputService(float mouseSensitivity, float keyboardSensitivity)
        {
            _mouseSensitivity = mouseSensitivity;
            _keyboardSensitivity = keyboardSensitivity;
        }

        public override float OffsetX { get
            {
                _offsetX += GetMouseDeltaX() * _mouseSensitivity;
                _offsetX += GetKeyBoardDeltaX() * _keyboardSensitivity;
                return _offsetX;
            }
        }

        private static float GetKeyBoardDeltaX() => 
            UnityEngine.Input.GetAxis("Horizontal");
    }
}