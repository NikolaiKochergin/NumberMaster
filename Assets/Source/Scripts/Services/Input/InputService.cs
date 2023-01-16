using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;
using UnityEngine.Windows;

namespace Source.Service.Input
{
    public abstract class InputService : IInputService
    {
        public abstract Vector2 Axis { get;}
        public bool IsAttackButtonUp() => false;
        protected static Vector2 MousAxis()
        {
            if (UnityEngine.Input.GetMouseButton(0))
            {
                float pointX = UnityEngine.Input.mousePosition.x;
                Vector2 AxisX = new Vector2(pointX, 0);  
            }
            return new Vector2();
        }
    }
}