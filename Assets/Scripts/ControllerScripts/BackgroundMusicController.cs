using UnityEngine;

public class BackgroundMusicController : MonoBehaviour {
    public static BackgroundMusicController instance;
    private void Awake() {
        if(instance == null) {
            instance = this;
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }
}