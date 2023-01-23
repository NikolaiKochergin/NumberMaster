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
        [SerializeField] private float _jumpForse;

        private void OnEnable() => 
            _triggerObserver.TriggerEnter += MovePlayer;

        private void OnDisable() => 
            _triggerObserver.TriggerEnter -= MovePlayer;

        private void MovePlayer(Collider other)
        {
            if (other.attachedRigidbody.TryGetComponent(out Player player))
            {
                Move(player.transform);
                _triggerObserver.gameObject.SetActive(false);
            }
        }

        private void Move(Transform targetTransform) => 
            targetTransform
                .DOMoveY(_jumpForse, _duration)
                .SetEase(_jumpCurve)
                .OnComplete(() => targetTransform.position = new Vector3(targetTransform.position.x, 0, targetTransform.position.z));
    }
}