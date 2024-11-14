using System;
using UnityEngine;

public class PauseManager : MonoBehaviour {
    private static bool _isPaused;

    private void Awake() {
        _isPaused = false;
    }
    public void Pause() {
        if (!_isPaused) {
            _isPaused = true;
        }
    }

    public void Unpause() {
        if(_isPaused) {
            _isPaused = false;
        }
    }
}