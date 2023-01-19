using Source.Scripts.Data;
using Source.Scripts.Services.PersistentProgress;
using UnityEngine;

namespace Source.Scripts.UI.Windows
{
    public abstract class WindowBase : MonoBehaviour
    {
        private IPersistentProgressService _progressService;
        protected PlayerProgress Progress => _progressService.Progress;

        public void Construct(IPersistentProgressService progressService) =>
            _progressService = progressService;

        private void Start()
        {
            Initialize();
            SubscribeUpdates();
        }

        private void OnDestroy() => 
            Cleanup();

        public virtual void Close() => 
            Destroy(gameObject);
        
        protected virtual void Initialize(){}
        protected virtual void SubscribeUpdates(){}
        protected virtual void Cleanup(){}
    }
}