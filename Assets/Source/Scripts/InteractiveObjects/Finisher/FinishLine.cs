using Source.Scripts.PlayerLogic;
using UnityEngine;

namespace Source.Scripts.InteractiveObjects.Finisher
{
    public class FinishLine : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _triggerObserver;

        private void OnEnable() => 
            _triggerObserver.TriggerEnter += —hange—ontrol;

        private void OnDisable() => 
            _triggerObserver.TriggerEnter -= —hange—ontrol;

        private void —hange—ontrol(Collider collider)
        {
            if(collider.TryGetComponent(out Player player))
            {
                player.PlayerMove.Disable();
                player.PlayerFinisherMove.Enable();
            }
        }
    }
}
