using TMPro;
using UnityEngine;

namespace Source.Scripts.InteractiveObjects
{
    public class NumberText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        public void SetText(int value) => 
            _text.text = value.ToString();
    }
}
