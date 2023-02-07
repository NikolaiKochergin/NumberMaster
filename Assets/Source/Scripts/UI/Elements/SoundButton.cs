using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Scripts.UI.Elements
{
    public class SoundButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private TextMeshProUGUI _buttonText;

        public Button Button => _button;

        public void SetMuteView() => 
            _buttonText.text = "UnMute";

        public void SetUnMuteView() => 
            _buttonText.text = "Mute";
    }
}
