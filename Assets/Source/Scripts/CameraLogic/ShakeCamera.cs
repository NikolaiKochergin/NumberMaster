using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private const string Shake = "Shake";
    public void PlayCameraShake()
    {
        _animator.SetTrigger(Shake);
    }
}
