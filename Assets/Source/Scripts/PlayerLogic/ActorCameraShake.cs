using Source.Scripts.CameraLogic;
using UnityEngine;

namespace Source.Scripts.PlayerLogic
{
    public class ActorCameraShake : MonoBehaviour
    {
        private CameraShake _cameraShake;

        public void Initialize(CameraShake cameraShake) => 
            _cameraShake = cameraShake;

        public void Shake() => 
            _cameraShake.PlayCameraShake();
    }
}