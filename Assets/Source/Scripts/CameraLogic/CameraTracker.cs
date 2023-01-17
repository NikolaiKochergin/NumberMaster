using UnityEngine;

namespace Source.Scripts.CameraLogic
{
    public class CameraTracker : MonoBehaviour
    {
        [SerializeField] private Transform _target;

        private void Update()
        {
            transform.position = _target.position;
        }
    }
}
