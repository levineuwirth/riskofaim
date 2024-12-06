using UnityEngine;

public class PauseManager : MonoBehaviour {
    public static bool isPaused = false;
    public static PauseManager Instance;

    private void Awake() {
        if(Instance == null) {
            Instance = this;
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }
    private void Start() {
        Pause();
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