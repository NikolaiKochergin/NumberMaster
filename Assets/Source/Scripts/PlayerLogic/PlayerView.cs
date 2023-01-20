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

            int length = numberString.Length > _numberViews.Count ? numberString.Length : _numberViews.Count;

            if (numberString.Length > _numberViews.Count)
            {
                for (int i = _numberViews.Count; i < numberString.Length; i++)
                {
                    var number = Instantiate(_numberViews[0], transform);
                    _numberViews.Add(number);
                    
                }
            }
            

            for (int i = 0; i < numberString.Length; i++) 
                _numberViews[i].Show(numberString[i]);
        }
    }
}