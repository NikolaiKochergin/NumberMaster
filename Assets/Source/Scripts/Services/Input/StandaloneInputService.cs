using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Windows;

namespace Source.Scripts.Services.Input
{
    public class StandaloneInputService : IInputService
    {
        //private const string Horizontal = "Horizontal";

        //public override Vector2 Axis
        //{
        //    get
        //    {
        //        //Vector2 axis = MousAxis();

        //        if (axis == Vector2.zero)
        //            axis = UnitiAxis();

        //        return axis;
        //    }
        //}

        public float PositionX { get
            {
                float Position = MouspositionX(); 
                return Position;
            }
        }

        private static float MouspositionX()
        {
            Vector3 vectorPoint =Vector3.zero;
            if (UnityEngine.Input.GetMouseButton(0))
            {
                var pointMousX = UnityEngine.Input.mousePosition.x;
                vectorPoint = new Vector3(pointMousX, 0, 0);
                Vector3 screenPointMousX = Camera.main.ScreenToViewportPoint(vectorPoint);
                Debug.Log(screenPointMousX);
                vectorPoint = screenPointMousX;
            }
            return vectorPoint.x;
        }

        private static Vector2 UnitiAxis()
        {
            //Vector2(UnityEngine.Input.GetAxis(Horizontal), 0);
            if (UnityEngine.Input.GetKeyDown(KeyCode.A))
            {
                Vector2 Axis = new Vector3();
            }

            return new Vector2();
        }

        public bool IsAttackButtonUp()
        {
            return false;
        }
    }
}