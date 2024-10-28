using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [field: SerializeField] public float timerDurationSeconds {get; private set;}
    [field: SerializeField] public TextMeshProUGUI timerText {get; private set;}
    private bool _timerActive = true;
    private float _timeLeft;
    private TimeSpan timeSpan;

    void Start()
    {
        _timerActive = true;
        _timeLeft = timerDurationSeconds;
    }

    void Update()
    {
        if(_timerActive) {
            _timeLeft -= Time.deltaTime;

            if(_timeLeft <= 0) {
                _timerActive = false;
                _timeLeft = 0;
            }
        }

        timeSpan = TimeSpan.FromSeconds(_timeLeft);
        timerText.text = timeSpan.Minutes.ToString() + " : " + timeSpan.Seconds.ToString() + " : " + timeSpan.Milliseconds.ToString();
    }
}
