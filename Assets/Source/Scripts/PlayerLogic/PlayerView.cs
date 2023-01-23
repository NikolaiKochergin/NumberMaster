using System.Collections.Generic;
using Source.Scripts.PlayerLogic.ViewLogic;
using UnityEngine;

namespace Source.Scripts.PlayerLogic
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private List<NumberView> _numberViews;

        public void ShowValue(int playerNumberCurrent)
        {
            string numberString = playerNumberCurrent.ToString();

            if (numberString.Length > _numberViews.Count)
                AddNumbers(numberString);
            else if(numberString.Length < _numberViews.Count) 
                RemoveNumbers(numberString);

            InitNumbers(numberString);
        }

        private void InitNumbers(string numberString)
        {
            for (int i = 0; i < numberString.Length; i++)
                _numberViews[i].Show(numberString[i]);
        }

        private void RemoveNumbers(string numberString)
        {
            for (int i = _numberViews.Count - 1; _numberViews.Count > numberString.Length; i--)
            {
                NumberView number = _numberViews[i];
                _numberViews.Remove(number);
                Destroy(number.gameObject);
            }
            
            UpdateCharPositions();
        }

        private void AddNumbers(string numberString)
        {
            for (int i = _numberViews.Count; i < numberString.Length; i++)
            {
                NumberView number = Instantiate(_numberViews[0], transform);
                _numberViews.Add(number);
            }
            
            UpdateCharPositions();
        }

        private void UpdateCharPositions()
        {
            float firstCharOffset = (_numberViews.Count - 1) * _numberViews[0].transform.localScale.x / 2;
            _numberViews[0].transform.localPosition = transform.right * -firstCharOffset;

            for (int i = 1; i < _numberViews.Count; i++)
                _numberViews[i].transform.localPosition = _numberViews[0].transform.localPosition +
                                                          transform.right * _numberViews[0].transform.localScale.x * i;
        }
    }
}