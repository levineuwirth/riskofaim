using System;
using TMPro;
using UnityEngine;
using UnityEngine.Video;
public class Countdown : MonoBehaviour
{
    public delegate void ActivateRound();
    public static ActivateRound EActivateRound;
    [field: SerializeField] public GameObject countdownScreen {get; private set;}
    [field: SerializeField] public float timerDurationSeconds {get; private set;}
    [field: SerializeField] public TextMeshProUGUI timerText {get; private set;}
    private bool _timerActive;
    private float _timeLeft;
    private TimeSpan _timeSpan;

    void Start()
    {
        RoundController.EStartRound += ActivateCountdown;

        countdownScreen.SetActive(false);
        _timerActive = false;
    }

    void Update()
    {
        if(_timerActive) {
            _timeLeft -= Time.deltaTime;

            if(_timeLeft <= 0) {
                _timerActive = false;
                _timeLeft = 0;

                EActivateRound?.Invoke();
                countdownScreen.SetActive(false);
            }
        }

        _timeSpan = TimeSpan.FromSeconds(_timeLeft);
        timerText.text = (_timeSpan.Seconds + 1).ToString();
    }
    public void ResetTimer() {
        _timerActive = true;
        _timeLeft = timerDurationSeconds;
    }
    public void ActivateCountdown() {
        ResetTimer();
        countdownScreen.SetActive(true);
    }
    private void OnDestroy() {
        RoundController.EStartRound -= ActivateCountdown;
    }
}
