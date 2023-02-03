using DG.Tweening;
using Source.Scripts.PlayerLogic;
using UnityEngine;

namespace Source.Scripts.InteractiveObjects
{
    public class Springboard : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _triggerObserver;
        [SerializeField] private AnimationCurve _jumpCurve;
        [SerializeField][Min(0)] private float _duration = 1;
        [SerializeField] private float _jumpForce = 1.5f;

        private void OnEnable() => 
            _triggerObserver.TriggerEnter += MovePlayer;

        private void OnDisable() => 
            _triggerObserver.TriggerEnter -= MovePlayer;

        private void MovePlayer(Collider other)
        {
            if (other.attachedRigidbody.TryGetComponent(out Player player))
            {
                Move(player);
                _triggerObserver.gameObject.SetActive(false);
            }
        }

        private void Move(Player player)
        {
            player.ActorFall.Disable();
            
            player.transform
                .DOMoveY(_jumpForce, _duration)
                .SetEase(_jumpCurve)
                .OnComplete(() =>
                {
                    player.transform.position =
                        new Vector3(player.transform.position.x, 0, player.transform.position.z);
                    player.ActorFall.Enable();
                });
        }
    }
}