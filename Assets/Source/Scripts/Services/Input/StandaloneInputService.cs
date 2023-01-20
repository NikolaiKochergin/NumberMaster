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

        public override float DeltaX { get
            {
                _deltaX = GetMouseDeltaX() * _mouseSensitivity + GetKeyBoardDeltaX() * _keyboardSensitivity;
                return _deltaX;
            }
        }

        private static float GetKeyBoardDeltaX() => 
            UnityEngine.Input.GetAxis("Horizontal");
    }
}