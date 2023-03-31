using UnityEngine;

namespace XXX___Hlam___XXX.DeformMat
{
    [ExecuteInEditMode]
    public class SetInsideMassMatrix : MonoBehaviour
    {
        [SerializeField] private Renderer _jellyRenderer;
        [SerializeField] private Matrix4x4 _insideMassMatrix;
        [SerializeField] private Transform _insideMassTransform;

        private void Update()
        {
            _insideMassMatrix = _insideMassTransform.localToWorldMatrix;
            _jellyRenderer.material.SetMatrix("_InsideMassMatrix", _insideMassMatrix);
        }
    }
}
