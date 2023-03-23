using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VibrationButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _buttonText;

    public Button Button => _button;

    public void SetOffVibrationView() => 
        _buttonText.text = "Off Vibration";

    public void SetOnVibrationView() => 
        _buttonText.text = "On Vibration";
}
