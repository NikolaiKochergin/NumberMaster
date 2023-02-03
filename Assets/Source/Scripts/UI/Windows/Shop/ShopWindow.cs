using Source.Scripts.Infrastructure.States;
using Source.Scripts.Services.IAP;
using Source.Scripts.Services.PersistentProgress;
using Source.Scripts.UI.Elements;
using UnityEngine;

namespace Source.Scripts.UI.Windows.Shop
{
    public sealed class ShopWindow : WindowBase
    {
        [SerializeField] private ClickedDownButton _startButton;
        [SerializeField] private ClickedDownButton _startNumberButton;
        [SerializeField] private ClickedDownButton _incomeButton;
        [SerializeField] private ShopButtonView _startNumberButtonView;
        [SerializeField] private ShopButtonView _incomeButtonView;
        
        private IGameStateMachine _stateMachine;
        private IIAPService _iapService;

        public void Construct(
            IGameStateMachine stateMachine, 
            IPersistentProgressService progressService,
            IIAPService iapService)
        {
            _stateMachine = stateMachine;
            _iapService = iapService;
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
            _iapService.Buy(PurchaseType.StartLevel);
            UpdateStartNumberButtonShowing();
            UpdateIncomeButtonShowing();
        }

        private void OnIncomeButtonClicked()
        {
            _iapService.Buy(PurchaseType.Incoming);
            UpdateStartNumberButtonShowing();
            UpdateIncomeButtonShowing();
        }

        private void UpdateStartNumberButtonShowing()
        {
            int price = _iapService.GetPriceOf(PurchaseType.StartLevel);
            _startNumberButtonView.SetPriceText(price);
            _startNumberButtonView.SetCurrentLevelText(Progress.PlayerStats.StartNumber.ToString());
            _startNumberButtonView.SetNextLevelText((Progress.PlayerStats.StartNumber + _iapService.GetConfigOf(PurchaseType.StartLevel).SalableValue).ToString());
            
            if(price > Progress.Soft.Collected)
                _startNumberButtonView.SetNotEnoughMoneyColor();
            else
                _startNumberButtonView.SetDefaultColor();
        }

        private void UpdateIncomeButtonShowing()
        {
            int price = _iapService.GetPriceOf(PurchaseType.Incoming);
            
            _incomeButtonView.SetPriceText(price);
            _incomeButtonView.SetCurrentLevelText("x" + Progress.PlayerStats.Income.ToString("0.0"));
            _incomeButtonView.SetNextLevelText("x" + (Progress.PlayerStats.Income + _iapService.GetConfigOf(PurchaseType.Incoming).SalableValue).ToString("0.0"));
            
            if(price > Progress.Soft.Collected)
                _incomeButtonView.SetNotEnoughMoneyColor();
            else
                _incomeButtonView.SetDefaultColor();
        }
    }
}