using TMPro;
using UnityEngine;

namespace Source.Scripts.UI.Windows.GameLoop
{
    public class Counter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _counterText;

        public void SetText(int number) => 
            _counterText.text = number.ToString();
    }
}
