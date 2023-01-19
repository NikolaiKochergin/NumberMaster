using Source.Scripts.InteractiveObjects;
using Source.Scripts.PlayerLogic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private TriggerObserver _triggerObserver;

    private void OnEnable()
    {
        _triggerObserver.TriggerEnter += —hange—ontrol;
    }

    private void OnDisable()
    {
        _triggerObserver.TriggerEnter -= —hange—ontrol;
    }

    private void —hange—ontrol(Collider collider)
    {
        if(collider.TryGetComponent(out Player player))
        {
            player.PlayerMove.enabled = false;
            player.PlayerMoveFinish.enabled = true;
        }
    }
}
