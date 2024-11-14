using UnityEngine;

public class PauseManager : MonoBehaviour {
    private static bool _isPaused = false;
    public static PauseManager Instance;

    private void Awake() {
        if(Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }
    public static void Pause() {
        if (!_isPaused) {
            _isPaused = true;
            Time.timeScale = 0;
        }
    }

    public static void Unpause() {
        if(_isPaused) {
            _isPaused = false;
            Time.timeScale = 1;
        }
    }
}