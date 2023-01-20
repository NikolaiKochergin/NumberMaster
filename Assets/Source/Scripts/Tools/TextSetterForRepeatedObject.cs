#if UNITY_EDITOR
using Source.Scripts.InteractiveObjects.Finisher;
using TMPro;
using UnityEngine;

namespace Source.Scripts.Tools
{
    [ExecuteInEditMode]
    public class TextSetterForRepeatedObject : MonoBehaviour
    {
        [SerializeField] private int _startValue;
        [SerializeField] private int _increment;

        private void Start()
        {
            if (Application.IsPlaying(this))
            {
                CorrectText();
                Destroy(this);
            }
        }
        
        private void Update() => 
            CorrectText();

        private void OnValidate() => 
            CorrectText();

        private void CorrectText()
        {
            FinishPanel[] finishPanels = GetComponentsInChildren<FinishPanel>();

            for (int i = 0; i < finishPanels.Length; i++)
            {
                TextMeshProUGUI[] texts = finishPanels[i].GetComponentsInChildren<TextMeshProUGUI>();
                foreach (TextMeshProUGUI text in texts) 
                    text.text = (_startValue + _increment * i).ToString();
            }
        }
    }
}
#endif