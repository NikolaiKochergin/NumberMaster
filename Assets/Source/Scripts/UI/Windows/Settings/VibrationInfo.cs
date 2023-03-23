using TMPro;
using UnityEngine;

namespace Source.Scripts.UI.Windows.Settings
{
    public class VibrationInfo : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _vibrationInfoText;
        
        public void SetVibrationInfo(bool isOn)
        {
            if (isOn)
            {
                _vibrationInfoText.text = "Can vibrate";
                _vibrationInfoText.color = Color.green;
            }
            else
            {
                _vibrationInfoText.text = "Can't vibrate";
                _vibrationInfoText.color = Color.red;
            }
        }
    }
}
