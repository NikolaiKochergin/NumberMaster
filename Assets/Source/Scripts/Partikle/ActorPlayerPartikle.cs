using Source.Scripts.PlayerLogic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorPlayerPartikle : MonoBehaviour
{
    [SerializeField] private PlayerNumber _playerNumber;
    [SerializeField] private ParticleSystem _particleSystemWallDistroi;
    [SerializeField] private ParticleSystem _partikleSistemIncreaseNumber;

    private void OnEnable()
    {
        _playerNumber.NumberChanged += UpNumperPlayPartikleSistem;
    }

    private void OnDisable()
    {
        _playerNumber.NumberChanged -= UpNumperPlayPartikleSistem;
    }

    public void PlayPartikleDestroyWall()
    {
        _particleSystemWallDistroi.Play();
    }

    public void StopPartikleDestroyWall()
    {
        _particleSystemWallDistroi.Stop();
    }

    public void UpNumperPlayPartikleSistem()
    {
        _partikleSistemIncreaseNumber.Play();
    }
}
