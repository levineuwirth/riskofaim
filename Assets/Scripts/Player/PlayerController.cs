using UnityEngine;

public class PlayerController : MonoBehaviour {
    [field: SerializeField] public KeyCode primaryFire {get; private set;}
    [field: SerializeField] public KeyCode altFire {get; private set;}
    [field: SerializeField] public KeyCode reload {get; private set;}
    [field: SerializeField] public KeyCode pause {get; private set;}
    public static PlayerController Instance;
    private void Awake() {
        if(Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }
}