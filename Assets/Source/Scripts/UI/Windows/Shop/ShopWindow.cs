using Source.Scripts.Infrastructure.States;
using Source.Scripts.Services.PersistentProgress;
using UnityEngine;

namespace Source.Scripts.UI.Windows.Shop
{
    public sealed class ShopWindow : WindowBase
    {
        [SerializeField] private StartButton _startButton;
        
        private IGameStateMachine _stateMachine;

        public void Construct(IGameStateMachine stateMachine, IPersistentProgressService progressService)
        {
            _stateMachine = stateMachine;
            base.Construct(progressService);
        }

        protected override void SubscribeUpdates() => 
            _startButton.ClickedDown += OnClickedDown;

        protected override void Cleanup() => 
            _startButton.ClickedDown -= OnClickedDown;

        private void OnClickedDown()
        {
            Close();
            _stateMachine.Enter<GameLoopState>();
        }
    }
}