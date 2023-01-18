namespace Source.Scripts.Services.Input
{
    public abstract class InputService : IInputService
    {
        protected float _offsetX = 0f;
        
        public abstract float OffsetX { get; }

        protected static float GetMouseDeltaX() => 
            UnityEngine.Input.GetMouseButton(0) ? UnityEngine.Input.GetAxis("Mouse X") : 0f;
    }
}