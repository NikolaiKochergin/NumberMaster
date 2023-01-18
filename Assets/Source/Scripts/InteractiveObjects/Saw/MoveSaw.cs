using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Source.Scripts.InteractiveObjects.Saw
{
    public class MoveSaw : MonoBehaviour
    {
        private void Start()
        {
            transform.DOMove(new Vector3(2,transform.position.y,transform.position.z),2).SetLoops(-1,LoopType.Yoyo);
        }
    }
}