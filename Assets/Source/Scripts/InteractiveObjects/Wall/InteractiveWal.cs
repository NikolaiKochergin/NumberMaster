using Source.Scripts.InteractiveObjects.Number;
using Source.Scripts.InteractiveObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Source.Scripts.PlayerLogic;

public class InteractiveWal : MonoBehaviour
{
    [SerializeField] private TriggerObserver _triggerObserver;
    [SerializeField] private InteractiveNumberView _interactiveNumberView;
    [SerializeField] private DamageWal _damageWal;
    [SerializeField] private int _value;
    [SerializeField] private float _slowDownSpeed;

    private float _speed = 0;

    private void Awake()
    {
        _interactiveNumberView.SetValue(_value);
    }

    private void OnEnable()
    {
        _triggerObserver.TriggerEnter += AffectPlayer;
        _triggerObserver.TriggerExit += AffectPlayerOff;
    }

    private void OnDisable()
    {
        
    }

    private void OnDestroy() =>
            _triggerObserver.TriggerEnter -= AffectPlayer;

    public void TakeDamage(int damage)
    {
        _value -= damage;
        if (_value < 0)
            _value = 0;
        Show();
    }

    private void Show()
    {
        _interactiveNumberView.SetValue(_value);
    }

    private void AffectPlayer(Collider other)
    {
        if (!other.TryGetComponent(out Player player)) return;
        if (player.PlayerNumber.Current >= _value)
        {
            _speed = player.PlayerMove.Speed;
            player.PlayerMove.SetSpeed(_slowDownSpeed);
            _damageWal.enabled = true;
            _damageWal.SetHealth(player,this);
            //playerNumber.TakeNumber(_value);
            //Die();
        }
        else
        {
            Debug.Log("Player Die");
        }
    }

    private void AffectPlayerOff(Collider collider)
    {
        if(collider.TryGetComponent(out Player player))
        {
            _damageWal.enabled = false;
            player.PlayerMove.SetSpeed(_speed);
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
