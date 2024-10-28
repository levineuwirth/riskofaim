using TMPro;
using UnityEngine;

public class Score : MonoBehaviour {

    [field: SerializeField] public TextMeshProUGUI scoreText {get; private set;}
    private int _score;

    void Start() {
        _score = 0;
    }
    void Update() {
        
    }
}