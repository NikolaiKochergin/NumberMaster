using UnityEngine;

namespace Source.Scripts.UI.Elements
{
    public class ImageRotator : MonoBehaviour
    {
        [SerializeField] private float _speed = -180;

        private void Update() => 
            transform.Rotate(Vector3.forward, _speed * Time.deltaTime);
    }
}
