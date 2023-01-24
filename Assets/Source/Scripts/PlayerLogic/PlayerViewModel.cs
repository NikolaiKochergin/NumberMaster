using System.Collections.Generic;
using Source.Scripts.PlayerLogic.ViewLogic;
using UnityEngine;

namespace Source.Scripts.PlayerLogic
{
    public class PlayerViewModel : MonoBehaviour
    {
        [SerializeField] private List<Number> _numbers;
        [SerializeField] private FallChecker _fallChecker;

        public FallChecker FallChecker => _fallChecker;

        private void Awake() => 
            _fallChecker.Add(_numbers[0].GroundChecker);

        public void ShowValue(int playerNumberCurrent)
        {
            string numberString = playerNumberCurrent.ToString();

            if (numberString.Length > _numbers.Count)
                AddNumbers(numberString);
            else if(numberString.Length < _numbers.Count) 
                RemoveNumbers(numberString);

            InitNumbers(numberString);
        }

        private void InitNumbers(string numberString)
        {
            for (int i = 0; i < numberString.Length; i++)
                _numbers[i].NumberView.Show(numberString[i]);
        }

        private void AddNumbers(string numberString)
        {
            for (int i = _numbers.Count; i < numberString.Length; i++)
            {
                Number number = Instantiate(_numbers[0], transform);
                _numbers.Add(number);
                _fallChecker.Add(number.GroundChecker);
            }
            
            UpdateNumbersPositions();
        }

        private void RemoveNumbers(string numberString)
        {
            for (int i = _numbers.Count - 1; _numbers.Count > numberString.Length; i--)
            {
                Number number = _numbers[i];
                _numbers.Remove(number);
                _fallChecker.Remove(number.GroundChecker);
                Destroy(number.gameObject);
            }
            
            UpdateNumbersPositions();
        }

        private void UpdateNumbersPositions()
        {
            float firstCharOffset = (_numbers.Count - 1) * _numbers[0].transform.localScale.x / 2;
            _numbers[0].transform.localPosition = transform.right * -firstCharOffset;

            for (int i = 1; i < _numbers.Count; i++)
                _numbers[i].transform.localPosition = _numbers[0].transform.localPosition +
                                                     transform.right * (_numbers[0].transform.localScale.x * i);
        }
    }
}