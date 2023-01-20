#if UNITY_EDITOR
using System.Collections.Generic;
using Source.Scripts.InteractiveObjects.Finisher;
using UnityEngine;

namespace Source.Scripts.Tools
{
    [ExecuteAlways]
    public class Colorant : MonoBehaviour
    {
        [SerializeField] private Material _templateMaterial;
        [SerializeField] private Gradient _gradient;
        private float _gradientStep;

        private readonly List<MeshRenderer> _meshRenderers = new();
        private int _oldCount;

        private void Start()
        {
            if (Application.IsPlaying(this))
            {
                CorrectColor();
                Destroy(this);
            }

            _oldCount = transform.childCount;
        }

        private void Update()
        {
            if (_oldCount != transform.childCount)
            {
                _oldCount = transform.childCount;
                CorrectColor();
            }
        }

        private void OnValidate() => 
            CorrectColor();

        private void CorrectColor()
        {
            if (_templateMaterial == null)
                return;

            _meshRenderers.Clear();

            FinishPanel[] finishPanels = GetComponentsInChildren<FinishPanel>();

            foreach (FinishPanel panel in finishPanels)
                _meshRenderers.Add(panel.GetComponentInChildren<MeshRenderer>());

            if (_meshRenderers.Count == 0)
                return;
            
            if(_meshRenderers.Count > 1)
                _gradientStep = 1.0f / (_meshRenderers.Count - 1);
            
            for (int i = 0; i < _meshRenderers.Count; i++)
            {
                Material material = new(_templateMaterial);

                material.color = _gradient.Evaluate(_gradientStep * i);

                _meshRenderers[i].material = material;
            }
        }
    }
}
#endif