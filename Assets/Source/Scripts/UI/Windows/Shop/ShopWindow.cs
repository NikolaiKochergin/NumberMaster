using Source.Scripts.Infrastructure.States;
using Source.Scripts.Services.PersistentProgress;
using UnityEngine;

namespace Source.Scripts.UI.Windows.Shop
{
    public sealed class ShopWindow : WindowBase
    {
        [SerializeField] private ClickedDownButton _startButton;
        [SerializeField] private ClickedDownButton _startNumberButton;
        [SerializeField] private ClickedDownButton _incomeButton;
        [SerializeField] private ShopButtonShowing _startNumberButtonShowing;
        [SerializeField] private ShopButtonShowing _incomeButtonShowing;
        
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