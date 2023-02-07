using UnityEngine;

namespace Source.Scripts.CameraLogic
{
    public class CameraShake : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private const string Shake = "Shake";
        public void PlayCameraShake() => 
            _animator.SetTrigger(Shake);
    }
}