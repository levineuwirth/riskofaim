using UnityEngine;

public class PauseManager : MonoBehaviour {
    public static bool isPaused = false;
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
        if (!isPaused) {
            isPaused = true;
            Time.timeScale = 0;
        }
    }

    public static void Unpause() {
        if(isPaused) {
            isPaused = false;
            Time.timeScale = 1;
        }
    }
}