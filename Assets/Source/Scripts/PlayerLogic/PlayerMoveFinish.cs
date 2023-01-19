using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveFinish : MonoBehaviour
{
    [SerializeField] private float _positionX;
    [SerializeField] private float _duration;
    [SerializeField] private float _speed;


    private void Awake()
    {
        enabled = false;
    }
    private void Update()
    {
        transform.DOMoveX(_positionX, _duration);
        transform.position += transform.forward * _speed * Time.deltaTime;
    }

    public void SetSpeed(float speed)
    {
        _speed += speed;
    }
}
