using DG.Tweening;
using UnityEngine;

namespace Source.Scripts.PlayerLogic
{
    public class ActorIsOnGround : MonoBehaviour
    {
        [SerializeField] private GroundChecker _groundChecker;
        [SerializeField] private float _offsetY;
        [SerializeField] [Min(0)] private float _moveDuration = 0.2f;
        
        private void OnEnable() => 
            _groundChecker.Changed += OnGroundChanged;

        private void OnDisable() => 
            _groundChecker.Changed -= OnGroundChanged;

        private void OnGroundChanged()
        {
            if (_groundChecker.IsOnGround)
                MoveUp();
            else
                MoveDown();
        }

        private void MoveUp() =>
            transform.DOLocalMoveY(0, _moveDuration);

        private void MoveDown() => 
            transform.DOLocalMoveY(_offsetY, _moveDuration);
    }
}
