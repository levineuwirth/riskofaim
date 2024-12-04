using TMPro;
using UnityEngine;

public class Score : MonoBehaviour {

    [field: SerializeField] public int scoreIncrement {get; private set;}
    private static int _score;
    void Start() {
        _score = 0;
    }
    public static int GetScore() {
        return _score;
    }
    private void AddScore() {
        _score += scoreIncrement;
    }
}