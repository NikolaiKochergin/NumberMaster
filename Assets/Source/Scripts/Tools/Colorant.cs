using Source.Scripts.InteractiveObjects.Finisher;
using UnityEngine;

namespace Source.Scripts.Tools
{
    public class Colorant : MonoBehaviour
    {
        private static readonly int Color = Shader.PropertyToID("_Color");
        
        [SerializeField] private Material _templateMaterial;
        [SerializeField] private Gradient _gradient;
        [SerializeField] private FinishPanel[] _finishPanels;
        
        private float _gradientStep;
        private MaterialPropertyBlock _propertyBlock;

        private void Start()
        {
            _propertyBlock = new MaterialPropertyBlock();
            CorrectColor();
        }

        private void CorrectColor()
        {
            if (_templateMaterial == null)
                return;
            
            switch (_finishPanels.Length)
            {
                case 0:
                    return;
                case > 1:
                    _gradientStep = 1.0f / (_finishPanels.Length - 1);
                    break;
            }

            for (int i = 0; i < _finishPanels.Length; i++)
            {
                _propertyBlock.SetColor(Color, _gradient.Evaluate(_gradientStep * i));
                _finishPanels[i].Renderer.SetPropertyBlock(_propertyBlock);
            }
        }

        public void CollectFinishPanels() => 
            _finishPanels = GetComponentsInChildren<FinishPanel>();
    }
}