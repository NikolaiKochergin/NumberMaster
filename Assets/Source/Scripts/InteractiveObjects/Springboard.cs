using DG.Tweening;
using Source.Scripts.InteractiveObjects;
using Source.Scripts.PlayerLogic;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Springboard : MonoBehaviour
{
    [SerializeField] private TriggerObserver _triggerObserver;
    [SerializeField] private AnimationCurve _jumpCurve;
    [SerializeField][Min(0)] private float _duration = 1;

    private void OnEnable()
    {
        _triggerObserver.TriggerEnter += MovePlayer;
    }


    private void OnDisable()
    {
        _triggerObserver.TriggerEnter -= MovePlayer;
    }

    private void MovePlayer(Collider obj)
    {
        if(obj.TryGetComponent(out Player player))
        {
            Move(player.transform);
        }
    }

    private void Move(Transform targetTransform)
    {
        DG.Tweening.Sequence sequence = DOTween.Sequence();
        sequence.Append(targetTransform.DOMoveY(targetTransform.position.y, _duration).SetEase(_jumpCurve));
        targetTransform.DOMoveY(targetTransform.position.y, _duration).SetEase(_jumpCurve);
        Debug.Log("Прыжок");
    }

}
