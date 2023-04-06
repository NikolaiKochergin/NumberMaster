using UnityEngine;
using UnityEngine.UIElements;

namespace XXX___Hlam___XXX
{
    public class TryMinMaxSlider : MonoBehaviour
    {
        [SerializeField] private MinMaxSlider _minMaxSlider;

        private void Update()
        {
            Debug.Log(_minMaxSlider.value);
        }
    }
}
