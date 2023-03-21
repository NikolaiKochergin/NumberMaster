#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace Source.Scripts.Tools
{
    [ExecuteInEditMode]
    [SelectionBase]
    public class RepeatedObject : MonoBehaviour
    {
        [SerializeField] private Colorant _colorant;
        [SerializeField] private Vector3 _offset = Vector3.forward;
        [SerializeField] [Min(1)] private int _count = 1;

        private void Start()
        {
            if (Application.IsPlaying(this))
            {
                CorrectChildCount();
                Destroy(this);
            }
        }

        private void Update() => 
            CorrectChildCount();

        private void CorrectChildCount()
        {
            if(transform.childCount == 0)
                return;
            
            _count = Mathf.Clamp(_count, 1, 1000);

            if (transform.childCount < _count)
            {
                for (int i = transform.childCount; i < _count; i++)
                {
                    if (PrefabUtility.IsPartOfAnyPrefab(transform.GetChild(0)))
                    {
                        GameObject prefab = PrefabUtility.GetCorrespondingObjectFromOriginalSource(transform.GetChild(0)).gameObject;

                        Object instantiate = PrefabUtility.InstantiatePrefab(prefab, transform);
                        GameObject instantiateObject = (GameObject)instantiate;
                        instantiateObject.transform.Translate((_offset * i));
                    }
                    else
                    {
                        Transform instantiate = Instantiate(transform.GetChild(0), transform);
                        instantiate.Translate(_offset * i);
                    }
                }
            }
            else if (_count < transform.childCount)
            {
                for (int i = transform.childCount - 1; i >= _count; i--)
                {
                    DestroyImmediate(transform.GetChild(i).gameObject);
                }
            }
            
            _colorant.CollectFinishPanels();
        }
    }
}
#endif