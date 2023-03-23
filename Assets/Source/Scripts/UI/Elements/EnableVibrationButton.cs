using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Scripts.UI.Elements
{
    public class EnableVibrationButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private TextMeshProUGUI _buttonText;

        public Button Button => _button;

        public void SetOffVibrationView() => 
            _buttonText.text = "Vibration is Off";

        public void SetOnVibrationView() => 
            _buttonText.text = "Vibration is On";
    }
}
