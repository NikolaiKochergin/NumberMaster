using DG.Tweening;
using Newtonsoft.Json.Linq;
using Source.Scripts.CameraLogic;
using Source.Scripts.InteractiveObjects;
using Source.Scripts.InteractiveObjects.Number;
using Source.Scripts.PlayerLogic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPanel : MonoBehaviour
{
    [SerializeField] private int _value;
    [SerializeField] private InteractiveNumberView _interactiveNumberView;
    [SerializeField] private TriggerObserver _triggerObserver;
    [SerializeField] private ShakeCamera _shakeCamera;

    private void Awake()
    {
        _interactiveNumberView.SetValue(_value);
    }

    private void OnEnable()
    {
        _triggerObserver.TriggerEnter += IsPlayerWeaker;
    }

    private void OnDisable()
    {
        _triggerObserver.TriggerEnter -= IsPlayerWeaker;
    }

    private void IsPlayerWeaker(Collider collider)
    {
        if(collider.TryGetComponent(out Player player))
        {
            if(player.PlayerNumber.Current >= _value)
            {
                transform.position = new Vector3(transform.position.x,-8,transform.position.z);
                player.PlayerMoveFinish.SetSpeed(1);
                _shakeCamera.PlayCameraShake();
            }
            else
            {
                player.PlayerMoveFinish.enabled= false;
                Debug.Log("Смерть!");
            }
        }
    }
}
