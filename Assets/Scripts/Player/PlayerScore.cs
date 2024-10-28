using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour {

    [field: SerializeField] public TextMeshProUGUI scoreText {get; private set;}
    private int _score;

    void Start() {
        _score = 0;
    }
    void Update() {
        
    }
}