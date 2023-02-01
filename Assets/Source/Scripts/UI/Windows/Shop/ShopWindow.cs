using Source.Scripts.Infrastructure.Factory;
using Source.Scripts.Infrastructure.States;
using Source.Scripts.Services.PersistentProgress;
using Source.Scripts.Services.StaticData;
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
        private IStaticDataService _staticData;
        private IGameFactory _factory;

        public void Construct(IGameStateMachine stateMachine, IPersistentProgressService progressService, IStaticDataService staticData, IGameFactory factory)
        {
            _stateMachine = stateMachine;
            _staticData = staticData;
            _factory = factory;
            base.Construct(progressService);
        }

        protected override void Initialize()
        {
            UpdateStartNumberButtonShowing();
            UpdateIncomeButtonShowing();
        }

        protected override void SubscribeUpdates()
        {
            _startButton.ClickedDown += OnClickedDown;
            _startNumberButton.ClickedDown += OnStartNumberButtonClicked;
            _incomeButton.ClickedDown += OnIncomeButtonClicked;
        }

        protected override void Cleanup()
        {
            _startButton.ClickedDown -= OnClickedDown;
            _startNumberButton.ClickedDown -= OnStartNumberButtonClicked;
            _incomeButton.ClickedDown -= OnIncomeButtonClicked;
        }

        private void OnClickedDown()
        {
            Close();
            _stateMachine.Enter<GameLoopState>();
        }

        private void OnStartNumberButtonClicked()
        {
            if (_staticData.ForStartNumberBasePrice() * Progress.PlayerStats.StartNumber >
                Progress.Soft.Collected) return;
            
            _factory.Player.PlayerNumber.TakeNumber(1);
            Progress.Soft.Collected -= _staticData.ForStartNumberBasePrice() * Progress.PlayerStats.StartNumber;
            Progress.PlayerStats.StartNumber += 1;
            UpdateStartNumberButtonShowing();
            UpdateIncomeButtonShowing();
        }

        private void OnIncomeButtonClicked()
        {
            if(_staticData.ForIncomeBasePrice() * Progress.PlayerStats.IncomeLevel > Progress.Soft.Collected)
                return;

            Progress.Soft.Collected -= _staticData.ForIncomeBasePrice() * Progress.PlayerStats.IncomeLevel;
            Progress.PlayerStats.IncomeLevel += 1;
            UpdateStartNumberButtonShowing();
            UpdateIncomeButtonShowing();
        }

        private void UpdateStartNumberButtonShowing()
        {
            _startNumberButtonShowing.SetPriceText(_staticData.ForStartNumberBasePrice() * Progress.PlayerStats.StartNumber);
            _startNumberButtonShowing.SetCurrentLevelText(Progress.PlayerStats.StartNumber.ToString());
            _startNumberButtonShowing.SetNextLevelText((Progress.PlayerStats.StartNumber + 1).ToString());
            
            if(_staticData.ForStartNumberBasePrice() * Progress.PlayerStats.StartNumber > Progress.Soft.Collected)
                _startNumberButtonShowing.SetNotEnoughMoneyColor();
            else
                _startNumberButtonShowing.SetDefaultColor();
        }

        private void UpdateIncomeButtonShowing()
        {
            _incomeButtonShowing.SetPriceText(_staticData.ForIncomeBasePrice() * Progress.PlayerStats.IncomeLevel);
            _incomeButtonShowing.SetCurrentLevelText("x" + (1.0f + (Progress.PlayerStats.IncomeLevel - 1) * _staticData.ForIncomeIncrement()).ToString("0.0"));
            _incomeButtonShowing.SetNextLevelText("x" + (1.0f + (Progress.PlayerStats.IncomeLevel) * _staticData.ForIncomeIncrement()).ToString("0.0"));
            
            if(_staticData.ForIncomeBasePrice() * Progress.PlayerStats.IncomeLevel > Progress.Soft.Collected)
                _incomeButtonShowing.SetNotEnoughMoneyColor();
            else
                _incomeButtonShowing.SetDefaultColor();
        }
    }
}