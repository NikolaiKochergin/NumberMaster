using TMPro;
using UnityEngine;

namespace Source.Scripts.UI.Elements
{
    public class SliderValueText : MonoBehaviour
    {
        [SerializeField] private TMP_Text _valueText;

        public void SetText(float value) => 
            _valueText.text = value.ToString("0");
    }
}
