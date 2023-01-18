using TMPro;
using UnityEngine;

namespace Source.Scripts.InteractiveObjects.Number
{
    public class InteractiveNumberView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        public void SetValue(int value) => 
            _text.text = value.ToString();
    }
}
