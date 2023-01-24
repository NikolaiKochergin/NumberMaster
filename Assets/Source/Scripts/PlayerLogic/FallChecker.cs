using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Source.Scripts.PlayerLogic
{
    public class FallChecker : MonoBehaviour
    {
        private List<GroundChecker> _groundCheckers = new List<GroundChecker>();

        private bool _isEnable = true;
        
        public event Action FallHappened;

        private void Awake() => 
            Disable();

        public void Add(GroundChecker checker)
        {
            _groundCheckers.Add(checker);
            checker.Changed += IsOnGroundChanged;
        }

        public void Remove(GroundChecker checker)
        {
            _groundCheckers.Remove(checker);
            checker.Changed -= IsOnGroundChanged;
        }

        public void Enable()
        {
            _isEnable = true;
            IsOnGroundChanged();
        }

        public void Disable() => 
            _isEnable = false;

        private void IsOnGroundChanged()
        {
            if(_isEnable == false)
                return;
            
            if (_groundCheckers.Any(checker => checker.IsOnGround))
                return;

            FallHappened?.Invoke();
        }
    }
}
