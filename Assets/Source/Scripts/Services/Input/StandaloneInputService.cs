using UnityEngine;

namespace Source.Service.Input
{
    public class StandaloneInputService : InputService
    {
        private const string Horizontal = "Horizontal";

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

        private static Vector2 UnitiAxis() => new
            Vector2(UnityEngine.Input.GetAxis(Horizontal), 0);
    }
}