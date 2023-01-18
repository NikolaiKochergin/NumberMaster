using Source.Scripts.Data;
using TMPro;
using UnityEngine;

namespace Source.Scripts.UI.Windows.GameLoop
{
    public sealed class SoftCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _counterText;

        private Soft _soft;
        
        public void Construct(Soft soft)
        {
            _soft = soft;
            _soft.Changed += UpdateCounter;
        }

        private void Start() => 
            UpdateCounter();

        private void OnDestroy()
        {
            if (_soft != null)
                _soft.Changed -= UpdateCounter;
        }

        private void UpdateCounter() => 
            _counterText.text = _soft.Collected.ToString();
    }
}
