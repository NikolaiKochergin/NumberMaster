using TMPro;
using UnityEngine;

namespace Source.Scripts.UI.Windows.Shop
{
    public class ShopButtonShowing : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _currentLevelText;
        [SerializeField] private TextMeshProUGUI _nextLevelText;
        [SerializeField] private TextMeshProUGUI _priceText;

        public void SetCurrentLevelText(string text) => 
            _currentLevelText.text = text;

        public void SetNextLevelText(string text) => 
            _nextLevelText.text = text;

        public void SetPriceText(int value) => 
            _priceText.text = value.ToString();
    }
}
