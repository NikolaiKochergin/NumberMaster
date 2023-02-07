using UnityEngine;

namespace Source.Scripts.PlayerLogic.ViewLogic
{
    public class Number : MonoBehaviour
    {
        [SerializeField] private NumberView _numberView;
        [SerializeField] private GroundChecker _groundChecker;

        public NumberView NumberView => _numberView;
        public GroundChecker GroundChecker => _groundChecker;
    }
}
