using DG.Tweening;
using Source.Scripts.PlayerLogic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageWal : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _dely;

    private Player _player;
    private float _elepsedTime = 0;

    private void Awake()
    {
        enabled = false;
    }

    private void Update()
    {
        _elepsedTime += Time.deltaTime;

        if (_elepsedTime >= _dely)
        {
            if(transform.localScale.z > 0)
            {
                _player.PlayerNumber.TakeNumber(-_damage);
                transform.localScale -= new Vector3(0, 0f, 1.5f);
            }
            else
            {
                transform.localScale= Vector3.zero;
            }
            
            _elepsedTime = 0;
            Debug.Log("Удары!");
        }
    }

    public void SetHealth(Player player)
    {
        _player = player;
    }
}
