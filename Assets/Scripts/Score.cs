using TMPro;
using UnityEngine;

public class Score : MonoBehaviour {

    [field: SerializeField] public int scoreIncrement {get; private set;}
    private static int _score;

    void Start() {
        _score = 0;
        PlayerShoot.EOnTargetHit += AddScore;
    }
    public static int GetScore() {
        return _score;
    }
    private void AddScore() {
        _score += scoreIncrement;
        Debug.Log(_score);
    }
    private void OnDestroy() {
        PlayerShoot.EOnTargetHit -= AddScore;
    }
}