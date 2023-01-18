using TMPro;
using UnityEngine;

public class LevelCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counterText;

    public void SetLevel(int number) => 
        _counterText.text = number.ToString();
}
