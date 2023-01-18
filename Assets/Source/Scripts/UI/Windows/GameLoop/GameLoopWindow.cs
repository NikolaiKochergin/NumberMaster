using Source.Scripts.Services.PersistentProgress;
using UnityEngine;

namespace Source.Scripts.UI.Windows.GameLoop
{
    public class GameLoopWindow : WindowBase
    {
        [SerializeField] private SoftCounter _softCounter;
        [SerializeField] private LevelCounter _levelCounter;

        public override void Construct(IPersistentProgressService progressService)
        {
            base.Construct(progressService);
            _softCounter.Construct(Progress.Soft);
        }

        protected override void Initialize()
        {
            base.Initialize();
            _levelCounter.SetLevel(Progress.World.CurrentLevel);
        }
    }
}