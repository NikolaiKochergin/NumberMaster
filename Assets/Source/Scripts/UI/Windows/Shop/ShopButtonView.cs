using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Scripts.UI.Windows.Shop
{
    public class ShopButtonView : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _currentLevelText;
        [SerializeField] private TextMeshProUGUI _nextLevelText;
        [SerializeField] private TextMeshProUGUI _priceText;
        [SerializeField] private Color _defaultColor;
        [SerializeField] private Color _notEnoughMoneyColor;

        public void SetCurrentLevelText(string text) => 
            _currentLevelText.text = text;

        public void SetNextLevelText(string text) => 
            _nextLevelText.text = text;

        public void SetPriceText(int value) => 
            _priceText.text = value.ToString();

        public void SetDefaultColor() =>
            _priceText.color = _defaultColor;

        public void SetNotEnoughMoneyColor() =>
            _priceText.color = _notEnoughMoneyColor;

        public void SetIcon(Sprite icon) => 
            _icon.sprite = icon;
    }
}
