using UnityEngine;

namespace Source.Scripts.InteractiveObjects.BlockLogic
{
    public class BlockViewModel : MonoBehaviour
    {
        [SerializeField] private Transform _model;
        [SerializeField] private NumberText _valueText;
        [SerializeField] private float _widthPerValue;

        public float WidthPerValue => _widthPerValue;

        public void SetViewBy(int value)
        {
            _model.localScale = new Vector3(
                _model.localScale.x,
                _model.localScale.y,
                _widthPerValue * value);


            _valueText.transform.localPosition = new Vector3(
                _valueText.transform.localPosition.x,
                _valueText.transform.localPosition.y,
                _model.localPosition.z - _widthPerValue * value);
            
            _valueText.SetText(-value);
        }
    }
}
