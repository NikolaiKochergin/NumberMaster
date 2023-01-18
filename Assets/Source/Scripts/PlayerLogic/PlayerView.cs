using TMPro;
using UnityEngine;

namespace Source.Scripts.PlayerLogic
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _numberText;
        
        public void SetValue(int playerNumberCurrent) => 
            _numberText.text = playerNumberCurrent.ToString();
    }
}