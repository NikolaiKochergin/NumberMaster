using UnityEngine;

namespace Source.Scripts.CameraLogic
{
    public class CameraTracker : MonoBehaviour
    {
        [SerializeField] private Transform _target;

        private void Update() => 
            transform.position = GetPosition();

        private Vector3 GetPosition() => 
            new Vector3(transform.position.x, transform.position.y, _target.transform.position.z);
    }
}
