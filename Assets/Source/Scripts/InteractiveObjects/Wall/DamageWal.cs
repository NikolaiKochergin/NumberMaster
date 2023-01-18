using DG.Tweening;
using Source.Scripts.PlayerLogic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageWal : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _dely;

    private InteractiveWal _interactiveWal;
    private Player _player;
    private float _elepsedTime = 0;
    private bool _isHit = false;

    private void Awake()
    {
        enabled = false;
    }

    private void Update()
    {
        _elepsedTime += Time.deltaTime;

        if (_elepsedTime >= _dely)
        {

            _isHit = true;

            if (transform.localScale.z > 0 && _isHit)
            {
                _player.PlayerNumber.TakeNumber(-_damage);
                _interactiveWal.TakeDamage(_damage);
                transform.localScale -= new Vector3(0, 0f, 1f);
                _isHit= false;
            }
            else
            {
                transform.localScale= Vector3.zero;
            }
            
            _elepsedTime = 0;
            Debug.Log("Удары!");
        }
    }

    public void SetHealth(Player player,InteractiveWal interactiveWal)
    {
        _player = player;
        _interactiveWal= interactiveWal;
    }
}
