using UnityEngine;

public class SoundController : MonoBehaviour {
    public static SoundController Instance;
    [field: SerializeField] public AudioSource soundFXObject {get; private set;}

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

    public void PlaySoundClip(AudioClip audioClip, Transform spawnTransform, float volume) {
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.Play();
        float clipLength = audioClip.length;
        Destroy(audioSource, clipLength);
    }
        public void PlaySoundClip(AudioClip audioClip, Transform spawnTransform, float volume, bool loop) {
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.loop = loop;
        audioSource.Play();
        float clipLength = audioClip.length;
        Destroy(audioSource, clipLength);
    }
}