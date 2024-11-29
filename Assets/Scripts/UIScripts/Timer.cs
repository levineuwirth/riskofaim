using System;
using TMPro;
using UnityEngine;
using UnityEngine.Video;
public class Timer : MonoBehaviour
{
    public delegate void OnRoundEnd();
    public static OnRoundEnd EOnRoundEnd;
    [field: SerializeField] public float timerDurationSeconds {get; private set;}
    [field: SerializeField] public TextMeshProUGUI timerText {get; private set;}
    private bool _timerActive = true;
    private float _timeLeft;
    private TimeSpan _timeSpan;

    void Start()
    {
        RoundController.EStartRound += ResetTimer;

        ResetTimer();
    }

    void Update()
    {
        if(_timerActive) {
            _timeLeft -= Time.deltaTime;

            if(_timeLeft <= 0) {
                _timerActive = false;
                _timeLeft = 0;

                EOnRoundEnd?.Invoke();
            }
        }

        _timeSpan = TimeSpan.FromSeconds(_timeLeft);
        timerText.text = _timeSpan.Minutes.ToString() + " : " + _timeSpan.Seconds.ToString() + " : " + _timeSpan.Milliseconds.ToString();
    }

    public void ResetTimer() {
        _timerActive = true;
        _timeLeft = timerDurationSeconds;
    }

    private void OnDestroy() {
        RoundController.EStartRound -= ResetTimer;
    }
}
