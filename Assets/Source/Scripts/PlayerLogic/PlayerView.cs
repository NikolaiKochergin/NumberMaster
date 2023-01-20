﻿using System.Collections.Generic;
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
            {
                for (int i = _numberViews.Count; i < numberString.Length; i++)
                {
                    NumberView number = Instantiate(_numberViews[0], transform);
                    number.transform.localPosition += transform.right * i * 0.5f;
                    _numberViews.Add(number);
                }
            }
            else if(numberString.Length < _numberViews.Count)
            {
                for (int i = _numberViews.Count - 1; _numberViews.Count > numberString.Length; i--)
                {
                    NumberView number = _numberViews[i];
                    _numberViews.Remove(number);
                    Destroy(number.gameObject);
                }
            }
            

            for (int i = 0; i < numberString.Length; i++) 
                _numberViews[i].Show(numberString[i]);
        }
    }
}