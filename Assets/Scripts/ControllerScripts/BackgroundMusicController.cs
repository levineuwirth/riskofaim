using UnityEngine;

public class BackgroundMusicController : MonoBehaviour {
    public static BackgroundMusicController instance;
    [field: SerializeField] public AudioClip backgroundMusic {get; private set;}
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
    private void Start() {
        // SoundController.Instance.PlaySoundClip(backgroundMusic, this.transform, 0.3f, true);
    }
}