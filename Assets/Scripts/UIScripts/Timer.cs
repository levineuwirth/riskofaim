using System;
using TMPro;
using UnityEngine;
public class Timer : MonoBehaviour {

    public delegate void BeforeRoundEnd();
    public static BeforeRoundEnd EBeforeRoundEnd;
    public delegate void OnRoundEnd();
    public static OnRoundEnd EOnRoundEnd;
    [field: SerializeField] public float timerDurationSeconds {get; private set;}
    [field: SerializeField] public TextMeshProUGUI timerText {get; private set;}
    private bool _timerActive;
    private float _timeLeft;
    private TimeSpan _timeSpan;

    void Start()
    {
        Countdown.EActivateRound += ResetTimer;

        _timerActive = false;
    }

    void Update()
    {
        if(_timerActive) {
            _timeLeft -= Time.deltaTime;

            if(_timeLeft <= 0) {
                _timerActive = false;
                _timeLeft = 0;

                EBeforeRoundEnd?.Invoke();
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
        Countdown.EActivateRound -= ResetTimer;
    }
}
