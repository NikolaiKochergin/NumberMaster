using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Plugins.Vibration
{
    public class VibrationAPI : MonoBehaviour
    {
        [SerializeField] private Button _vibrationOnesButton;

        private void Awake() => 
            _vibrationOnesButton.onClick.AddListener(OnVibrationButtonClicked);

        [DllImport("__Internal")]
        private static extern void Vibration();

        private void OnVibrationButtonClicked() => 
            Vibration();
    }
}