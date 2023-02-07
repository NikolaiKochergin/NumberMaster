namespace Source.Scripts.Services.Input
{
    public abstract class InputService : IInputService
    {
        protected float _deltaX = 0f;
        
        public abstract float DeltaX { get; }

        protected static float GetMouseDeltaX() => 
            UnityEngine.Input.GetMouseButton(0) ? UnityEngine.Input.GetAxis("Mouse X") : 0f;
    }
}