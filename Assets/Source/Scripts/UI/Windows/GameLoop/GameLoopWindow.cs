using UnityEngine;

namespace Source.Scripts.UI.Windows.GameLoop
{
    public sealed class GameLoopWindow : WindowBase
    {
        [SerializeField] private Counter _softCounter;
        [SerializeField] private Counter _levelCounter;

        protected override void Initialize()
        {
            base.Initialize();
            SetCurrentLevelNumberText();
            RefreshSoftValueText();
        }

        protected override void SubscribeUpdates() => 
            Progress.Soft.Changed += RefreshSoftValueText;

        protected override void Cleanup()
        {
            base.Cleanup();
            Progress.Soft.Changed -= RefreshSoftValueText;
        }

        private void RefreshSoftValueText() => 
            _softCounter.SetText(Progress.Soft.Collected);

        private void SetCurrentLevelNumberText() => 
            _levelCounter.SetText(Progress.World.DisplayedLevel);
    }
}