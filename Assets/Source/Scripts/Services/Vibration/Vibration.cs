using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Vibration : MonoBehaviour
{
    [SerializeField] private Button _vibrationOnes;
    [SerializeField] private Button _vibrationHoldBegin;
    [SerializeField] private Button _vibrationHoldStop;
    

    private Coroutine _vibrationCoroutine;

    private void Start()
    {
        _vibrationOnes.onClick.AddListener(PlayVibration);
        _vibrationHoldBegin.onClick.AddListener(() =>
        {
            _vibrationCoroutine = StartCoroutine(VibrationCoroutine());
        });
        _vibrationHoldStop.onClick.AddListener(() =>
        {
            StopCoroutine(_vibrationCoroutine);
        });
    }

    private IEnumerator VibrationCoroutine()
    {
        while (true)
        {
            PlayVibration();
            yield return null;
        }
    }
    
    private void PlayVibration() => 
        Handheld.Vibrate();
}
