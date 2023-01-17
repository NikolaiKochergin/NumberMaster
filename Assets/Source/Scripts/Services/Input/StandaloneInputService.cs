using UnityEngine;
using UnityEngine.Animations;

namespace Source.Scripts.Services.Input
{
    public class StandaloneInputService : InputService
    {
        //private const string Horizontal = "Horizontal";

        public override Vector2 Axis
        {
            get
            {
                Vector2 axis = MousAxis();

                if (axis == Vector2.zero)
                    axis = UnitiAxis();

                return axis;
            }
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
    }
}